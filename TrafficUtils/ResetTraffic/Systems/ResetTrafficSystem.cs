namespace ResetTraffic
{
    using Setting = TrafficUtils.Setting;
    using System;
    using Game;
    using Game.Common;
    using Game.Creatures;
    using Game.Input;
    using Game.Objects;
    using Game.Rendering;
    using Game.SceneFlow;
    using Game.Simulation;
    using Game.Tools;
    using Game.UI;
    using Game.UI.Localization;
    using Game.Vehicles;
    using Unity.Collections;
    using Unity.Entities;

    /// <summary>
    /// One-shot city-wide despawn: snapshot matching entities, then tag that list with
    /// <see cref="Deleted"/> through <see cref="ToolOutputBarrier"/>.
    /// </summary>
    /// <remarks>
    /// Hard-won constraints (native UNKNOWN crash / infinite remaining count):
    /// <list type="bullet">
    /// <item>Never <c>EntityManager.AddComponent&lt;Deleted&gt;</c> this frame — deferred ECB only.</item>
    /// <item>Snapshot once; do not keep deleting live queries (respawns never drain).</item>
    /// <item>Skip <see cref="Unspawned"/> (spawn-pending bounce) and <see cref="Temp"/> (tool ghosts).</item>
    /// <item>Do not tag while paused (<c>selectedSpeed &lt;= 0</c>) or while Options is open (<c>IsGame</c> is false).</item>
    /// <item>Pace with Unity render frames; simulation ticks stall at speed 0.</item>
    /// </list>
    /// Extra clicks while a run is in progress are ignored. Leaving the city clears via OnDestroy.
    /// </remarks>
    // Run just before ToolOutputBarrier so Deleted tags land in that frame's tool ECB.
    [UpdateBefore(typeof(ToolOutputBarrier))]
    public partial class ResetTrafficSystem : GameSystemBase
    {
        // Info-log cadence during a run. Verbose [DEBUG] lines are gated separately by ResetEnableDebugging.
        private const int LogEvery = 256;
        internal const string FinishDialogTitleId = "ResetTraffic.FinishDialog.Title";
        internal const string FinishDialogOkId = "ResetTraffic.FinishDialog.Ok";
        internal const string FinishDialogCountsId = "ResetTraffic.FinishDialog.Counts";

        // Runtime headlines for the Options Status line and the finish dialog body. Logs stay English;
        // only what the player reads goes through the active dictionary.
        internal const string StatusIdlePrefixId = "ResetTraffic.Status.IdlePrefix";
        internal const string StatusIdleFreshId = "ResetTraffic.Status.IdleFresh";
        internal const string StatusRunningId = "ResetTraffic.Status.Running";
        internal const string StatusQueuedId = "ResetTraffic.Status.Queued";
        internal const string StatusWaitingId = "ResetTraffic.Status.Waiting";
        internal const string StatusNoTypesId = "ResetTraffic.Status.NoTypes";
        internal const string StatusNothingMatchedId = "ResetTraffic.Status.NothingMatched";
        internal const string StatusSnapshotReadyId = "ResetTraffic.Status.SnapshotReady";
        internal const string StatusProgressId = "ResetTraffic.Status.Progress";
        internal const string StatusCompleteId = "ResetTraffic.Status.Complete";

        private EntityQuery m_MovingCars;
        private EntityQuery m_MovingBicycles;
        private EntityQuery m_MovingTrains;
        private EntityQuery m_MovingPublicTransport;
        private EntityQuery m_MovingTrucks;
        private EntityQuery m_MovingOther;
        private EntityQuery m_Pedestrians;
        private EntityQuery m_ParkedCars;
        private EntityQuery m_ParkedBicycles;
        private EntityQuery m_ParkedTrains;
        private EntityQuery m_ParkedOther;
        private ToolOutputBarrier m_Barrier;
        // Walked once per run. Persistent because the system lives across many frames.
        private NativeList<Entity> m_Snapshot;
        // Everything tagged during this run. Layout extras (train cars, articulated sections) also
        // appear in the snapshot, and the ECB has not played back yet, so HasComponent<Deleted> cannot
        // catch the repeat. Without this they would be tagged and counted twice.
        private NativeHashSet<Entity> m_Tagged;
        // Next index to consider; advanced even when the entity is already gone so Remaining can hit 0.
        private int m_SnapshotIndex;
        private bool m_SnapshotReady;
        // True from RequestReset until Finish. Extra button/hotkey presses are ignored while set.
        private bool m_Requested;
        // One Info line when waiting for speed > 0; the wait itself can last many frames.
        private bool m_LoggedWait;
        private int m_SessionCount;
        private int m_LastLoggedCount;
        private int m_LastProcessedFrame = -1;
        private int m_LastWaitLogFrame = -1;
        private bool m_LoggedNullHotkey;
        private int m_DebugSkipNull;
        private int m_DebugSkipMissing;
        private int m_DebugSkipDeleted;
        // True once OnDestroy starts so Finish cannot show a false-complete popup during teardown.
        private bool m_Disposing;

        internal static bool IsActive { get; private set; }

        // Options reads this via SettingsUIValueVersion so the Status line rebinds.
        internal static int UiVersion { get; private set; }

        internal static int RemainingCount { get; private set; }

        internal static int SnapshotTotal { get; private set; }

        internal static int RemovedCount { get; private set; }

        private static string StatusHeadline { get; set; }

        internal static string FormatStatus()
        {
            if (!IsActive && string.IsNullOrEmpty(StatusHeadline) && SnapshotTotal <= 0 && RemovedCount <= 0)
            {
                return TryLocalize(StatusIdleFreshId, "Idle. No reset yet this session.");
            }

            string counts = FormatCounts(RemainingCount, SnapshotTotal, RemovedCount);
            if (!IsActive)
            {
                // Idle with a headline reports the last result; idle without one still must not say Running.
                string idle = TryLocalize(StatusIdlePrefixId, "Idle.");
                return string.IsNullOrEmpty(StatusHeadline)
                    ? $"{idle} {counts}"
                    : $"{idle} {StatusHeadline} {counts}";
            }

            string head = string.IsNullOrEmpty(StatusHeadline)
                ? TryLocalize(StatusRunningId, "Running.")
                : StatusHeadline;

            return $"{head} {counts}";
        }

        /// <summary>
        /// Queue a reset. Shared by the Options button and the hotkey. Safe to call before the
        /// system's first ToolUpdate (creates the system if needed). No-ops if already running,
        /// not in a city, or no types are checked.
        /// </summary>
        public static void RequestReset()
        {
            World world = World.DefaultGameObjectInjectionWorld;
            if (world == null || !world.IsCreated)
            {
                TrafficUtils.Mod.ResetLog?.Warn("Reset requested but the game world is not ready.");
                return;
            }

            if (!Setting.ResetIsInGame())
            {
                TrafficUtils.Mod.ResetLog?.Warn("Reset requested outside an active city.");
                return;
            }

            Setting settings = TrafficUtils.Mod.Instance?.Settings;
            if (settings != null && !settings.HasAnythingSelected())
            {
                TrafficUtils.Mod.ResetLog?.Warn("Reset requested but no vehicle or pedestrian types are enabled.");
                return;
            }

            ResetTrafficSystem system = world.GetOrCreateSystemManaged<ResetTrafficSystem>();
            if (system.m_Requested)
            {
                // Do not restart or expand the snapshot while a run is in progress.
                DebugLog($"RequestReset ignored: already running (index={system.m_SnapshotIndex}/{system.SnapshotLength}, tagged={system.m_SessionCount}, snapshotReady={system.m_SnapshotReady}).");
                return;
            }

            system.m_Requested = true;
            system.m_SnapshotReady = false;
            system.m_SnapshotIndex = 0;
            system.m_LoggedWait = false;
            system.m_SessionCount = 0;
            system.m_LastLoggedCount = 0;
            system.m_LastProcessedFrame = -1;
            if (system.m_Snapshot.IsCreated)
            {
                system.m_Snapshot.Clear();
            }

            if (system.m_Tagged.IsCreated)
            {
                system.m_Tagged.Clear();
            }

            IsActive = true;
            PublishState(TryLocalize(StatusQueuedId, "Queued. Close Options, then set speed to 1."), 0, 0, 0);
            TrafficUtils.Mod.ResetLog?.Info("Reset queued. Close Options, then set game speed to 1.");
            DebugLog($"RequestReset accepted. types={DescribeTypes(settings)} perFrame={settings?.ClampedVehiclesPerFrame()} interval={settings?.ClampedFrameInterval()}");
        }

        private int SnapshotLength => m_Snapshot.IsCreated ? m_Snapshot.Length : 0;

        protected override void OnCreate()
        {
            base.OnCreate();
            m_Barrier = World.GetOrCreateSystemManaged<ToolOutputBarrier>();
            // 4096 is a starting capacity only; both collections grow. Persistent: disposed in OnDestroy.
            m_Snapshot = new NativeList<Entity>(4096, Allocator.Persistent);
            m_Tagged = new NativeHashSet<Entity>(4096, Allocator.Persistent);
            // Deleted = already going away. Temp = preview/ghost. Unspawned = spawn-pending
            // (tagging those keeps them in a bounce loop). InterpolatedTransform ≈ currently moving.
            ComponentType deleted = ComponentType.ReadOnly<Deleted>();
            ComponentType temp = ComponentType.ReadOnly<Temp>();
            ComponentType unspawned = ComponentType.ReadOnly<Unspawned>();
            ComponentType interpolated = ComponentType.ReadOnly<InterpolatedTransform>();

            m_MovingCars = GetEntityQuery(new EntityQueryDesc
            {
                All = new[] { ComponentType.ReadOnly<PersonalCar>(), interpolated },
                None = new[] { deleted, temp, unspawned, ComponentType.ReadOnly<ParkedCar>() },
            });
            m_MovingBicycles = GetEntityQuery(new EntityQueryDesc
            {
                All = new[] { ComponentType.ReadOnly<Bicycle>(), interpolated },
                None = new[] { deleted, temp, unspawned },
            });
            m_MovingTrains = GetEntityQuery(new EntityQueryDesc
            {
                All = new[] { ComponentType.ReadOnly<Train>(), interpolated },
                None = new[] { deleted, temp, unspawned, ComponentType.ReadOnly<ParkedTrain>() },
            });
            // Trains have their own toggle; exclude them here so PT does not double-count.
            m_MovingPublicTransport = GetEntityQuery(new EntityQueryDesc
            {
                All = new[] { interpolated },
                Any = new[] { ComponentType.ReadOnly<PublicTransport>(), ComponentType.ReadOnly<Taxi>(), ComponentType.ReadOnly<PassengerTransport>() },
                None = new[] { deleted, temp, unspawned, ComponentType.ReadOnly<Train>() },
            });
            m_MovingTrucks = GetEntityQuery(new EntityQueryDesc
            {
                All = new[] { interpolated },
                Any = new[]
                {
                    ComponentType.ReadOnly<DeliveryTruck>(),
                    ComponentType.ReadOnly<GarbageTruck>(),
                    ComponentType.ReadOnly<FireEngine>(),
                    ComponentType.ReadOnly<PoliceCar>(),
                    ComponentType.ReadOnly<PostVan>(),
                    ComponentType.ReadOnly<Ambulance>(),
                    ComponentType.ReadOnly<Hearse>(),
                    ComponentType.ReadOnly<MaintenanceVehicle>(),
                    ComponentType.ReadOnly<CargoTransport>(),
                },
                None = new[] { deleted, temp, unspawned },
            });
            m_MovingOther = GetEntityQuery(new EntityQueryDesc
            {
                All = new[] { interpolated },
                Any = new[]
                {
                    ComponentType.ReadOnly<Aircraft>(),
                    ComponentType.ReadOnly<Watercraft>(),
                    ComponentType.ReadOnly<Helicopter>(),
                },
                None = new[] { deleted, temp, unspawned },
            });
            // Skip cims already seated in a vehicle; those follow the vehicle entity.
            m_Pedestrians = GetEntityQuery(new EntityQueryDesc
            {
                All = new[] { ComponentType.ReadOnly<Human>(), interpolated },
                None = new[] { deleted, temp, unspawned, ComponentType.ReadOnly<CurrentVehicle>() },
            });
            // Includes curb, garage, and depot/service fleets — not street parking only.
            m_ParkedCars = GetEntityQuery(new EntityQueryDesc
            {
                All = new[] { ComponentType.ReadOnly<ParkedCar>() },
                None = new[] { deleted, temp, unspawned },
            });
            // Parked bikes have no InterpolatedTransform (moving bikes do).
            m_ParkedBicycles = GetEntityQuery(new EntityQueryDesc
            {
                All = new[] { ComponentType.ReadOnly<Bicycle>() },
                None = new[] { deleted, temp, unspawned, interpolated },
            });
            m_ParkedTrains = GetEntityQuery(new EntityQueryDesc
            {
                All = new[] { ComponentType.ReadOnly<ParkedTrain>() },
                None = new[] { deleted, temp, unspawned },
            });
            // Stationary vehicles that are not parked cars/trains/bikes (boats at docks, planes at gates, …).
            m_ParkedOther = GetEntityQuery(new EntityQueryDesc
            {
                All = new[] { ComponentType.ReadOnly<Vehicle>() },
                None = new[]
                {
                    deleted,
                    temp,
                    unspawned,
                    interpolated,
                    ComponentType.ReadOnly<ParkedCar>(),
                    ComponentType.ReadOnly<ParkedTrain>(),
                    ComponentType.ReadOnly<Bicycle>(),
                },
            });
        }

        protected override void OnDestroy()
        {
            // Do not Finish() here: leaving the city is not a completed run.
            m_Disposing = true;
            // Persistent collections must be disposed with the system.
            if (m_Snapshot.IsCreated)
            {
                m_Snapshot.Dispose();
            }

            if (m_Tagged.IsCreated)
            {
                m_Tagged.Dispose();
            }

            IsActive = false;
            // Counts belong to the city being unloaded. Clear them so the next city starts Idle
            // instead of showing the previous session's result.
            PublishState(null, 0, 0, 0);
            base.OnDestroy();
        }

        protected override void OnUpdate()
        {
            PollHotkey();

            if (!m_Requested)
            {
                return;
            }

            // IsGame() is false in Options and on the main menu. Pause; do not Finish.
            // Leaving the city still clears via OnDestroy when the world is disposed.
            if (!Setting.ResetIsInGame())
            {
                DebugLogThrottled("OnUpdate wait: menu/Options open; in-flight reset paused (not cancelled).");
                return;
            }

            SimulationSystem simulation = World.GetExistingSystemManaged<SimulationSystem>();
            float speed = simulation != null ? simulation.selectedSpeed : -1f;
            // selectedSpeed 0 = paused. Deleting while paused is unsafe; wait for speed > 0.
            if (simulation == null || speed <= 0f)
            {
                if (!m_LoggedWait)
                {
                    m_LoggedWait = true;
                    PublishState(TryLocalize(StatusWaitingId, "Waiting for speed 1."), RemainingCount, SnapshotTotal, RemovedCount);
                    TrafficUtils.Mod.ResetLog?.Info("Waiting for game speed > 0. Close Options and unpause to start.");
                }

                DebugLogThrottled($"OnUpdate wait: selectedSpeed={speed} requested={m_Requested} snapshotReady={m_SnapshotReady} index={m_SnapshotIndex}/{SnapshotLength} IsActive={IsActive}");
                return;
            }

            Setting settings = TrafficUtils.Mod.Instance?.Settings;
            if (settings == null || !settings.HasAnythingSelected())
            {
                DebugLog("OnUpdate abort: no types enabled.");
                Finish(
                    "Skipped vehicle reset: no types enabled.",
                    TryLocalize(StatusNoTypesId, "Skipped: no types are checked."),
                    warn: true);
                return;
            }

            if (!m_SnapshotReady)
            {
                // Wait for in-flight jobs so ToEntityArray is a consistent view.
                EntityManager.CompleteAllTrackedJobs();
                BuildSnapshot(settings);
                m_SnapshotReady = true;
                if (m_Snapshot.Length == 0)
                {
                    DebugLog("Snapshot empty after BuildSnapshot.");
                    Finish(
                        "Reset complete: nothing matched the checked types.",
                        TryLocalize(StatusNothingMatchedId, "Reset complete: nothing matched the checked types."));
                    return;
                }

                PublishState(
                    Localize(StatusSnapshotReadyId, "Snapshot {SNAPSHOT}. Removing listed entities only.", m_Snapshot.Length, m_Snapshot.Length, 0),
                    m_Snapshot.Length,
                    m_Snapshot.Length,
                    0);
                TrafficUtils.Mod.ResetLog?.Info($"Snapshot {m_Snapshot.Length} entities. Vehicles that spawn after this are left alone.");
                DebugLog($"Snapshot ready length={m_Snapshot.Length} IsActive={IsActive} UiVersion={UiVersion}");
            }

            int perFrame = settings.ClampedVehiclesPerFrame();
            int interval = settings.ClampedFrameInterval();
            // Unity render frames, not simulation ticks (those stall at speed 0).
            int frame = UnityEngine.Time.frameCount;
            if (m_LastProcessedFrame >= 0 && frame < m_LastProcessedFrame + 1 + interval)
            {
                DebugLogThrottled($"OnUpdate skip interval: frame={frame} last={m_LastProcessedFrame} interval={interval} index={m_SnapshotIndex}/{SnapshotLength}");
                return;
            }

            m_LastProcessedFrame = frame;
            // Jobs may have despawned snapshot entities since the last batch; sync before Exists checks.
            EntityManager.CompleteAllTrackedJobs();

            m_DebugSkipNull = 0;
            m_DebugSkipMissing = 0;
            m_DebugSkipDeleted = 0;
            EntityCommandBuffer commandBuffer = m_Barrier.CreateCommandBuffer();
            int tagged = TagSnapshotBatch(commandBuffer, perFrame, settings.ResetEnableDebugging);
            m_SessionCount += tagged;
            int stillLeft = m_Snapshot.Length - m_SnapshotIndex;
            PublishState(
                Localize(StatusProgressId, "Running: {REMOVED} removed, {REMAINING} left.", stillLeft, m_Snapshot.Length, m_SessionCount),
                stillLeft,
                m_Snapshot.Length,
                m_SessionCount);
            DebugLog($"batch frame={frame} speed={speed} tagged={tagged} session={m_SessionCount} index={m_SnapshotIndex}/{m_Snapshot.Length} left={stillLeft} skipNull={m_DebugSkipNull} skipMissing={m_DebugSkipMissing} skipDeleted={m_DebugSkipDeleted} IsActive={IsActive} UiVersion={UiVersion}");

            if (stillLeft <= 0)
            {
                DebugLog($"Finish condition met. taggedThisSession={m_SessionCount} snapshotLength={m_Snapshot.Length}");
                Finish(
                    $"Reset complete: {m_SessionCount} entities.",
                    Localize(StatusCompleteId, "Reset complete: {REMOVED} entities.", 0, m_Snapshot.Length, m_SessionCount));
                return;
            }

            if (m_SessionCount == tagged || m_SessionCount - m_LastLoggedCount >= LogEvery)
            {
                m_LastLoggedCount = m_SessionCount;
                TrafficUtils.Mod.ResetLog?.Info($"Reset progress: {m_SessionCount} entities tagged, {stillLeft} remaining in snapshot.");
            }
        }

        private void BuildSnapshot(Setting settings)
        {
            m_Snapshot.Clear();
            m_SnapshotIndex = 0;
            // Queries overlap (e.g. a bus is PT and a truck-like vehicle). Keep each entity once.
            NativeHashSet<Entity> seen = new NativeHashSet<Entity>(4096, Allocator.Temp);
            try
            {
                AppendQuery("MovingCars", settings.RemoveMovingCars, m_MovingCars, seen);
                AppendQuery("MovingBicycles", settings.RemoveMovingBicycles, m_MovingBicycles, seen);
                AppendQuery("MovingTrains", settings.RemoveMovingTrains, m_MovingTrains, seen);
                AppendQuery("MovingPublicTransport", settings.RemoveMovingPublicTransport, m_MovingPublicTransport, seen);
                AppendQuery("MovingTrucks", settings.RemoveMovingTrucks, m_MovingTrucks, seen);
                AppendQuery("MovingOther", settings.RemoveMovingOther, m_MovingOther, seen);
                AppendQuery("Pedestrians", settings.RemovePedestrians, m_Pedestrians, seen);
                AppendQuery("ParkedCars", settings.RemoveParkedCars, m_ParkedCars, seen);
                AppendQuery("ParkedBicycles", settings.RemoveParkedBicycles, m_ParkedBicycles, seen);
                AppendQuery("ParkedTrains", settings.RemoveParkedTrains, m_ParkedTrains, seen);
                AppendQuery("ParkedOther", settings.RemoveParkedOther, m_ParkedOther, seen);
            }
            finally
            {
                seen.Dispose();
            }

            DebugLog($"BuildSnapshot total={m_Snapshot.Length}");
        }

        private void AppendQuery(string name, bool enabled, EntityQuery query, NativeHashSet<Entity> seen)
        {
            if (!enabled)
            {
                DebugLog($"query {name} skipped (unchecked)");
                return;
            }

            NativeArray<Entity> entities = query.ToEntityArray(Allocator.Temp);
            int added = 0;
            int dupes = 0;
            try
            {
                for (int i = 0; i < entities.Length; i++)
                {
                    Entity entity = entities[i];
                    if (entity == Entity.Null || !seen.Add(entity))
                    {
                        dupes++;
                        continue;
                    }

                    m_Snapshot.Add(entity);
                    added++;
                }
            }
            finally
            {
                entities.Dispose();
            }

            DebugLog($"query {name} live={query.CalculateEntityCount()} added={added} dupesOrNull={dupes}");
        }

        // Tag up to `budget` still-existing snapshot entities. Always advance the index so
        // already-gone entities still count down Remaining to 0. The budget counts snapshot rows;
        // the return value counts entities actually tagged, which includes layout extras.
        private int TagSnapshotBatch(EntityCommandBuffer commandBuffer, int budget, bool debugging)
        {
            int processed = 0;
            int tagged = 0;
            while (m_SnapshotIndex < m_Snapshot.Length && processed < budget)
            {
                int index = m_SnapshotIndex;
                // Advance even when skipping so Remaining can reach 0 (gone/already Deleted).
                Entity entity = m_Snapshot[m_SnapshotIndex++];
                if (entity == Entity.Null)
                {
                    m_DebugSkipNull++;
                    if (debugging)
                    {
                        DebugLog($"skip[{index}] Entity.Null");
                    }

                    continue;
                }

                if (!EntityManager.Exists(entity))
                {
                    m_DebugSkipMissing++;
                    if (debugging)
                    {
                        DebugLog($"skip[{index}] missing {FormatEntity(entity)}");
                    }

                    continue;
                }

                if (EntityManager.HasComponent<Deleted>(entity))
                {
                    m_DebugSkipDeleted++;
                    if (debugging)
                    {
                        DebugLog($"skip[{index}] already Deleted {FormatEntity(entity)}");
                    }

                    continue;
                }

                int justTagged = TagDeleted(commandBuffer, entity, debugging);
                if (justTagged == 0)
                {
                    // Already tagged earlier in this run as another vehicle's layout extra.
                    m_DebugSkipDeleted++;
                    if (debugging)
                    {
                        DebugLog($"skip[{index}] already tagged this run {FormatEntity(entity)}");
                    }

                    continue;
                }

                tagged += justTagged;
                processed++;
                if (debugging)
                {
                    DebugLog($"tag[{index}] {FormatEntity(entity)} taggedThisBatch={processed}/{budget} entities={tagged}");
                }
            }

            return tagged;
        }

        // Clears the run flags but keeps the last counts for Options until the next RequestReset.
        // The log line stays English for supportability; only uiMessage goes through the active dictionary.
        private void Finish(string logMessage, string uiMessage, bool warn = false)
        {
            DebugLog($"Finish begin: '{logMessage}' requested={m_Requested} snapshotReady={m_SnapshotReady} index={m_SnapshotIndex}/{SnapshotLength} session={m_SessionCount} IsActive={IsActive}");
            if (warn)
            {
                TrafficUtils.Mod.ResetLog?.Warn(logMessage);
            }
            else
            {
                TrafficUtils.Mod.ResetLog?.Info(logMessage);
            }

            int removed = m_SessionCount;
            int snapshot = SnapshotLength;
            m_Requested = false;
            m_SnapshotReady = false;
            m_SnapshotIndex = 0;
            m_SessionCount = 0;
            m_LastLoggedCount = 0;
            if (m_Snapshot.IsCreated)
            {
                m_Snapshot.Clear();
            }

            if (m_Tagged.IsCreated)
            {
                m_Tagged.Clear();
            }

            IsActive = false;
            PublishState(uiMessage, 0, snapshot, removed);
            ShowCompletionPopup(uiMessage, 0, snapshot, removed);
            DebugLog($"Finish end: IsActive={IsActive} UiVersion={UiVersion} status='{FormatStatus()}'");
        }

        // Official CS2 modal (Game.UI.MessageDialog). Not the error HUD — SetShowsErrorsInUI stays false.
        private void ShowCompletionPopup(string message, int remaining, int snapshot, int removed)
        {
            if (m_Disposing)
            {
                DebugLog("Finish popup skipped: disposing.");
                return;
            }

            GameManager gameManager = GameManager.instance;
            AppBindings appBindings = gameManager?.userInterface?.appBindings;
            if (appBindings == null)
            {
                DebugLog("Finish popup skipped: UI not ready.");
                return;
            }

            string counts = FormatCounts(remaining, snapshot, removed);
            string body = string.IsNullOrEmpty(message) ? counts : message + "\n" + counts;

            try
            {
                MessageDialog dialog = new MessageDialog(
                    LocalizedString.IdWithFallback(FinishDialogTitleId, "Reset Traffic"),
                    LocalizedString.Value(body),
                    LocalizedString.IdWithFallback(FinishDialogOkId, "OK"));
                appBindings.ShowMessageDialog(dialog, _ => { });
            }
            catch (Exception exception)
            {
                TrafficUtils.Mod.ResetLog?.Warn("Finish popup failed: " + exception.Message);
            }
        }

        private static string TryLocalize(string id, string fallback)
        {
            GameManager gameManager = GameManager.instance;
            if (gameManager?.localizationManager?.activeDictionary != null
                && gameManager.localizationManager.activeDictionary.TryGetValue(id, out string value)
                && !string.IsNullOrEmpty(value))
            {
                return value;
            }

            return fallback;
        }

        // The counts tail shared by the Status line and the finish dialog body.
        private static string FormatCounts(int remaining, int snapshot, int removed)
        {
            return Localize(
                FinishDialogCountsId,
                "Remaining {REMAINING}  ·  Removed {REMOVED}  ·  Snapshot {SNAPSHOT}",
                remaining,
                snapshot,
                removed);
        }

        // Headline strings that carry counts. Placeholders are the same three the locale files use.
        private static string Localize(string id, string fallback, int remaining, int snapshot, int removed)
        {
            return TryLocalize(id, fallback)
                .Replace("{REMAINING}", remaining.ToString())
                .Replace("{REMOVED}", removed.ToString())
                .Replace("{SNAPSHOT}", snapshot.ToString());
        }

        // Static so Options can read progress without a system instance. BumpUi invalidates dummy rows.
        private static void PublishState(string text, int remaining, int snapshot, int removed)
        {
            StatusHeadline = text;
            RemainingCount = remaining;
            SnapshotTotal = snapshot;
            RemovedCount = removed;
            BumpUi();
        }

        private static void BumpUi()
        {
            UiVersion++;
        }

        private void PollHotkey()
        {
            Setting settings = TrafficUtils.Mod.Instance?.Settings;
            if (settings == null)
            {
                return;
            }

            ProxyAction action = settings.GetAction(nameof(Setting.ResetHotkey));
            if (action == null)
            {
                // Binding is not registered with InputManager, so the hotkey cannot fire.
                if (settings.ResetEnableDebugging && !m_LoggedNullHotkey)
                {
                    m_LoggedNullHotkey = true;
                    DebugLog("GetAction(ResetHotkey) returned null. Hotkey will not fire.");
                }

                return;
            }

            // InputManager only delivers the action while enabled; keep it off in menus/Options.
            action.shouldBeEnabled = Setting.ResetIsInGame();
            bool performed = action.WasPerformedThisFrame();
            if (settings.ResetEnableDebugging && performed)
            {
                DebugLog($"hotkey performed shouldBeEnabled={action.shouldBeEnabled} inGame={Setting.ResetIsInGame()} alreadyRunning={IsActive}");
            }

            if (performed && Setting.ResetIsInGame())
            {
                RequestReset();
            }
        }

        // Returns how many entities were newly tagged (the vehicle plus its extra slots) so Removed
        // reports actual despawns rather than snapshot rows. 0 means nothing was left to do.
        private int TagDeleted(EntityCommandBuffer commandBuffer, Entity entity, bool debugging)
        {
            int tagged = TryTag(commandBuffer, entity) ? 1 : 0;

            if (!EntityManager.HasBuffer<LayoutElement>(entity))
            {
                return tagged;
            }

            // Extra slots on the same vehicle (articulated buses, train cars, trailers).
            DynamicBuffer<LayoutElement> layout = EntityManager.GetBuffer<LayoutElement>(entity, true);
            int extras = 0;
            for (int i = 0; i < layout.Length; i++)
            {
                Entity extra = layout[i].m_Vehicle;
                if (extra == entity || !TryTag(commandBuffer, extra))
                {
                    continue;
                }

                extras++;
                if (debugging)
                {
                    DebugLog($"  layout extra {FormatEntity(extra)} of {FormatEntity(entity)}");
                }
            }

            if (debugging && extras > 0)
            {
                DebugLog($"  layout extras tagged={extras} for {FormatEntity(entity)}");
            }

            return tagged + extras;
        }

        // False when the entity is gone, already Deleted, or was tagged earlier in this run.
        private bool TryTag(EntityCommandBuffer commandBuffer, Entity entity)
        {
            if (entity == Entity.Null
                || !EntityManager.Exists(entity)
                || EntityManager.HasComponent<Deleted>(entity)
                || !m_Tagged.Add(entity))
            {
                return false;
            }

            // Deferred Deleted via the tool barrier — not EntityManager.AddComponent this frame.
            commandBuffer.AddComponent<Deleted>(entity);
            return true;
        }

        private static string FormatEntity(Entity entity)
        {
            return $"Index={entity.Index} Version={entity.Version}";
        }

        // Compact type dump for debug logs — not shown in Options.
        private static string DescribeTypes(Setting settings)
        {
            if (settings == null)
            {
                return "settings=null";
            }

            return "cars=" + settings.RemoveMovingCars
                + " bikes=" + settings.RemoveMovingBicycles
                + " trains=" + settings.RemoveMovingTrains
                + " pt=" + settings.RemoveMovingPublicTransport
                + " trucks=" + settings.RemoveMovingTrucks
                + " other=" + settings.RemoveMovingOther
                + " peds=" + settings.RemovePedestrians
                + " parkedCars=" + settings.RemoveParkedCars
                + " parkedBikes=" + settings.RemoveParkedBicycles
                + " parkedTrains=" + settings.RemoveParkedTrains
                + " parkedOther=" + settings.RemoveParkedOther;
        }

        private static void DebugLog(string message)
        {
            Setting settings = TrafficUtils.Mod.Instance?.Settings;
            if (settings == null || !settings.ResetEnableDebugging)
            {
                return;
            }

            TrafficUtils.Mod.ResetLog?.Info("[DEBUG] " + message);
        }

        private void DebugLogThrottled(string message)
        {
            // Wait loops run every frame; cap debug spam at about once per second.
            int frame = UnityEngine.Time.frameCount;
            if (m_LastWaitLogFrame >= 0 && frame - m_LastWaitLogFrame < 60)
            {
                return;
            }

            m_LastWaitLogFrame = frame;
            DebugLog(message);
        }
    }
}
