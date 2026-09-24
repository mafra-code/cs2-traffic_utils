namespace AccidentsBeGone
{
    using Setting = TrafficUtils.Setting;
    using Colossal.Serialization.Entities;
    using Game;
    using Game.Common;
    using Game.Events;
    using Game.SceneFlow;
    using Game.Notifications;
    using Game.Prefabs;
    using Game.Simulation;
    using Game.Tools;
    using Unity.Collections;
    using Unity.Entities;

    /// <summary>
    /// Writes <see cref="TrafficAccidentData.m_OccurenceProbability"/> to 0 every
    /// <see cref="SystemUpdatePhase.ModificationEnd"/>, including locked prefabs, and can
    /// remove traffic-accident sites already on the roads.
    /// </summary>
    /// <remarks>
    /// Runs before <see cref="ModificationEndBarrier"/> and before GameSimulation, so
    /// <c>RoadSafetySystem</c> rolls a zero chance the same frame. The authoring field
    /// <c>TrafficAccident.m_OccurrenceProbability</c> is left alone while prevention is on;
    /// turning prevention off copies that field back once.
    /// Accident sites live on road entities. Those entities are not deleted. The event
    /// entity is. Involved vehicles lose <see cref="InvolvedInAccident"/> and stay in the city.
    /// Crime scenes (an <see cref="AccidentSite"/> without <see cref="AccidentSiteFlags.TrafficAccident"/>)
    /// are left in place. This system does not reference Disable Accidents.
    /// </remarks>
    [UpdateBefore(typeof(ModificationEndBarrier))]
    public partial class AccidentsBeGoneSystem : GameSystemBase
    {
        private const float VanillaFallback = 0.01f;

        internal const string StatusIdleId = "AccidentsBeGone.Status.Idle";
        internal const string StatusClearedId = "AccidentsBeGone.Status.Cleared";

        private PrefabSystem m_PrefabSystem;
        private ModificationEndBarrier m_Barrier;
        private SimulationSystem m_SimulationSystem;
        private IconCommandSystem m_IconCommands;
        private NativeHashSet<Entity> m_Seen;
        private uint m_StartFrame;
        private bool m_HasStartFrame;
        private EntityQuery m_Prefabs;
        private EntityQuery m_Events;
        private EntityQuery m_Sites;
        private EntityQuery m_Involved;
        private EntityQuery m_Pending;
        private EntityQuery m_AccidentIcons;
        private EntityQuery m_PoliceConfig;
        private IconCommandBuffer m_IconBuffer;
        private bool m_HasIconBuffer;
        private int m_IconsQueued;
        private bool m_ClearRequested;
        private bool m_HoldingZero;
        private bool m_LoggedRewrite;
        private int m_TicksUntilRun;

        internal static int LastEvents { get; private set; }

        internal static int LastSites { get; private set; }

        internal static int LastReleased { get; private set; }

        internal static bool HasCleared { get; private set; }

        internal static int UiVersion { get; private set; }

        protected override void OnCreate()
        {
            base.OnCreate();
            m_PrefabSystem = World.GetOrCreateSystemManaged<PrefabSystem>();
            m_Barrier = World.GetOrCreateSystemManaged<ModificationEndBarrier>();
            m_SimulationSystem = World.GetOrCreateSystemManaged<SimulationSystem>();
            m_IconCommands = World.GetOrCreateSystemManaged<IconCommandSystem>();
            m_Seen = new NativeHashSet<Entity>(64, Allocator.Persistent);
            m_Prefabs = GetEntityQuery(ComponentType.ReadWrite<TrafficAccidentData>());
            m_Events = GetEntityQuery(
                ComponentType.ReadOnly<Game.Events.TrafficAccident>(),
                ComponentType.Exclude<Deleted>(),
                ComponentType.Exclude<Temp>());
            m_Sites = GetEntityQuery(
                ComponentType.ReadOnly<AccidentSite>(),
                ComponentType.Exclude<Deleted>(),
                ComponentType.Exclude<Temp>());
            m_Involved = GetEntityQuery(
                ComponentType.ReadOnly<InvolvedInAccident>(),
                ComponentType.Exclude<Deleted>(),
                ComponentType.Exclude<Temp>());
            m_Pending = GetEntityQuery(
                ComponentType.ReadOnly<AddAccidentSite>(),
                ComponentType.Exclude<Deleted>(),
                ComponentType.Exclude<Temp>());
            m_AccidentIcons = GetEntityQuery(
                ComponentType.ReadOnly<Icon>(),
                ComponentType.ReadOnly<PrefabRef>(),
                ComponentType.ReadOnly<Owner>(),
                ComponentType.Exclude<Deleted>(),
                ComponentType.Exclude<Temp>());
            m_PoliceConfig = GetEntityQuery(ComponentType.ReadOnly<PoliceConfigurationData>());
        }

        /// <summary>
        /// Queue one clear. Shared by the Options button, city load, and the enable toggle.
        /// Safe to call before the system's first update.
        /// </summary>
        public static void RequestClear()
        {
            World world = World.DefaultGameObjectInjectionWorld;
            if (world == null || !world.IsCreated)
            {
                TrafficUtils.Mod.AccidentLog?.Warn("Clear requested but the game world is not ready.");
                return;
            }

            world.GetOrCreateSystemManaged<AccidentsBeGoneSystem>().m_ClearRequested = true;
            if (!Setting.AccidentIsInGame())
            {
                TrafficUtils.Mod.AccidentLog?.Info("Clear queued until a city is active.");
            }
        }

        protected override void OnGameLoadingComplete(Purpose purpose, GameMode mode)
        {
            base.OnGameLoadingComplete(purpose, mode);
            InvolvedStats.ResetNow();
            if (m_Seen.IsCreated)
            {
                m_Seen.Clear();
            }

            m_HasStartFrame = false;
            m_TicksUntilRun = 0;
            Setting settings = TrafficUtils.Mod.Instance?.Settings;
            if (settings != null && settings.AccidentEnabled && settings.ClearOnLoad)
            {
                m_ClearRequested = true;
            }
        }

        protected override void OnDestroy()
        {
            if (m_Seen.IsCreated)
            {
                m_Seen.Dispose();
            }

            base.OnDestroy();
        }

        protected override void OnUpdate()
        {
            Setting settings = TrafficUtils.Mod.Instance?.Settings;
            int interval = settings != null ? settings.ClampedUpdateInterval() : Setting.DefaultUpdateInterval;
            if (m_TicksUntilRun > 0)
            {
                m_TicksUntilRun--;
                return;
            }

            m_TicksUntilRun = interval - 1;
            m_HasIconBuffer = false;
            m_IconsQueued = 0;
            bool enabled = settings != null && settings.AccidentEnabled;
            ApplyProbabilities(enabled);
            if (!Setting.AccidentIsInGame())
            {
                return;
            }

            RecordInvolvements();
            if (m_ClearRequested)
            {
                m_ClearRequested = false;
                Clear();
            }

            HideOrphanAccidentIcons();
            FlushIconCommands();
        }

        private void ApplyProbabilities(bool enabled)
        {
            if (enabled)
            {
                int changed = WriteProbabilities(zero: true);
                if (changed > 0)
                {
                    if (!m_LoggedRewrite)
                    {
                        TrafficUtils.Mod.AccidentLog?.Info($"Accident chance held at 0 ({changed} prefab{(changed == 1 ? string.Empty : "s")} updated).");
                        m_LoggedRewrite = true;
                    }
                    else if (TrafficUtils.Mod.Instance?.Settings?.AccidentEnableDebugging == true)
                    {
                        TrafficUtils.Mod.AccidentLog.Info($"[DEBUG] Accident chance was overwritten; set back to 0 on {changed} prefab{(changed == 1 ? string.Empty : "s")}.");
                    }
                }
                else
                {
                    if (!m_HoldingZero)
                    {
                        TrafficUtils.Mod.AccidentLog?.Info("Accident chance already 0.");
                    }

                    m_LoggedRewrite = false;
                }

                m_HoldingZero = true;
                return;
            }

            if (!m_HoldingZero)
            {
                return;
            }

            int restored = WriteProbabilities(zero: false);
            m_HoldingZero = false;
            TrafficUtils.Mod.AccidentLog?.Info($"Accident chance restored on {restored} prefab{(restored == 1 ? string.Empty : "s")}.");
        }

        private int WriteProbabilities(bool zero)
        {
            int changed = 0;
            using NativeArray<Entity> prefabs = m_Prefabs.ToEntityArray(Allocator.Temp);
            for (int i = 0; i < prefabs.Length; i++)
            {
                Entity entity = prefabs[i];
                TrafficAccidentData data = EntityManager.GetComponentData<TrafficAccidentData>(entity);
                float target = zero ? 0f : ReadAuthoringProbability(entity);
                if (data.m_OccurenceProbability == target)
                {
                    continue;
                }

                float previous = data.m_OccurenceProbability;
                data.m_OccurenceProbability = target;
                EntityManager.SetComponentData(entity, data);
                changed++;
                if (TrafficUtils.Mod.Instance?.Settings?.AccidentEnableDebugging == true)
                {
                    TrafficUtils.Mod.AccidentLog.Info($"[DEBUG] Prefab {entity.Index} chance {previous} -> {target}.");
                }
            }

            return changed;
        }

        private float ReadAuthoringProbability(Entity entity)
        {
            if (m_PrefabSystem.TryGetPrefab(entity, out PrefabBase prefab)
                && prefab.TryGet(out Game.Prefabs.TrafficAccident accident))
            {
                return accident.m_OccurrenceProbability;
            }

            return VanillaFallback;
        }

        private void Clear()
        {
            EntityCommandBuffer commandBuffer = m_Barrier.CreateCommandBuffer();
            int events = 0;
            int sites = 0;
            int released = 0;
            int pending = 0;

            using NativeArray<Entity> eventEntities = m_Events.ToEntityArray(Allocator.Temp);
            using NativeHashSet<Entity> eventSet = new NativeHashSet<Entity>(eventEntities.Length, Allocator.Temp);
            for (int i = 0; i < eventEntities.Length; i++)
            {
                Entity entity = eventEntities[i];
                if (!eventSet.Add(entity))
                {
                    continue;
                }

                commandBuffer.AddComponent<Deleted>(entity);
                events++;
            }

            using NativeArray<Entity> siteEntities = m_Sites.ToEntityArray(Allocator.Temp);
            for (int i = 0; i < siteEntities.Length; i++)
            {
                Entity entity = siteEntities[i];
                AccidentSite site = EntityManager.GetComponentData<AccidentSite>(entity);
                if ((site.m_Flags & AccidentSiteFlags.TrafficAccident) == 0)
                {
                    continue;
                }

                if (eventSet.Contains(entity))
                {
                    continue;
                }

                commandBuffer.RemoveComponent<AccidentSite>(entity);
                sites++;
            }

            using NativeArray<Entity> involvedEntities = m_Involved.ToEntityArray(Allocator.Temp);
            for (int i = 0; i < involvedEntities.Length; i++)
            {
                Entity entity = involvedEntities[i];
                InvolvedInAccident involved = EntityManager.GetComponentData<InvolvedInAccident>(entity);
                if (!eventSet.Contains(involved.m_Event))
                {
                    continue;
                }

                commandBuffer.RemoveComponent<InvolvedInAccident>(entity);
                QueueAccidentIconRemoval(entity);
                released++;
            }

            using NativeArray<Entity> pendingEntities = m_Pending.ToEntityArray(Allocator.Temp);
            for (int i = 0; i < pendingEntities.Length; i++)
            {
                Entity entity = pendingEntities[i];
                AddAccidentSite add = EntityManager.GetComponentData<AddAccidentSite>(entity);
                if ((add.m_Flags & AccidentSiteFlags.TrafficAccident) == 0 || eventSet.Contains(entity))
                {
                    continue;
                }

                commandBuffer.RemoveComponent<AddAccidentSite>(entity);
                pending++;
            }

            LastEvents = events;
            LastSites = sites;
            LastReleased = released;
            HasCleared = true;
            UiVersion++;
            TrafficUtils.Mod.AccidentLog?.Info($"Cleared traffic accidents: events={events}, sites={sites}, vehicles released={released}, pending={pending}.");
        }

        // The map icon is the traffic-accident notification on the involved object, not the
        // counter. Drop it when that object no longer has InvolvedInAccident. Leave it while
        // the object still does, so a real accident keeps its icon. Crime-scene icons use
        // another prefab and are not touched.
        private void HideOrphanAccidentIcons()
        {
            Entity notification = TrafficAccidentNotification();
            if (notification == Entity.Null || m_AccidentIcons.IsEmptyIgnoreFilter)
            {
                return;
            }

            using NativeArray<Entity> icons = m_AccidentIcons.ToEntityArray(Allocator.Temp);
            for (int i = 0; i < icons.Length; i++)
            {
                Entity icon = icons[i];
                if (EntityManager.GetComponentData<PrefabRef>(icon).m_Prefab != notification)
                {
                    continue;
                }

                Entity owner = EntityManager.GetComponentData<Owner>(icon).m_Owner;
                if (EntityManager.HasComponent<InvolvedInAccident>(owner))
                {
                    continue;
                }

                QueueAccidentIconRemoval(owner);
            }
        }

        private void QueueAccidentIconRemoval(Entity owner)
        {
            Entity notification = TrafficAccidentNotification();
            if (notification == Entity.Null || owner == Entity.Null)
            {
                return;
            }

            if (!m_HasIconBuffer)
            {
                m_IconBuffer = m_IconCommands.CreateCommandBuffer();
                m_HasIconBuffer = true;
            }

            m_IconBuffer.Remove(owner, notification);
            m_IconsQueued++;
        }

        private void FlushIconCommands()
        {
            if (!m_HasIconBuffer)
            {
                return;
            }

            m_IconCommands.AddCommandBufferWriter(default);
            m_HasIconBuffer = false;
            if (m_IconsQueued > 0)
            {
                TrafficUtils.Mod.AccidentLog?.Info($"Hid {m_IconsQueued} accident icon{(m_IconsQueued == 1 ? string.Empty : "s")} with no involved object.");
            }
        }

        private Entity TrafficAccidentNotification()
        {
            if (m_PoliceConfig.IsEmptyIgnoreFilter)
            {
                return Entity.Null;
            }

            return m_PoliceConfig.GetSingleton<PoliceConfigurationData>().m_TrafficAccidentNotificationPrefab;
        }

        // Counts a new InvolvedInAccident once. Riders are skipped so a passenger is not
        // counted on top of the vehicle. Losing the component lets a later involvement count again.
        private void RecordInvolvements()
        {
            if (!m_Seen.IsCreated)
            {
                return;
            }

            bool stampOnly = InvolvedStats.ConsumePendingReset();
            if (stampOnly)
            {
                m_Seen.Clear();
                m_HasStartFrame = false;
            }

            uint frameIndex = m_SimulationSystem.frameIndex;
            if (!m_HasStartFrame)
            {
                m_StartFrame = frameIndex;
                m_HasStartFrame = true;
            }

            using NativeArray<Entity> involved = m_Involved.ToEntityArray(Allocator.Temp);
            using NativeHashSet<Entity> still = new NativeHashSet<Entity>(involved.Length, Allocator.Temp);
            for (int i = 0; i < involved.Length; i++)
            {
                Entity entity = involved[i];
                still.Add(entity);
                if (!m_Seen.Add(entity))
                {
                    continue;
                }

                if (stampOnly)
                {
                    continue;
                }

                int kind = Classify(entity);
                if (kind >= 0)
                {
                    InvolvedStats.Add(kind);
                }
            }

            using NativeArray<Entity> seen = m_Seen.ToNativeArray(Allocator.Temp);
            for (int i = 0; i < seen.Length; i++)
            {
                if (!still.Contains(seen[i]))
                {
                    m_Seen.Remove(seen[i]);
                }
            }

            InvolvedStats.Publish(ElapsedInGameHours(m_StartFrame, frameIndex));
        }

        private int Classify(Entity entity)
        {
            if (EntityManager.HasComponent<Game.Creatures.Human>(entity))
            {
                return EntityManager.HasComponent<Game.Creatures.CurrentVehicle>(entity) ? -1 : (int)InvolvedKind.Pedestrian;
            }

            if (EntityManager.HasComponent<Game.Vehicles.Train>(entity))
            {
                if (EntityManager.HasComponent<Game.Vehicles.PublicTransport>(entity))
                {
                    return (int)InvolvedKind.PassengerTrain;
                }

                if (EntityManager.HasComponent<Game.Vehicles.CargoTransport>(entity))
                {
                    return (int)InvolvedKind.CargoTrain;
                }

                return (int)InvolvedKind.Train;
            }

            if (EntityManager.HasComponent<Game.Vehicles.Bicycle>(entity))
            {
                return (int)InvolvedKind.Bicycle;
            }

            if (EntityManager.HasComponent<Game.Vehicles.Airplane>(entity))
            {
                return (int)InvolvedKind.Airplane;
            }

            if (EntityManager.HasComponent<Game.Vehicles.Helicopter>(entity))
            {
                return (int)InvolvedKind.Helicopter;
            }

            if (EntityManager.HasComponent<Game.Vehicles.Aircraft>(entity))
            {
                return (int)InvolvedKind.Aircraft;
            }

            if (EntityManager.HasComponent<Game.Vehicles.Watercraft>(entity))
            {
                return (int)InvolvedKind.Watercraft;
            }

            if (EntityManager.HasComponent<Game.Vehicles.PrisonerTransport>(entity))
            {
                return (int)InvolvedKind.PrisonerTransport;
            }

            if (EntityManager.HasComponent<Game.Vehicles.EvacuatingTransport>(entity))
            {
                return (int)InvolvedKind.Evacuation;
            }

            if (EntityManager.HasComponent<Game.Vehicles.Taxi>(entity))
            {
                return (int)InvolvedKind.Taxi;
            }

            if (EntityManager.HasComponent<Game.Vehicles.GarbageTruck>(entity))
            {
                return (int)InvolvedKind.GarbageTruck;
            }

            if (EntityManager.HasComponent<Game.Vehicles.DeliveryTruck>(entity) || EntityManager.HasComponent<Game.Vehicles.GoodsDeliveryVehicle>(entity))
            {
                return (int)InvolvedKind.DeliveryTruck;
            }

            if (EntityManager.HasComponent<Game.Vehicles.FireEngine>(entity))
            {
                return (int)InvolvedKind.FireEngine;
            }

            if (EntityManager.HasComponent<Game.Vehicles.PoliceCar>(entity))
            {
                return (int)InvolvedKind.PoliceCar;
            }

            if (EntityManager.HasComponent<Game.Vehicles.PostVan>(entity))
            {
                return (int)InvolvedKind.PostVan;
            }

            if (EntityManager.HasComponent<Game.Vehicles.Ambulance>(entity))
            {
                return (int)InvolvedKind.Ambulance;
            }

            if (EntityManager.HasComponent<Game.Vehicles.Hearse>(entity))
            {
                return (int)InvolvedKind.Hearse;
            }

            if (EntityManager.HasComponent<Game.Vehicles.RoadMaintenanceVehicle>(entity))
            {
                return (int)InvolvedKind.RoadMaintenance;
            }

            if (EntityManager.HasComponent<Game.Vehicles.ParkMaintenanceVehicle>(entity))
            {
                return (int)InvolvedKind.ParkMaintenance;
            }

            if (EntityManager.HasComponent<Game.Vehicles.MaintenanceVehicle>(entity))
            {
                return (int)InvolvedKind.Maintenance;
            }

            if (EntityManager.HasComponent<Game.Vehicles.CargoTransport>(entity))
            {
                return (int)InvolvedKind.CargoTruck;
            }

            if (EntityManager.HasComponent<Game.Vehicles.PublicTransport>(entity) || EntityManager.HasComponent<Game.Vehicles.PassengerTransport>(entity))
            {
                return (int)InvolvedKind.Transit;
            }

            if (EntityManager.HasComponent<Game.Vehicles.PersonalCar>(entity) || EntityManager.HasComponent<Game.Vehicles.Car>(entity))
            {
                return (int)InvolvedKind.Car;
            }

            return (int)InvolvedKind.Other;
        }

        private static double ElapsedInGameHours(uint startFrame, uint frameIndex)
        {
            if (frameIndex <= startFrame)
            {
                return 0.0;
            }

            return (frameIndex - startFrame) * 24.0 / TimeSystem.kTicksPerDay;
        }

        internal static string FormatStatus()
        {
            if (!HasCleared)
            {
                return TryLocalize(StatusIdleId, "No wrecks cleared this session.");
            }

            string pattern = TryLocalize(
                StatusClearedId,
                "Last clear: {0} events, {1} sites, {2} vehicles released.");
            return string.Format(pattern, LastEvents, LastSites, LastReleased);
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
    }
}
