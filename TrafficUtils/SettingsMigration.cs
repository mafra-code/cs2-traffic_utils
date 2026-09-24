namespace TrafficUtils
{
    using System;
    using System.IO;
    using Colossal.IO.AssetDatabase;
    using Game.Modding;

    /// <summary>
    /// First launch only: copy persisted values from the three old .coc files onto
    /// <see cref="Setting"/>. Later launches use Mods_TrafficUtils.coc only.
    /// Old files are left in place.
    /// </summary>
    internal static class SettingsMigration
    {
        internal static void ImportIfNeeded(Setting target, IMod mod)
        {
            string root = Environment.GetEnvironmentVariable("CSII_USERDATAPATH");
            if (string.IsNullOrEmpty(root))
            {
                root = Environment.GetEnvironmentVariable("CSII_USERDATAPATH", EnvironmentVariableTarget.User);
            }

            if (string.IsNullOrEmpty(root))
            {
                Mod.Log?.Warn("CSII_USERDATAPATH is unset. Skipped import of the older settings files.");
                return;
            }

            string path = Path.Combine(root, "Mods_TrafficUtils.coc");
            if (File.Exists(path))
            {
                return;
            }

            LegacyResetSetting reset = LoadLegacy(mod, "ResetTraffic", () => new LegacyResetSetting(mod));
            LegacyJamSetting jam = LoadLegacy(mod, "JamThreshold", () => new LegacyJamSetting(mod));
            LegacyAccidentSetting accident = LoadLegacy(mod, "AccidentsBeGone", () => new LegacyAccidentSetting(mod));

            target.RemoveMovingCars = reset.RemoveMovingCars;
            target.RemoveMovingBicycles = reset.RemoveMovingBicycles;
            target.RemoveMovingTrains = reset.RemoveMovingTrains;
            target.RemoveMovingPublicTransport = reset.RemoveMovingPublicTransport;
            target.RemoveMovingTrucks = reset.RemoveMovingTrucks;
            target.RemoveMovingOther = reset.RemoveMovingOther;
            target.RemovePedestrians = reset.RemovePedestrians;
            target.RemoveParkedCars = reset.RemoveParkedCars;
            target.RemoveParkedBicycles = reset.RemoveParkedBicycles;
            target.RemoveParkedTrains = reset.RemoveParkedTrains;
            target.RemoveParkedOther = reset.RemoveParkedOther;
            target.VehiclesPerFrame = reset.VehiclesPerFrame;
            target.FrameInterval = reset.FrameInterval;
            target.ResetEnableDebugging = reset.EnableDebugging;

            target.JamEnabled = false;
            target.ChainDepth = jam.ChainDepth;
            target.MaxStuckSpeed = jam.MaxStuckSpeed;
            target.JamEnableDebugging = jam.EnableDebugging;

            target.AccidentEnabled = false;
            target.UpdateInterval = accident.UpdateInterval;
            target.ClearOnLoad = accident.ClearOnLoad;
            target.AccidentEnableDebugging = accident.EnableDebugging;

            target.ApplyAndSave();
            Mod.Log?.Info("Imported Mods_ResetTraffic.coc, Mods_JamThreshold.coc, and Mods_AccidentsBeGone.coc into Mods_TrafficUtils.coc. The old files were left in place.");
        }

        private static T LoadLegacy<T>(IMod mod, string name, Func<T> create)
            where T : ModSetting
        {
            T loaded = create();
            T defaults = create();
            AssetDatabase.global.LoadSettings(name, loaded, defaults);
            return loaded;
        }
    }
}
