namespace TrafficUtils
{
    using JamThreshold;
    using Colossal.IO.AssetDatabase;
    using Game.Modding;
    using Game.Settings;

    /// <summary>
    /// Options page: enable the replacement stuck-check, set chain depth and raw
    /// speed threshold, read the session statistics and rates, turn on debug logs,
    /// or hand ownership back to vanilla <c>StuckMovingObjectSystem</c>.
    /// This is not a city-wide traffic reset.
    /// </summary>
    // Jam Threshold values live on the shared Traffic Utils settings file.
    public partial class Setting
    {
        
        public const string JamToggleGroup = "Toggle";
        public const string JamThresholdGroup = "Thresholds";
        public const string JamStatsGroup = "JamStatistics";
        public const string JamRateGroup = "JamRate";
        public const string JamVanillaGroup = "Vanilla";
        public const string JamDebugGroup = "JamDebug";

        public const int DefaultChainDepth = 40;
        public const int VanillaChainDepth = 100;
        public const int MinChainDepth = 1;
        public const int MaxChainDepth = 200;

        public const int DefaultMaxStuckSpeed = 6;
        public const int VanillaMaxStuckSpeed = 6;
        public const int MinMaxStuckSpeed = 0;
        public const int MaxMaxStuckSpeed = 255;

        /// <summary>
        /// When on, vanilla <c>StuckMovingObjectSystem</c> is disabled and
        /// <see cref="JamThresholdSystem"/> runs with the sliders below.
        /// </summary>
        [SettingsUISection(TabJam, JamToggleGroup)]
        [SettingsUISetter(typeof(Setting), nameof(JamOnEnabledChanged))]
        public bool JamEnabled { get; set; }

        /// <summary>
        /// A blocked chain is flagged stuck if it is a loop or this many vehicles long.
        /// Vanilla is 100. Default 40 so shorter jams clear.
        /// </summary>
        [SettingsUISection(TabJam, JamThresholdGroup)]
        [SettingsUISlider(min = MinChainDepth, max = MaxChainDepth, step = 1, scalarMultiplier = 1)]
        [SettingsUIHideByCondition(typeof(Setting), nameof(IsVanillaActive))]
        public int ChainDepth { get; set; }

        /// <summary>
        /// Raw <c>Blocker.m_MaxSpeed</c> byte. The chain walk stops if any vehicle is at or
        /// above this. Vanilla 6 (about 1.2 m/s at ~0.2 m/s per unit).
        /// </summary>
        [SettingsUISection(TabJam, JamThresholdGroup)]
        [SettingsUISlider(min = MinMaxStuckSpeed, max = MaxMaxStuckSpeed, step = 1, scalarMultiplier = 1)]
        [SettingsUIHideByCondition(typeof(Setting), nameof(IsVanillaActive))]
        public int MaxStuckSpeed { get; set; }

