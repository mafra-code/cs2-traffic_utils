namespace TrafficUtils
{
    using ResetTraffic;
    using Colossal.IO.AssetDatabase;
    using Game;
    using Game.Modding;
    using Game.Settings;
    using Game.Tools;
    using Unity.Entities;

    /// <summary>
    /// Options page: type filters, pace, and a Status line (remaining / removed / snapshot).
    /// <see cref="ResetGetUiVersion"/> forces Options to rebind that line when the system publishes progress.
    /// </summary>
    // Saved as Mods_ResetTraffic.coc under the game's ModsSettings folder.
    public partial class Setting
    {
        
        public const string ResetActionGroup = "Actions";
        public const string ResetFeedbackGroup = "Feedback";
        public const string ResetMovingGroup = "Moving";
        public const string ResetParkedGroup = "Parked";
        public const string ResetPaceGroup = "Pace";
        public const string ResetDebugGroup = "ResetDebug";
        public const string ResetDefaultsGroup = "Defaults";

        // Permanent invite, so it can live in source. Kept here as the single copy of the literal.
        private const string DiscordInviteUrl = "https://discord.gg/84UxmTGZm";

        public const int DefaultVehiclesPerFrame = 20;
        public const int DefaultFrameInterval = 0;
        public const int MinVehiclesPerFrame = 1;
        public const int MaxVehiclesPerFrame = 64;
        public const int MinFrameInterval = 0;
        public const int MaxFrameInterval = 30;

        /// <summary>
        /// Options button. The UI only invokes the setter; the getter is unused.
        /// Disabled on the main menu and while a reset is already running.
        /// </summary>
        [SettingsUISection(TabReset, ResetActionGroup)]
        [SettingsUIButton]
        [SettingsUIConfirmation]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(DisableResetButton))]
        public bool ResetVehicles
        {
            set
            {
                ResetTrafficSystem.RequestReset();
            }
        }

        /// <summary>
        /// Live run status. A plain string (not MultilineText, not disabled) so Options
        /// actually shows the getter value: remaining / removed / snapshot.
        /// </summary>
        [SettingsUISection(TabReset, ResetActionGroup)]
        [SettingsUIWarning(typeof(Setting), nameof(IsRunning))]
        [SettingsUIValueVersion(typeof(Setting), nameof(ResetGetUiVersion))]
        public string ProgressText => ResetTrafficSystem.FormatStatus();

        /// <summary>
        /// Options button. Hands the invite to the OS default browser; the game has no in-client one.
        /// Deliberately without a confirmation dialog - the extra click costs more feedback than it saves,
        /// so the localized description is what warns that a browser window appears.
        /// </summary>
        [SettingsUISection(TabReset, ResetFeedbackGroup)]
        [SettingsUIButton]
        public bool JoinDiscord
        {
            set
            {
                UnityEngine.Application.OpenURL(DiscordInviteUrl);
            }
        }

        /// <summary>
        /// Options button. Restores filters, pace sliders, and debugging.
        /// Does not queue a traffic reset.
        /// Sits in its own group so a header separates it from the type filters below.
        /// </summary>
        [SettingsUISection(TabReset, ResetDefaultsGroup)]
        [SettingsUIButton]
        [SettingsUIConfirmation]
        public bool ResetModSettings
        {
            set
            {
                bool wasDebugging = ResetEnableDebugging;
                ApplyResetDefaults();
                ApplyAndSave();
                if (wasDebugging)
                {
                    ResetOnDebuggingChanged(false);
                }

                TrafficUtils.Mod.ResetLog?.Info("Options restored to defaults.");
            }
        }

        // Moving: InterpolatedTransform present. On by default except pedestrians.
        [SettingsUISection(TabReset, ResetMovingGroup)]
        public bool RemoveMovingCars { get; set; }

        [SettingsUISection(TabReset, ResetMovingGroup)]
        public bool RemoveMovingBicycles { get; set; }

        [SettingsUISection(TabReset, ResetMovingGroup)]
        public bool RemoveMovingTrains { get; set; }

        [SettingsUISection(TabReset, ResetMovingGroup)]
        public bool RemoveMovingPublicTransport { get; set; }

        [SettingsUISection(TabReset, ResetMovingGroup)]
        public bool RemoveMovingTrucks { get; set; }

        [SettingsUISection(TabReset, ResetMovingGroup)]
        public bool RemoveMovingOther { get; set; }

        [SettingsUISection(TabReset, ResetMovingGroup)]
        public bool RemovePedestrians { get; set; }

        // Parked cars/bicycles on by default (includes garage/depot/service fleets, not only curbs). Trains and other parked stay off.
        [SettingsUISection(TabReset, ResetParkedGroup)]
        public bool RemoveParkedCars { get; set; }

        [SettingsUISection(TabReset, ResetParkedGroup)]
        public bool RemoveParkedBicycles { get; set; }

        [SettingsUISection(TabReset, ResetParkedGroup)]
        public bool RemoveParkedTrains { get; set; }

        [SettingsUISection(TabReset, ResetParkedGroup)]
        public bool RemoveParkedOther { get; set; }

        /// <summary>How many snapshot entities to tag Deleted each accepted Unity render frame.</summary>
        [SettingsUISection(TabReset, ResetPaceGroup)]
        [SettingsUISlider(min = MinVehiclesPerFrame, max = MaxVehiclesPerFrame, step = 1, scalarMultiplier = 1)]
        public int VehiclesPerFrame { get; set; }

        /// <summary>Extra display frames to skip after each batch. 0 = every frame. Simulation ticks stall while paused, so this uses Unity frames.</summary>
        [SettingsUISection(TabReset, ResetPaceGroup)]
        [SettingsUISlider(min = MinFrameInterval, max = MaxFrameInterval, step = 1, scalarMultiplier = 1)]
        public int FrameInterval { get; set; }

        /// <summary>Verbose <c>[DEBUG]</c> lines in the mod log. Hits FPS; leave off unless diagnosing a run.</summary>
        [SettingsUISection(TabReset, ResetDebugGroup)]
        [SettingsUISetter(typeof(Setting), nameof(ResetOnDebuggingChanged))]
        public bool ResetEnableDebugging { get; set; }

        public bool ResetIsNotInGame => !ResetIsInGame();

        public bool IsRunning => ResetTrafficSystem.IsActive;

        public bool DisableResetButton => ResetIsNotInGame || ResetTrafficSystem.IsActive;

        /// <summary>Incremented by the system after each progress publish so Options rebinds Status.</summary>
        public int ResetGetUiVersion()
        {
            return ResetTrafficSystem.UiVersion;
        }

        internal void ApplyResetDefaults()
        {
            VehiclesPerFrame = DefaultVehiclesPerFrame;
            FrameInterval = DefaultFrameInterval;
            RemoveMovingCars = true;
            RemoveMovingBicycles = true;
            RemoveMovingTrains = true;
            RemoveMovingPublicTransport = true;
            RemoveMovingTrucks = true;
            RemoveMovingOther = true;
            // Pedestrians respawn continuously. Parked trains/other stay off. Parked cars include depot/service fleets.
            RemovePedestrians = false;
            RemoveParkedCars = true;
            RemoveParkedBicycles = true;
            RemoveParkedTrains = false;
            RemoveParkedOther = false;
            ResetEnableDebugging = false;
        }

        public void ResetOnDebuggingChanged(bool value)
        {
            TrafficUtils.Mod.ResetLog?.Info(value
                ? "Debugging ON. Verbose reset logs are enabled and will slow the game. See Mods_ResetTraffic.log."
                : "Debugging OFF. Reset logs back to normal.");
        }

        internal bool HasAnythingSelected()
        {
            return RemoveMovingCars
                || RemoveMovingBicycles
                || RemoveMovingTrains
                || RemoveMovingPublicTransport
                || RemoveMovingTrucks
                || RemoveMovingOther
                || RemovePedestrians
                || RemoveParkedCars
                || RemoveParkedBicycles
                || RemoveParkedTrains
                || RemoveParkedOther;
        }

        // Clamp because Mods_ResetTraffic.coc can be edited by hand outside the slider range.
        internal int ClampedVehiclesPerFrame()
        {
            int value = VehiclesPerFrame;
            if (value < MinVehiclesPerFrame)
            {
                return MinVehiclesPerFrame;
            }

            if (value > MaxVehiclesPerFrame)
            {
                return MaxVehiclesPerFrame;
            }

            return value;
        }

        internal int ClampedFrameInterval()
        {
            int value = FrameInterval;
            if (value < MinFrameInterval)
            {
                return MinFrameInterval;
            }

            if (value > MaxFrameInterval)
            {
                return MaxFrameInterval;
            }

            return value;
        }

        internal static bool ResetIsInGame()
        {
            World world = World.DefaultGameObjectInjectionWorld;
            if (world == null || !world.IsCreated)
            {
                return false;
            }

            // False on the main menu and while Options is open (actionMode is not Game).
            ToolSystem toolSystem = world.GetExistingSystemManaged<ToolSystem>();
            return toolSystem != null && toolSystem.actionMode.IsGame();
        }
    }
}
