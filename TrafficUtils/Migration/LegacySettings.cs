namespace TrafficUtils
{
    using Colossal.IO.AssetDatabase;
    using Game.Input;
    using Game.Modding;
    using Game.Settings;

    /// <summary>
    /// Unregistered copy of the Reset Traffic settings file. Original property names,
    /// so LoadSettings can read Mods_ResetTraffic.coc. Not shown in Options.
    /// </summary>
    [FileLocation("Mods_ResetTraffic")]
    internal class LegacyResetSetting : ModSetting
    {
        public LegacyResetSetting(IMod mod)
            : base(mod)
        {
            SetDefaults();
        }

        public bool RemoveMovingCars { get; set; }

        public bool RemoveMovingBicycles { get; set; }

        public bool RemoveMovingTrains { get; set; }

        public bool RemoveMovingPublicTransport { get; set; }

        public bool RemoveMovingTrucks { get; set; }

        public bool RemoveMovingOther { get; set; }

        public bool RemovePedestrians { get; set; }

        public bool RemoveParkedCars { get; set; }

        public bool RemoveParkedBicycles { get; set; }

        public bool RemoveParkedTrains { get; set; }

        public bool RemoveParkedOther { get; set; }

        public int VehiclesPerFrame { get; set; }

        public int FrameInterval { get; set; }

        public ProxyBinding ResetHotkey { get; set; }

        public bool EnableDebugging { get; set; }

        public override void SetDefaults()
        {
            VehiclesPerFrame = Setting.DefaultVehiclesPerFrame;
            FrameInterval = Setting.DefaultFrameInterval;
            RemoveMovingCars = true;
            RemoveMovingBicycles = true;
            RemoveMovingTrains = true;
            RemoveMovingPublicTransport = true;
            RemoveMovingTrucks = true;
            RemoveMovingOther = true;
            RemovePedestrians = false;
            RemoveParkedCars = true;
            RemoveParkedBicycles = true;
            RemoveParkedTrains = false;
            RemoveParkedOther = false;
            EnableDebugging = false;
        }
    }

    /// <summary>Unregistered copy of Mods_JamThreshold.coc. Not shown in Options.</summary>
    [FileLocation("Mods_JamThreshold")]
    internal class LegacyJamSetting : ModSetting
    {
        public LegacyJamSetting(IMod mod)
            : base(mod)
        {
            SetDefaults();
        }

        public bool Enabled { get; set; }

        public int ChainDepth { get; set; }

        public int MaxStuckSpeed { get; set; }

        public bool EnableDebugging { get; set; }

        public override void SetDefaults()
        {
            Enabled = true;
            ChainDepth = Setting.DefaultChainDepth;
            MaxStuckSpeed = Setting.DefaultMaxStuckSpeed;
            EnableDebugging = false;
        }
    }

    /// <summary>Unregistered copy of Mods_AccidentsBeGone.coc. Not shown in Options.</summary>
    [FileLocation("Mods_AccidentsBeGone")]
    internal class LegacyAccidentSetting : ModSetting
    {
        public LegacyAccidentSetting(IMod mod)
            : base(mod)
        {
            SetDefaults();
        }

        public bool Enabled { get; set; }

        public int UpdateInterval { get; set; }

        public bool ClearOnLoad { get; set; }

        public bool EnableDebugging { get; set; }

        public override void SetDefaults()
        {
            Enabled = true;
            UpdateInterval = Setting.DefaultUpdateInterval;
            ClearOnLoad = true;
            EnableDebugging = false;
        }
    }
}