        /// <summary>
        /// Objects flagged stuck this session. A plain string (not MultilineText, not disabled)
        /// so Options actually shows the getter value; getter-only keeps it out of the .coc.
        /// </summary>
        [SettingsUISection(TabJam, JamStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        public string ClearedText => ClearanceStats.FormatCleared();

        // One row per subtype. Hidden while the count is zero so a fresh city is not a wall of zeros.
        // Getter-only, same as the totals, so none of these are written to Mods_JamThreshold.coc.

        [SettingsUISection(TabJam, JamStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(JamHideCar))]
        public string JamCarText => ClearanceStats.FormatCount(ClearedKind.Car);

        public bool JamHideCar => ClearanceStats.IsZero(ClearedKind.Car);

        [SettingsUISection(TabJam, JamStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(JamHideDeliveryTruck))]
        public string JamDeliveryTruckText => ClearanceStats.FormatCount(ClearedKind.DeliveryTruck);

        public bool JamHideDeliveryTruck => ClearanceStats.IsZero(ClearedKind.DeliveryTruck);

        [SettingsUISection(TabJam, JamStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(JamHideGarbageTruck))]
        public string JamGarbageTruckText => ClearanceStats.FormatCount(ClearedKind.GarbageTruck);

        public bool JamHideGarbageTruck => ClearanceStats.IsZero(ClearedKind.GarbageTruck);

        [SettingsUISection(TabJam, JamStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(JamHideCargoTruck))]
        public string JamCargoTruckText => ClearanceStats.FormatCount(ClearedKind.CargoTruck);

        public bool JamHideCargoTruck => ClearanceStats.IsZero(ClearedKind.CargoTruck);

        [SettingsUISection(TabJam, JamStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(JamHideRoadMaintenance))]
        public string JamRoadMaintenanceText => ClearanceStats.FormatCount(ClearedKind.RoadMaintenance);

        public bool JamHideRoadMaintenance => ClearanceStats.IsZero(ClearedKind.RoadMaintenance);

        [SettingsUISection(TabJam, JamStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(JamHideParkMaintenance))]
        public string JamParkMaintenanceText => ClearanceStats.FormatCount(ClearedKind.ParkMaintenance);

        public bool JamHideParkMaintenance => ClearanceStats.IsZero(ClearedKind.ParkMaintenance);

        [SettingsUISection(TabJam, JamStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(JamHideMaintenance))]
        public string JamMaintenanceText => ClearanceStats.FormatCount(ClearedKind.Maintenance);

        public bool JamHideMaintenance => ClearanceStats.IsZero(ClearedKind.Maintenance);

        [SettingsUISection(TabJam, JamStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(JamHideFireEngine))]
        public string JamFireEngineText => ClearanceStats.FormatCount(ClearedKind.FireEngine);

        public bool JamHideFireEngine => ClearanceStats.IsZero(ClearedKind.FireEngine);

        [SettingsUISection(TabJam, JamStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(JamHidePoliceCar))]
        public string JamPoliceCarText => ClearanceStats.FormatCount(ClearedKind.PoliceCar);

        public bool JamHidePoliceCar => ClearanceStats.IsZero(ClearedKind.PoliceCar);

        [SettingsUISection(TabJam, JamStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(JamHidePostVan))]
        public string JamPostVanText => ClearanceStats.FormatCount(ClearedKind.PostVan);

        public bool JamHidePostVan => ClearanceStats.IsZero(ClearedKind.PostVan);

        [SettingsUISection(TabJam, JamStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(JamHideAmbulance))]
        public string JamAmbulanceText => ClearanceStats.FormatCount(ClearedKind.Ambulance);

        public bool JamHideAmbulance => ClearanceStats.IsZero(ClearedKind.Ambulance);

        [SettingsUISection(TabJam, JamStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(JamHideHearse))]
        public string JamHearseText => ClearanceStats.FormatCount(ClearedKind.Hearse);

        public bool JamHideHearse => ClearanceStats.IsZero(ClearedKind.Hearse);

        [SettingsUISection(TabJam, JamStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(JamHidePrisonerTransport))]
        public string JamPrisonerTransportText => ClearanceStats.FormatCount(ClearedKind.PrisonerTransport);

        public bool JamHidePrisonerTransport => ClearanceStats.IsZero(ClearedKind.PrisonerTransport);

        [SettingsUISection(TabJam, JamStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(JamHideEvacuation))]
        public string JamEvacuationText => ClearanceStats.FormatCount(ClearedKind.Evacuation);

        public bool JamHideEvacuation => ClearanceStats.IsZero(ClearedKind.Evacuation);

        [SettingsUISection(TabJam, JamStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(JamHideTaxi))]
        public string JamTaxiText => ClearanceStats.FormatCount(ClearedKind.Taxi);

        public bool JamHideTaxi => ClearanceStats.IsZero(ClearedKind.Taxi);

        [SettingsUISection(TabJam, JamStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(JamHideTransit))]
        public string JamTransitText => ClearanceStats.FormatCount(ClearedKind.Transit);

        public bool JamHideTransit => ClearanceStats.IsZero(ClearedKind.Transit);

        [SettingsUISection(TabJam, JamStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(JamHidePassengerTrain))]
        public string JamPassengerTrainText => ClearanceStats.FormatCount(ClearedKind.PassengerTrain);

        public bool JamHidePassengerTrain => ClearanceStats.IsZero(ClearedKind.PassengerTrain);

        [SettingsUISection(TabJam, JamStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(JamHideCargoTrain))]
        public string JamCargoTrainText => ClearanceStats.FormatCount(ClearedKind.CargoTrain);

        public bool JamHideCargoTrain => ClearanceStats.IsZero(ClearedKind.CargoTrain);

        [SettingsUISection(TabJam, JamStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(JamHideTrain))]
        public string JamTrainText => ClearanceStats.FormatCount(ClearedKind.Train);

        public bool JamHideTrain => ClearanceStats.IsZero(ClearedKind.Train);

        [SettingsUISection(TabJam, JamStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(JamHideAirplane))]
        public string JamAirplaneText => ClearanceStats.FormatCount(ClearedKind.Airplane);

        public bool JamHideAirplane => ClearanceStats.IsZero(ClearedKind.Airplane);

        [SettingsUISection(TabJam, JamStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(JamHideHelicopter))]
        public string JamHelicopterText => ClearanceStats.FormatCount(ClearedKind.Helicopter);

        public bool JamHideHelicopter => ClearanceStats.IsZero(ClearedKind.Helicopter);

        [SettingsUISection(TabJam, JamStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(JamHideAircraft))]
        public string JamAircraftText => ClearanceStats.FormatCount(ClearedKind.Aircraft);

        public bool JamHideAircraft => ClearanceStats.IsZero(ClearedKind.Aircraft);

        [SettingsUISection(TabJam, JamStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(JamHideWatercraft))]
        public string JamWatercraftText => ClearanceStats.FormatCount(ClearedKind.Watercraft);

        public bool JamHideWatercraft => ClearanceStats.IsZero(ClearedKind.Watercraft);

        [SettingsUISection(TabJam, JamStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(JamHideBicycle))]
        public string JamBicycleText => ClearanceStats.FormatCount(ClearedKind.Bicycle);

        public bool JamHideBicycle => ClearanceStats.IsZero(ClearedKind.Bicycle);

        [SettingsUISection(TabJam, JamStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(JamHidePedestrian))]
        public string JamPedestrianText => ClearanceStats.FormatCount(ClearedKind.Pedestrian);

        public bool JamHidePedestrian => ClearanceStats.IsZero(ClearedKind.Pedestrian);

        [SettingsUISection(TabJam, JamStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(JamHideOther))]
        public string JamOtherText => ClearanceStats.FormatCount(ClearedKind.Other);

        public bool JamHideOther => ClearanceStats.IsZero(ClearedKind.Other);

        /// <summary>Those objects per in-game hour, not per real-time hour.</summary>
        [SettingsUISection(TabJam, JamRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        public string JamRateText => ClearanceStats.FormatRate();

        [SettingsUISection(TabJam, JamRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(JamHideCar))]
        public string JamCarRateText => ClearanceStats.FormatKindRate(ClearedKind.Car);

        [SettingsUISection(TabJam, JamRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(JamHideDeliveryTruck))]
        public string JamDeliveryTruckRateText => ClearanceStats.FormatKindRate(ClearedKind.DeliveryTruck);

        [SettingsUISection(TabJam, JamRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(JamHideGarbageTruck))]
        public string JamGarbageTruckRateText => ClearanceStats.FormatKindRate(ClearedKind.GarbageTruck);

        [SettingsUISection(TabJam, JamRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(JamHideCargoTruck))]
        public string JamCargoTruckRateText => ClearanceStats.FormatKindRate(ClearedKind.CargoTruck);

        [SettingsUISection(TabJam, JamRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(JamHideRoadMaintenance))]
        public string JamRoadMaintenanceRateText => ClearanceStats.FormatKindRate(ClearedKind.RoadMaintenance);

        [SettingsUISection(TabJam, JamRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(JamHideParkMaintenance))]
        public string JamParkMaintenanceRateText => ClearanceStats.FormatKindRate(ClearedKind.ParkMaintenance);

        [SettingsUISection(TabJam, JamRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(JamHideMaintenance))]
        public string JamMaintenanceRateText => ClearanceStats.FormatKindRate(ClearedKind.Maintenance);

        [SettingsUISection(TabJam, JamRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(JamHideFireEngine))]
        public string JamFireEngineRateText => ClearanceStats.FormatKindRate(ClearedKind.FireEngine);

        [SettingsUISection(TabJam, JamRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(JamHidePoliceCar))]
        public string JamPoliceCarRateText => ClearanceStats.FormatKindRate(ClearedKind.PoliceCar);

        [SettingsUISection(TabJam, JamRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(JamHidePostVan))]
        public string JamPostVanRateText => ClearanceStats.FormatKindRate(ClearedKind.PostVan);

        [SettingsUISection(TabJam, JamRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(JamHideAmbulance))]
        public string JamAmbulanceRateText => ClearanceStats.FormatKindRate(ClearedKind.Ambulance);

        [SettingsUISection(TabJam, JamRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(JamHideHearse))]
        public string JamHearseRateText => ClearanceStats.FormatKindRate(ClearedKind.Hearse);

        [SettingsUISection(TabJam, JamRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(JamHidePrisonerTransport))]
        public string JamPrisonerTransportRateText => ClearanceStats.FormatKindRate(ClearedKind.PrisonerTransport);

        [SettingsUISection(TabJam, JamRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(JamHideEvacuation))]
        public string JamEvacuationRateText => ClearanceStats.FormatKindRate(ClearedKind.Evacuation);

        [SettingsUISection(TabJam, JamRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(JamHideTaxi))]
        public string JamTaxiRateText => ClearanceStats.FormatKindRate(ClearedKind.Taxi);

        [SettingsUISection(TabJam, JamRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(JamHideTransit))]
        public string JamTransitRateText => ClearanceStats.FormatKindRate(ClearedKind.Transit);

        [SettingsUISection(TabJam, JamRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(JamHidePassengerTrain))]
        public string JamPassengerTrainRateText => ClearanceStats.FormatKindRate(ClearedKind.PassengerTrain);

        [SettingsUISection(TabJam, JamRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(JamHideCargoTrain))]
        public string JamCargoTrainRateText => ClearanceStats.FormatKindRate(ClearedKind.CargoTrain);

        [SettingsUISection(TabJam, JamRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(JamHideTrain))]
        public string JamTrainRateText => ClearanceStats.FormatKindRate(ClearedKind.Train);

        [SettingsUISection(TabJam, JamRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(JamHideAirplane))]
        public string JamAirplaneRateText => ClearanceStats.FormatKindRate(ClearedKind.Airplane);

        [SettingsUISection(TabJam, JamRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(JamHideHelicopter))]
        public string JamHelicopterRateText => ClearanceStats.FormatKindRate(ClearedKind.Helicopter);

        [SettingsUISection(TabJam, JamRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(JamHideAircraft))]
        public string JamAircraftRateText => ClearanceStats.FormatKindRate(ClearedKind.Aircraft);

        [SettingsUISection(TabJam, JamRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(JamHideWatercraft))]
        public string JamWatercraftRateText => ClearanceStats.FormatKindRate(ClearedKind.Watercraft);

        [SettingsUISection(TabJam, JamRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(JamHideBicycle))]
        public string JamBicycleRateText => ClearanceStats.FormatKindRate(ClearedKind.Bicycle);

        [SettingsUISection(TabJam, JamRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(JamHidePedestrian))]
        public string JamPedestrianRateText => ClearanceStats.FormatKindRate(ClearedKind.Pedestrian);

        [SettingsUISection(TabJam, JamRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(GetStatsVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(JamHideOther))]
        public string JamOtherRateText => ClearanceStats.FormatKindRate(ClearedKind.Other);

        /// <summary>
        /// Options button. Zeroes the counters and restarts the in-game-hour window.
        /// Does not touch thresholds and does not despawn traffic.
        /// </summary>
        [SettingsUISection(TabJam, JamRateGroup)]
        [SettingsUIButton]
        [SettingsUIConfirmation]
        public bool JamResetStats
        {
            set
            {
                ClearanceStats.RequestReset();
                TrafficUtils.Mod.JamLog?.Info("Statistics reset; counting restarts from zero.");
            }
        }

        /// <summary>
        /// Options button. Re-enables vanilla <c>StuckMovingObjectSystem</c> and disables
        /// the replacement. Does not despawn traffic.
        /// </summary>
        [SettingsUISection(TabJam, JamVanillaGroup)]
        [SettingsUIButton]
        [SettingsUIConfirmation]
        [SettingsUIDisableByCondition(typeof(Setting), nameof(IsVanillaActive))]
        public bool ResetToVanilla
        {
            set
            {
                JamEnabled = false;
                ApplyAndSave();
                JamThresholdSystem.ApplyOwnership(false);
                TrafficUtils.Mod.JamLog?.Info("Reset to vanilla StuckMovingObjectSystem (replacement disabled).");
            }
        }

        /// <summary>Verbose <c>[DEBUG]</c> lines in the mod log. Hits FPS; leave off unless diagnosing.</summary>
        [SettingsUISection(TabJam, JamDebugGroup)]
        [SettingsUISetter(typeof(Setting), nameof(JamOnDebuggingChanged))]
        public bool JamEnableDebugging { get; set; }

        public bool IsVanillaActive => !JamEnabled;

        /// <summary>Bumped by <see cref="ClearanceStats"/> so Options rebinds the statistics lines.</summary>
        public int GetStatsVersion()
        {
            return ClearanceStats.UiVersion;
        }

        internal void ApplyJamDefaults()
        {
            JamEnabled = true;
            ChainDepth = DefaultChainDepth;
            MaxStuckSpeed = DefaultMaxStuckSpeed;
            JamEnableDebugging = false;
        }

        public void JamOnEnabledChanged(bool value)
        {
            JamThresholdSystem.ApplyOwnership(value);
            TrafficUtils.Mod.JamLog?.Info(value
                ? "Replacement stuck-check ON (vanilla StuckMovingObjectSystem disabled)."
                : "Replacement stuck-check OFF (vanilla StuckMovingObjectSystem re-enabled).");
        }

        public void JamOnDebuggingChanged(bool value)
        {
            TrafficUtils.Mod.JamLog?.Info(value
                ? "Debugging ON. Verbose stuck-check logs are enabled and will slow the game. See Mods_JamThreshold.log."
                : "Debugging OFF. Stuck-check logs back to normal.");
        }

        // Clamp because Mods_JamThreshold.coc can be edited by hand outside the slider range.
        internal int ClampedChainDepth()
        {
            int value = ChainDepth;
            if (value < MinChainDepth)
            {
                return MinChainDepth;
            }

            if (value > MaxChainDepth)
            {
                return MaxChainDepth;
            }

            return value;
        }

        internal byte ClampedMaxStuckSpeed()
        {
            int value = MaxStuckSpeed;
            if (value < MinMaxStuckSpeed)
            {
                return (byte)MinMaxStuckSpeed;
            }

            if (value > MaxMaxStuckSpeed)
            {
                return (byte)MaxMaxStuckSpeed;
            }

            return (byte)value;
        }
    }
}
