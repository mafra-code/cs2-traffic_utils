namespace TrafficUtils
{
    using AccidentsBeGone;
    using Game.Settings;

    /// <summary>
    /// Session counts of objects that actually received <c>InvolvedInAccident</c>,
    /// and the same counts per in-game hour. Rows stay hidden while the count is zero.
    /// Getter-only, so none of this is written to the settings file.
    /// </summary>
    public partial class Setting
    {
        [SettingsUISection(TabAccident, AccidentStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        public string InvolvedText => InvolvedStats.FormatCleared();

        [SettingsUISection(TabAccident, AccidentStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(AccidentHideCar))]
        public string AccidentCarText => InvolvedStats.FormatCount(InvolvedKind.Car);

        public bool AccidentHideCar => InvolvedStats.IsZero(InvolvedKind.Car);

        [SettingsUISection(TabAccident, AccidentStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(AccidentHideDeliveryTruck))]
        public string AccidentDeliveryTruckText => InvolvedStats.FormatCount(InvolvedKind.DeliveryTruck);

        public bool AccidentHideDeliveryTruck => InvolvedStats.IsZero(InvolvedKind.DeliveryTruck);

        [SettingsUISection(TabAccident, AccidentStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(AccidentHideGarbageTruck))]
        public string AccidentGarbageTruckText => InvolvedStats.FormatCount(InvolvedKind.GarbageTruck);

        public bool AccidentHideGarbageTruck => InvolvedStats.IsZero(InvolvedKind.GarbageTruck);

        [SettingsUISection(TabAccident, AccidentStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(AccidentHideCargoTruck))]
        public string AccidentCargoTruckText => InvolvedStats.FormatCount(InvolvedKind.CargoTruck);

        public bool AccidentHideCargoTruck => InvolvedStats.IsZero(InvolvedKind.CargoTruck);

        [SettingsUISection(TabAccident, AccidentStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(AccidentHideRoadMaintenance))]
        public string AccidentRoadMaintenanceText => InvolvedStats.FormatCount(InvolvedKind.RoadMaintenance);

        public bool AccidentHideRoadMaintenance => InvolvedStats.IsZero(InvolvedKind.RoadMaintenance);

        [SettingsUISection(TabAccident, AccidentStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(AccidentHideParkMaintenance))]
        public string AccidentParkMaintenanceText => InvolvedStats.FormatCount(InvolvedKind.ParkMaintenance);

        public bool AccidentHideParkMaintenance => InvolvedStats.IsZero(InvolvedKind.ParkMaintenance);

        [SettingsUISection(TabAccident, AccidentStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(AccidentHideMaintenance))]
        public string AccidentMaintenanceText => InvolvedStats.FormatCount(InvolvedKind.Maintenance);

        public bool AccidentHideMaintenance => InvolvedStats.IsZero(InvolvedKind.Maintenance);

        [SettingsUISection(TabAccident, AccidentStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(AccidentHideFireEngine))]
        public string AccidentFireEngineText => InvolvedStats.FormatCount(InvolvedKind.FireEngine);

        public bool AccidentHideFireEngine => InvolvedStats.IsZero(InvolvedKind.FireEngine);

        [SettingsUISection(TabAccident, AccidentStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(AccidentHidePoliceCar))]
        public string AccidentPoliceCarText => InvolvedStats.FormatCount(InvolvedKind.PoliceCar);

        public bool AccidentHidePoliceCar => InvolvedStats.IsZero(InvolvedKind.PoliceCar);

        [SettingsUISection(TabAccident, AccidentStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(AccidentHidePostVan))]
        public string AccidentPostVanText => InvolvedStats.FormatCount(InvolvedKind.PostVan);

        public bool AccidentHidePostVan => InvolvedStats.IsZero(InvolvedKind.PostVan);

        [SettingsUISection(TabAccident, AccidentStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(AccidentHideAmbulance))]
        public string AccidentAmbulanceText => InvolvedStats.FormatCount(InvolvedKind.Ambulance);

        public bool AccidentHideAmbulance => InvolvedStats.IsZero(InvolvedKind.Ambulance);

        [SettingsUISection(TabAccident, AccidentStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(AccidentHideHearse))]
        public string AccidentHearseText => InvolvedStats.FormatCount(InvolvedKind.Hearse);

        public bool AccidentHideHearse => InvolvedStats.IsZero(InvolvedKind.Hearse);

        [SettingsUISection(TabAccident, AccidentStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(AccidentHidePrisonerTransport))]
        public string AccidentPrisonerTransportText => InvolvedStats.FormatCount(InvolvedKind.PrisonerTransport);

        public bool AccidentHidePrisonerTransport => InvolvedStats.IsZero(InvolvedKind.PrisonerTransport);

        [SettingsUISection(TabAccident, AccidentStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(AccidentHideEvacuation))]
        public string AccidentEvacuationText => InvolvedStats.FormatCount(InvolvedKind.Evacuation);

        public bool AccidentHideEvacuation => InvolvedStats.IsZero(InvolvedKind.Evacuation);

        [SettingsUISection(TabAccident, AccidentStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(AccidentHideTaxi))]
        public string AccidentTaxiText => InvolvedStats.FormatCount(InvolvedKind.Taxi);

        public bool AccidentHideTaxi => InvolvedStats.IsZero(InvolvedKind.Taxi);

        [SettingsUISection(TabAccident, AccidentStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(AccidentHideTransit))]
        public string AccidentTransitText => InvolvedStats.FormatCount(InvolvedKind.Transit);

        public bool AccidentHideTransit => InvolvedStats.IsZero(InvolvedKind.Transit);

        [SettingsUISection(TabAccident, AccidentStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(AccidentHidePassengerTrain))]
        public string AccidentPassengerTrainText => InvolvedStats.FormatCount(InvolvedKind.PassengerTrain);

        public bool AccidentHidePassengerTrain => InvolvedStats.IsZero(InvolvedKind.PassengerTrain);

        [SettingsUISection(TabAccident, AccidentStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(AccidentHideCargoTrain))]
        public string AccidentCargoTrainText => InvolvedStats.FormatCount(InvolvedKind.CargoTrain);

        public bool AccidentHideCargoTrain => InvolvedStats.IsZero(InvolvedKind.CargoTrain);

        [SettingsUISection(TabAccident, AccidentStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(AccidentHideTrain))]
        public string AccidentTrainText => InvolvedStats.FormatCount(InvolvedKind.Train);

        public bool AccidentHideTrain => InvolvedStats.IsZero(InvolvedKind.Train);

        [SettingsUISection(TabAccident, AccidentStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(AccidentHideAirplane))]
        public string AccidentAirplaneText => InvolvedStats.FormatCount(InvolvedKind.Airplane);

        public bool AccidentHideAirplane => InvolvedStats.IsZero(InvolvedKind.Airplane);

        [SettingsUISection(TabAccident, AccidentStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(AccidentHideHelicopter))]
        public string AccidentHelicopterText => InvolvedStats.FormatCount(InvolvedKind.Helicopter);

        public bool AccidentHideHelicopter => InvolvedStats.IsZero(InvolvedKind.Helicopter);

        [SettingsUISection(TabAccident, AccidentStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(AccidentHideAircraft))]
        public string AccidentAircraftText => InvolvedStats.FormatCount(InvolvedKind.Aircraft);

        public bool AccidentHideAircraft => InvolvedStats.IsZero(InvolvedKind.Aircraft);

        [SettingsUISection(TabAccident, AccidentStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(AccidentHideWatercraft))]
        public string AccidentWatercraftText => InvolvedStats.FormatCount(InvolvedKind.Watercraft);

        public bool AccidentHideWatercraft => InvolvedStats.IsZero(InvolvedKind.Watercraft);

        [SettingsUISection(TabAccident, AccidentStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(AccidentHideBicycle))]
        public string AccidentBicycleText => InvolvedStats.FormatCount(InvolvedKind.Bicycle);

        public bool AccidentHideBicycle => InvolvedStats.IsZero(InvolvedKind.Bicycle);

        [SettingsUISection(TabAccident, AccidentStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(AccidentHidePedestrian))]
        public string AccidentPedestrianText => InvolvedStats.FormatCount(InvolvedKind.Pedestrian);

        public bool AccidentHidePedestrian => InvolvedStats.IsZero(InvolvedKind.Pedestrian);

        [SettingsUISection(TabAccident, AccidentStatsGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(AccidentHideOther))]
        public string AccidentOtherText => InvolvedStats.FormatCount(InvolvedKind.Other);

        public bool AccidentHideOther => InvolvedStats.IsZero(InvolvedKind.Other);

        [SettingsUISection(TabAccident, AccidentRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        public string AccidentRateText => InvolvedStats.FormatRate();

        [SettingsUISection(TabAccident, AccidentRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(AccidentHideCar))]
        public string AccidentCarRateText => InvolvedStats.FormatKindRate(InvolvedKind.Car);

        [SettingsUISection(TabAccident, AccidentRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(AccidentHideDeliveryTruck))]
        public string AccidentDeliveryTruckRateText => InvolvedStats.FormatKindRate(InvolvedKind.DeliveryTruck);

        [SettingsUISection(TabAccident, AccidentRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(AccidentHideGarbageTruck))]
        public string AccidentGarbageTruckRateText => InvolvedStats.FormatKindRate(InvolvedKind.GarbageTruck);

        [SettingsUISection(TabAccident, AccidentRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(AccidentHideCargoTruck))]
        public string AccidentCargoTruckRateText => InvolvedStats.FormatKindRate(InvolvedKind.CargoTruck);

        [SettingsUISection(TabAccident, AccidentRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(AccidentHideRoadMaintenance))]
        public string AccidentRoadMaintenanceRateText => InvolvedStats.FormatKindRate(InvolvedKind.RoadMaintenance);

        [SettingsUISection(TabAccident, AccidentRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(AccidentHideParkMaintenance))]
        public string AccidentParkMaintenanceRateText => InvolvedStats.FormatKindRate(InvolvedKind.ParkMaintenance);

        [SettingsUISection(TabAccident, AccidentRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(AccidentHideMaintenance))]
        public string AccidentMaintenanceRateText => InvolvedStats.FormatKindRate(InvolvedKind.Maintenance);

        [SettingsUISection(TabAccident, AccidentRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(AccidentHideFireEngine))]
        public string AccidentFireEngineRateText => InvolvedStats.FormatKindRate(InvolvedKind.FireEngine);

        [SettingsUISection(TabAccident, AccidentRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(AccidentHidePoliceCar))]
        public string AccidentPoliceCarRateText => InvolvedStats.FormatKindRate(InvolvedKind.PoliceCar);

        [SettingsUISection(TabAccident, AccidentRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(AccidentHidePostVan))]
        public string AccidentPostVanRateText => InvolvedStats.FormatKindRate(InvolvedKind.PostVan);

        [SettingsUISection(TabAccident, AccidentRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(AccidentHideAmbulance))]
        public string AccidentAmbulanceRateText => InvolvedStats.FormatKindRate(InvolvedKind.Ambulance);

        [SettingsUISection(TabAccident, AccidentRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(AccidentHideHearse))]
        public string AccidentHearseRateText => InvolvedStats.FormatKindRate(InvolvedKind.Hearse);

        [SettingsUISection(TabAccident, AccidentRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(AccidentHidePrisonerTransport))]
        public string AccidentPrisonerTransportRateText => InvolvedStats.FormatKindRate(InvolvedKind.PrisonerTransport);

        [SettingsUISection(TabAccident, AccidentRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(AccidentHideEvacuation))]
        public string AccidentEvacuationRateText => InvolvedStats.FormatKindRate(InvolvedKind.Evacuation);

        [SettingsUISection(TabAccident, AccidentRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(AccidentHideTaxi))]
        public string AccidentTaxiRateText => InvolvedStats.FormatKindRate(InvolvedKind.Taxi);

        [SettingsUISection(TabAccident, AccidentRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(AccidentHideTransit))]
        public string AccidentTransitRateText => InvolvedStats.FormatKindRate(InvolvedKind.Transit);

        [SettingsUISection(TabAccident, AccidentRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(AccidentHidePassengerTrain))]
        public string AccidentPassengerTrainRateText => InvolvedStats.FormatKindRate(InvolvedKind.PassengerTrain);

        [SettingsUISection(TabAccident, AccidentRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(AccidentHideCargoTrain))]
        public string AccidentCargoTrainRateText => InvolvedStats.FormatKindRate(InvolvedKind.CargoTrain);

        [SettingsUISection(TabAccident, AccidentRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(AccidentHideTrain))]
        public string AccidentTrainRateText => InvolvedStats.FormatKindRate(InvolvedKind.Train);

        [SettingsUISection(TabAccident, AccidentRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(AccidentHideAirplane))]
        public string AccidentAirplaneRateText => InvolvedStats.FormatKindRate(InvolvedKind.Airplane);

        [SettingsUISection(TabAccident, AccidentRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(AccidentHideHelicopter))]
        public string AccidentHelicopterRateText => InvolvedStats.FormatKindRate(InvolvedKind.Helicopter);

        [SettingsUISection(TabAccident, AccidentRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(AccidentHideAircraft))]
        public string AccidentAircraftRateText => InvolvedStats.FormatKindRate(InvolvedKind.Aircraft);

        [SettingsUISection(TabAccident, AccidentRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(AccidentHideWatercraft))]
        public string AccidentWatercraftRateText => InvolvedStats.FormatKindRate(InvolvedKind.Watercraft);

        [SettingsUISection(TabAccident, AccidentRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(AccidentHideBicycle))]
        public string AccidentBicycleRateText => InvolvedStats.FormatKindRate(InvolvedKind.Bicycle);

        [SettingsUISection(TabAccident, AccidentRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(AccidentHidePedestrian))]
        public string AccidentPedestrianRateText => InvolvedStats.FormatKindRate(InvolvedKind.Pedestrian);

        [SettingsUISection(TabAccident, AccidentRateGroup)]
        [SettingsUIValueVersion(typeof(Setting), nameof(AccidentGetUiVersion))]
        [SettingsUIHideByCondition(typeof(Setting), nameof(AccidentHideOther))]
        public string AccidentOtherRateText => InvolvedStats.FormatKindRate(InvolvedKind.Other);

        /// <summary>
        /// Zeroes the counters and restarts the in-game hour. Objects already involved
        /// are stamped as seen so only a later involvement increments the count.
        /// </summary>
        [SettingsUISection(TabAccident, AccidentRateGroup)]
        [SettingsUIButton]
        [SettingsUIConfirmation]
        public bool AccidentResetStats
        {
            set
            {
                InvolvedStats.RequestReset();
                TrafficUtils.Mod.AccidentLog?.Info("Accident statistics reset. Counting restarts from zero.");
            }
        }
    }
}
