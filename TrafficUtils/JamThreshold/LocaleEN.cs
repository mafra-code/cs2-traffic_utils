namespace JamThreshold
{
    using Setting = TrafficUtils.Setting;
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// English Options strings. Keys are built from <see cref="Setting"/> locale IDs so labels
    /// stay bound if a property is renamed.
    /// </summary>
    public class LocaleEN : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleEN(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                { m_Setting.GetSettingsLocaleID(), "Jam Threshold" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamToggleGroup), "Replacement" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamThresholdGroup), "Thresholds" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamStatsGroup), "Statistics" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamRateGroup), "Rate" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamVanillaGroup), "Vanilla" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamDebugGroup), "Debug" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamEnabled)), "Enabled" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.JamEnabled)), "When on, the game's original stuck-mover check is turned off and this replacement runs with the sliders below. When off, vanilla behavior is restored. This does not reset all traffic." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChainDepth)), "Chain depth" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ChainDepth)), "A chain of blocked vehicles is flagged stuck if it is a loop or longer than this. Vanilla is 100. Default 40 so shorter jams start despawning." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MaxStuckSpeed)), "Speed threshold" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.MaxStuckSpeed)), "Raw Blocker speed byte (~0.2 m/s per unit). The chain walk stops if any vehicle is at or above this. Vanilla 6 is about 1.2 m/s." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ClearedText)), "Cleared this session" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ClearedText)), "Objects this replacement flagged as stuck since the city was loaded. Passengers riding in a vehicle are counted once, through the vehicle. Re-open this page if the numbers look stale." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamRateText)), "All objects" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.JamRateText)), "Cleared objects per in-game hour, not per real-time hour. Paused time does not count. Shown once enough in-game time has passed." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCarText)), "Cars" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamDeliveryTruckText)), "Delivery trucks" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamGarbageTruckText)), "Garbage trucks" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCargoTruckText)), "Cargo trucks" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamRoadMaintenanceText)), "Road maintenance" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamParkMaintenanceText)), "Park maintenance" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamMaintenanceText)), "Maintenance vehicles" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamFireEngineText)), "Fire engines" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPoliceCarText)), "Police cars" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPostVanText)), "Post vans" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAmbulanceText)), "Ambulances" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamHearseText)), "Hearses" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPrisonerTransportText)), "Prisoner transport" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamEvacuationText)), "Evacuation vehicles" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTaxiText)), "Taxis" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTransitText)), "Transit" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPassengerTrainText)), "Passenger trains" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCargoTrainText)), "Cargo trains" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTrainText)), "Trains" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAirplaneText)), "Airplanes" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamHelicopterText)), "Helicopters" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAircraftText)), "Aircraft" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamWatercraftText)), "Watercraft" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamBicycleText)), "Bicycles" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPedestrianText)), "Pedestrians" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamOtherText)), "Other" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCarRateText)), "Cars" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamDeliveryTruckRateText)), "Delivery trucks" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamGarbageTruckRateText)), "Garbage trucks" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCargoTruckRateText)), "Cargo trucks" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamRoadMaintenanceRateText)), "Road maintenance" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamParkMaintenanceRateText)), "Park maintenance" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamMaintenanceRateText)), "Maintenance vehicles" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamFireEngineRateText)), "Fire engines" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPoliceCarRateText)), "Police cars" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPostVanRateText)), "Post vans" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAmbulanceRateText)), "Ambulances" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamHearseRateText)), "Hearses" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPrisonerTransportRateText)), "Prisoner transport" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamEvacuationRateText)), "Evacuation vehicles" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTaxiRateText)), "Taxis" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTransitRateText)), "Transit" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPassengerTrainRateText)), "Passenger trains" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCargoTrainRateText)), "Cargo trains" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTrainRateText)), "Trains" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAirplaneRateText)), "Airplanes" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamHelicopterRateText)), "Helicopters" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAircraftRateText)), "Aircraft" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamWatercraftRateText)), "Watercraft" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamBicycleRateText)), "Bicycles" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPedestrianRateText)), "Pedestrians" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamOtherRateText)), "Other" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamResetStats)), "Reset statistics" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.JamResetStats)), "Set every counter back to zero and start the in-game hour measurement again. Does not change your thresholds and does not remove vehicles." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.JamResetStats)), "Reset the statistics to zero? This only clears the counters. Your thresholds and the traffic in your city are untouched." },
                { ClearanceStats.ClearedId, "{TOTAL} objects" },
                { ClearanceStats.RateId, "~{RATE} objects / in-game hour" },
                { ClearanceStats.KindRateId, "~{RATE} / in-game hour" },
                { ClearanceStats.RateUnknownId, "—" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamEnableDebugging)), "Debugging" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.JamEnableDebugging)), "Verbose stuck-check logs in Mods_JamThreshold.log. Slows the game while on. Turn off for normal speed." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "Reset to vanilla" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)), "Turn this replacement off and use the game's original stuck check (chain 100, speed 6). Does not despawn traffic city-wide. Your sliders are kept if you enable the replacement again." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetToVanilla)), "Use the game's original stuck check? Short jams will sit again until you re-enable this mod. This does not remove vehicles." },
            };
        }

        public void Unload()
        {
            // IDictionarySource requires Unload; Colossal keeps the source for the session.
        }
    }
}
