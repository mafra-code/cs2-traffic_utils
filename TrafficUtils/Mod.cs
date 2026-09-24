namespace TrafficUtils
{
    using System;
    using System.Reflection;
    using Colossal.IO.AssetDatabase;
    using Colossal.Logging;
    using Game;
    using Game.Modding;
    using Game.SceneFlow;

    /// <summary>
    /// Official CS2 <see cref="IMod"/> entry (no Harmony). One Options page, three systems.
    /// </summary>
    public class Mod : IMod
    {
        public const string Id = "TrafficUtils";

        public static Mod Instance { get; private set; }

        /// <summary>Writes <c>Mods_TrafficUtils.log</c> under the game's Logs folder.</summary>
        internal static ILog Log { get; private set; }

        /// <summary>Writes <c>Mods_ResetTraffic.log</c>.</summary>
        internal static ILog ResetLog { get; private set; }

        /// <summary>Writes <c>Mods_JamThreshold.log</c>.</summary>
        internal static ILog JamLog { get; private set; }

        /// <summary>Writes <c>Mods_AccidentsBeGone.log</c>.</summary>
        internal static ILog AccidentLog { get; private set; }

        internal Setting Settings { get; private set; }

        public void OnLoad(UpdateSystem updateSystem)
        {
            Instance = this;
            Log = LogManager.GetLogger("Mods_TrafficUtils").SetShowsErrorsInUI(false);
            ResetLog = LogManager.GetLogger("Mods_ResetTraffic").SetShowsErrorsInUI(false);
            JamLog = LogManager.GetLogger("Mods_JamThreshold").SetShowsErrorsInUI(false);
            AccidentLog = LogManager.GetLogger("Mods_AccidentsBeGone").SetShowsErrorsInUI(false);
            Log.Info(nameof(OnLoad));
            WarnIfLegacyModsLoaded();

            Settings = new Setting(this);
            Settings.RegisterInOptionsUI();
            AddLocales();

            SettingsMigration.ImportIfNeeded(Settings, this);
            AssetDatabase.global.LoadSettings(nameof(TrafficUtils), Settings, new Setting(this));

            updateSystem.UpdateAt<ResetTraffic.ResetTrafficSystem>(SystemUpdatePhase.ToolUpdate);
            updateSystem.UpdateAt<JamThreshold.JamThresholdSystem>(SystemUpdatePhase.GameSimulation);
            updateSystem.UpdateAt<AccidentsBeGone.AccidentsBeGoneSystem>(SystemUpdatePhase.ModificationEnd);
            JamThreshold.JamThresholdSystem.ApplyOwnership(Settings.JamEnabled);
            Log.Info($"{nameof(OnLoad)} complete.");
        }

        public void OnDispose()
        {
            Log?.Info("Disposing.");
            JamThreshold.JamThresholdSystem.ApplyOwnership(false);
            if (Settings != null)
            {
                Settings.UnregisterInOptionsUI();
                Settings = null;
            }

            Instance = null;
        }

        private void AddLocales()
        {
            var localization = GameManager.instance.localizationManager;
            localization.AddSource("en-US", new ResetTraffic.LocaleEN(Settings));
            localization.AddSource("de-DE", new ResetTraffic.LocaleDE(Settings));
            localization.AddSource("es-ES", new ResetTraffic.LocaleES(Settings));
            localization.AddSource("fr-FR", new ResetTraffic.LocaleFR(Settings));
            localization.AddSource("it-IT", new ResetTraffic.LocaleIT(Settings));
            localization.AddSource("ja-JP", new ResetTraffic.LocaleJA(Settings));
            localization.AddSource("ko-KR", new ResetTraffic.LocaleKO(Settings));
            localization.AddSource("pl-PL", new ResetTraffic.LocalePL(Settings));
            localization.AddSource("pt-BR", new ResetTraffic.LocalePT(Settings));
            localization.AddSource("ru-RU", new ResetTraffic.LocaleRU(Settings));
            localization.AddSource("zh-HANS", new ResetTraffic.LocaleZHHans(Settings));
            localization.AddSource("zh-HANT", new ResetTraffic.LocaleZHHant(Settings));

            localization.AddSource("en-US", new JamThreshold.LocaleEN(Settings));
            localization.AddSource("de-DE", new JamThreshold.LocaleDE(Settings));
            localization.AddSource("es-ES", new JamThreshold.LocaleES(Settings));
            localization.AddSource("fr-FR", new JamThreshold.LocaleFR(Settings));
            localization.AddSource("it-IT", new JamThreshold.LocaleIT(Settings));
            localization.AddSource("ja-JP", new JamThreshold.LocaleJA(Settings));
            localization.AddSource("ko-KR", new JamThreshold.LocaleKO(Settings));
            localization.AddSource("pl-PL", new JamThreshold.LocalePL(Settings));
            localization.AddSource("pt-BR", new JamThreshold.LocalePT(Settings));
            localization.AddSource("ru-RU", new JamThreshold.LocaleRU(Settings));
            localization.AddSource("zh-HANS", new JamThreshold.LocaleZHHans(Settings));
            localization.AddSource("zh-HANT", new JamThreshold.LocaleZHHant(Settings));

            localization.AddSource("en-US", new AccidentsBeGone.LocaleEN(Settings));
            localization.AddSource("de-DE", new AccidentsBeGone.LocaleDE(Settings));
            localization.AddSource("es-ES", new AccidentsBeGone.LocaleES(Settings));
            localization.AddSource("fr-FR", new AccidentsBeGone.LocaleFR(Settings));
            localization.AddSource("it-IT", new AccidentsBeGone.LocaleIT(Settings));
            localization.AddSource("ja-JP", new AccidentsBeGone.LocaleJA(Settings));
            localization.AddSource("ko-KR", new AccidentsBeGone.LocaleKO(Settings));
            localization.AddSource("pl-PL", new AccidentsBeGone.LocalePL(Settings));
            localization.AddSource("pt-BR", new AccidentsBeGone.LocalePT(Settings));
            localization.AddSource("ru-RU", new AccidentsBeGone.LocaleRU(Settings));
            localization.AddSource("zh-HANS", new AccidentsBeGone.LocaleZHHans(Settings));
            localization.AddSource("zh-HANT", new AccidentsBeGone.LocaleZHHant(Settings));

            // Last, so the page title and tab labels win over the three old page titles.
            localization.AddSource("en-US", new LocalePages(Settings, "en-US"));
            localization.AddSource("de-DE", new LocalePages(Settings, "de-DE"));
            localization.AddSource("es-ES", new LocalePages(Settings, "es-ES"));
            localization.AddSource("fr-FR", new LocalePages(Settings, "fr-FR"));
            localization.AddSource("it-IT", new LocalePages(Settings, "it-IT"));
            localization.AddSource("ja-JP", new LocalePages(Settings, "ja-JP"));
            localization.AddSource("ko-KR", new LocalePages(Settings, "ko-KR"));
            localization.AddSource("pl-PL", new LocalePages(Settings, "pl-PL"));
            localization.AddSource("pt-BR", new LocalePages(Settings, "pt-BR"));
            localization.AddSource("ru-RU", new LocalePages(Settings, "ru-RU"));
            localization.AddSource("zh-HANS", new LocalePages(Settings, "zh-HANS"));
            localization.AddSource("zh-HANT", new LocalePages(Settings, "zh-HANT"));
        }

        private static void WarnIfLegacyModsLoaded()
        {
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                string name = assembly.GetName().Name;
                if (name == "ResetTraffic" || name == "JamThreshold" || name == "AccidentsBeGone")
                {
                    Log.Error(
                        "Disable " + name + ". Traffic Utils already includes it. "
                        + "Leaving it enabled runs that system twice.");
                }
            }
        }
    }
}
