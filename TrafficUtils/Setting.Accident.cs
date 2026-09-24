namespace TrafficUtils
{
    using AccidentsBeGone;
    using Colossal.IO.AssetDatabase;
    using Game;
    using Game.Modding;
    using Game.Settings;
    using Game.Tools;
    using Unity.Entities;

    /// <summary>
    /// Options page: hold traffic-accident chance at zero, clear wrecks already on the roads,
    /// read how often each object type is actually involved, and turn on debug logs.
    /// This is not Disable Accidents and does not load that mod.
    /// </summary>
    // Saved as Mods_AccidentsBeGone.coc under the game's userdata root.
    public partial class Setting
    {
        
        public const string AccidentToggleGroup = "Prevention";
        public const string AccidentClearGroup = "Clear";
        public const string AccidentStatsGroup = "AccidentStatistics";
        public const string AccidentRateGroup = "AccidentRate";
        public const string AccidentDebugGroup = "AccidentDebug";

        public const int DefaultUpdateInterval = 1;
        public const int MinUpdateInterval = 1;
        public const int MaxUpdateInterval = 50;

        /// <summary>
        /// When on, <see cref="AccidentsBeGoneSystem"/> writes accident chance 0 every tick.
        /// When off, the prefab's own chance is restored once.
        /// </summary>
        [SettingsUISection(TabAccident, AccidentToggleGroup)]
        [SettingsUISetter(typeof(Setting), nameof(AccidentOnEnabledChanged))]
        public bool AccidentEnabled { get; set; } = false;

        /// <summary>
        /// Frames between runs of the chance write and the statistics scan. 1 runs every frame.
        /// </summary>
        [SettingsUISection(TabAccident, AccidentToggleGroup)]
        [SettingsUISlider(min = MinUpdateInterval, max = MaxUpdateInterval, step = 1, scalarMultiplier = 1)]
        [SettingsUISetter(typeof(Setting), nameof(OnUpdateIntervalChanged))]
        public int UpdateInterval { get; set; } = DefaultUpdateInterval;

        /// <summary>
        /// When on, a city load or turning <see cref="AccidentEnabled"/> on removes traffic-accident sites
        /// already on the roads. Fires and crime scenes stay.
        /// </summary>
        [SettingsUISection(TabAccident, AccidentClearGroup)]
        [SettingsUISetter(typeof(Setting), nameof(OnClearOnLoadChanged))]
        public bool ClearOnLoad { get; set; }

        /// <summary>
        /// Options button. Removes traffic-accident sites now. Does not delete roads or vehicles.
        /// </summary>
        [SettingsUISection(TabAccident, AccidentClearGroup)]
        [SettingsUIButton]
        [SettingsUIConfirmation]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(AccidentIsNotInGame))]
        public bool ClearNow
        {
            set
            {
                AccidentsBeGoneSystem.RequestClear();
            }
        }

        /// <summary>
        /// Last clear counts. A plain string so Options shows the getter value.
        /// </summary>
        [SettingsUISection(TabAccident, AccidentClearGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        public string StatusText => AccidentsBeGoneSystem.FormatStatus();

        /// <summary>Verbose <c>[DEBUG]</c> lines in the mod log. Leave off unless diagnosing.</summary>
        [SettingsUISection(TabAccident, AccidentDebugGroup)]
        [SettingsUISetter(typeof(Setting), nameof(AccidentOnDebuggingChanged))]
        public bool AccidentEnableDebugging { get; set; }

        public bool AccidentIsNotInGame => !AccidentIsInGame();

        internal int ClampedUpdateInterval()
        {
            int value = UpdateInterval;
            if (value < MinUpdateInterval)
            {
                return MinUpdateInterval;
            }

            if (value > MaxUpdateInterval)
            {
                return MaxUpdateInterval;
            }

            return value;
        }

        /// <summary>Bumped after a clear so Options rebinds <see cref="StatusText"/>.</summary>
        public int AccidentGetUiVersion()
        {
            return AccidentsBeGoneSystem.UiVersion + InvolvedStats.UiVersion;
        }

        internal void ApplyAccidentDefaults()
        {
            AccidentEnabled = false;
            UpdateInterval = DefaultUpdateInterval;
            ClearOnLoad = true;
            AccidentEnableDebugging = false;
        }

        public void AccidentOnEnabledChanged(bool value)
        {
            if (value && ClearOnLoad)
            {
                AccidentsBeGoneSystem.RequestClear();
            }

            TrafficUtils.Mod.AccidentLog?.Info(value
                ? "Accident prevention ON. Chance is held at zero."
                : "Accident prevention OFF. Chance will be restored from the accident prefab.");
        }

        public void OnUpdateIntervalChanged(int value)
        {
            TrafficUtils.Mod.AccidentLog?.Info($"Run every {ClampedUpdateInterval()} frame(s).");
        }

        public void OnClearOnLoadChanged(bool value)
        {
            if (value && AccidentEnabled)
            {
                AccidentsBeGoneSystem.RequestClear();
            }

            TrafficUtils.Mod.AccidentLog?.Info(value
                ? "Clear existing wrecks ON."
                : "Clear existing wrecks OFF. New accidents stay blocked while prevention is on.");
        }

        public void AccidentOnDebuggingChanged(bool value)
        {
            TrafficUtils.Mod.AccidentLog?.Info(value
                ? "Debugging ON. Verbose lines are enabled. See Mods_AccidentsBeGone.log."
                : "Debugging OFF.");
        }

        internal static bool AccidentIsInGame()
        {
            World world = World.DefaultGameObjectInjectionWorld;
            if (world == null || !world.IsCreated)
            {
                return false;
            }

            ToolSystem toolSystem = world.GetExistingSystemManaged<ToolSystem>();
            return toolSystem != null && toolSystem.actionMode.IsGame();
        }
    }
}
