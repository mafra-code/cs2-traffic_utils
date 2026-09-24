namespace TrafficUtils
{
    using Colossal.IO.AssetDatabase;
    using Game.Modding;
    using Game.SceneFlow;
    using Game.Settings;

    /// <summary>
    /// One Options page, three tabs. Saved as Mods_TrafficUtils.coc.
    /// </summary>
    [FileLocation("Mods_TrafficUtils")]
    [SettingsUITabOrder(TabReset, TabJam, TabAccident)]
    [SettingsUIPageWarning(typeof(Setting), nameof(IsRunning))]
    [SettingsUIGroupOrder(
        ResetNoticeGroup,
        ResetActionGroup,
        ResetFeedbackGroup,
        ResetDefaultsGroup,
        ResetMovingGroup,
        ResetParkedGroup,
        ResetPaceGroup,
        ResetDebugGroup,
        JamToggleGroup,
        JamThresholdGroup,
        JamStatsGroup,
        JamRateGroup,
        JamVanillaGroup,
        JamDebugGroup,
        AccidentToggleGroup,
        AccidentClearGroup,
        AccidentStatsGroup,
        AccidentRateGroup,
        AccidentDebugGroup)]
    [SettingsUIShowGroupName(
        ResetNoticeGroup,
        ResetActionGroup,
        ResetFeedbackGroup,
        ResetDefaultsGroup,
        ResetMovingGroup,
        ResetParkedGroup,
        ResetPaceGroup,
        ResetDebugGroup,
        JamToggleGroup,
        JamThresholdGroup,
        JamStatsGroup,
        JamRateGroup,
        JamVanillaGroup,
        JamDebugGroup,
        AccidentToggleGroup,
        AccidentClearGroup,
        AccidentStatsGroup,
        AccidentRateGroup,
        AccidentDebugGroup)]
    public partial class Setting : ModSetting
    {
        public const string TabReset = "ResetTraffic";
        public const string TabJam = "JamThreshold";
        public const string TabAccident = "AccidentsBeGone";
        public const string ResetNoticeGroup = "Notice";
        public const string SupersededNoteId = "TrafficUtils.NOTE[Superseded]";

        public Setting(IMod mod)
            : base(mod)
        {
            // LoadSettings copies the template when no file exists and does not call SetDefaults.
            SetDefaults();
        }

        /// <summary>
        /// Shown on the Reset Traffic tab. The three older mods must be off or each system runs twice.
        /// </summary>
        [SettingsUISection(TabReset, ResetNoticeGroup)]
        public string SupersededNote => TryLocalize(
            SupersededNoteId,
            "Disable Reset Traffic, Jam Threshold, and Accidents Be Gone. Leaving them on runs each system twice.");

        public override void SetDefaults()
        {
            ApplyResetDefaults();
            ApplyJamDefaults();
            ApplyAccidentDefaults();
        }

        internal static string TryLocalize(string id, string fallback)
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
