namespace JamThreshold
{
    using Setting = TrafficUtils.Setting;
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// AI-generated Options strings from the English meaning. Keys match <see cref="LocaleEN"/>.
    /// </summary>
    public class LocaleES : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleES(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                { m_Setting.GetSettingsLocaleID(), "Jam Threshold" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamToggleGroup), "Reemplazo" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamThresholdGroup), "Umbrales" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamStatsGroup), "Estadísticas" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamRateGroup), "Ritmo" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamVanillaGroup), "Vanilla" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamDebugGroup), "Debug" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamEnabled)), "Activado" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.JamEnabled)), "Si está activado, la comprobación original de atasco del juego se apaga y este reemplazo usa los deslizadores de abajo. Si está desactivado, vuelve el comportamiento vanilla. Esto no reinicia todo el tráfico." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChainDepth)), "Profundidad de cadena" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ChainDepth)), "Una cadena de vehículos bloqueados se marca como atascada si es un bucle o es más larga que este valor. Vanilla es 100. Predeterminado 40 para que los atascos más cortos empiecen a desaparecer." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MaxStuckSpeed)), "Umbral de velocidad" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.MaxStuckSpeed)), "Byte de velocidad de Blocker en crudo (~0,2 m/s por unidad). El recorrido de la cadena se detiene si algún vehículo está en este valor o por encima. Vanilla 6 es unos 1,2 m/s." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ClearedText)), "Despejados en esta sesión" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ClearedText)), "Objetos que este reemplazo marcó como atascados desde que se cargó la ciudad. Los pasajeros que van en un vehículo se cuentan una vez, a través del vehículo. Vuelve a abrir esta página si los números parecen desactualizados." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamRateText)), "Todos los objetos" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.JamRateText)), "Objetos despejados por hora del juego, no por hora real. El tiempo en pausa no cuenta. Se muestra cuando ha pasado suficiente tiempo de juego." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCarText)), "Coches" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamDeliveryTruckText)), "Camiones de reparto" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamGarbageTruckText)), "Camiones de basura" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCargoTruckText)), "Camiones de carga" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamRoadMaintenanceText)), "Mantenimiento de carreteras" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamParkMaintenanceText)), "Mantenimiento de parques" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamMaintenanceText)), "Vehículos de mantenimiento" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamFireEngineText)), "Camiones de bomberos" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPoliceCarText)), "Coches de policía" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPostVanText)), "Furgonetas de correos" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAmbulanceText)), "Ambulancias" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamHearseText)), "Coches fúnebres" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPrisonerTransportText)), "Transporte de presos" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamEvacuationText)), "Vehículos de evacuación" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTaxiText)), "Taxis" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTransitText)), "Transporte" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPassengerTrainText)), "Trenes de pasajeros" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCargoTrainText)), "Trenes de carga" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTrainText)), "Trenes" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAirplaneText)), "Aviones" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamHelicopterText)), "Helicópteros" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAircraftText)), "Aeronaves" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamWatercraftText)), "Embarcaciones" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamBicycleText)), "Bicicletas" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPedestrianText)), "Peatones" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamOtherText)), "Otros" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCarRateText)), "Coches" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamDeliveryTruckRateText)), "Camiones de reparto" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamGarbageTruckRateText)), "Camiones de basura" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCargoTruckRateText)), "Camiones de carga" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamRoadMaintenanceRateText)), "Mantenimiento de carreteras" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamParkMaintenanceRateText)), "Mantenimiento de parques" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamMaintenanceRateText)), "Vehículos de mantenimiento" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamFireEngineRateText)), "Camiones de bomberos" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPoliceCarRateText)), "Coches de policía" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPostVanRateText)), "Furgonetas de correos" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAmbulanceRateText)), "Ambulancias" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamHearseRateText)), "Coches fúnebres" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPrisonerTransportRateText)), "Transporte de presos" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamEvacuationRateText)), "Vehículos de evacuación" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTaxiRateText)), "Taxis" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTransitRateText)), "Transporte" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPassengerTrainRateText)), "Trenes de pasajeros" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCargoTrainRateText)), "Trenes de carga" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTrainRateText)), "Trenes" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAirplaneRateText)), "Aviones" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamHelicopterRateText)), "Helicópteros" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAircraftRateText)), "Aeronaves" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamWatercraftRateText)), "Embarcaciones" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamBicycleRateText)), "Bicicletas" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPedestrianRateText)), "Peatones" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamOtherRateText)), "Otros" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamResetStats)), "Restablecer estadísticas" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.JamResetStats)), "Pone todos los contadores a cero y reinicia la medición de horas del juego. No cambia tus umbrales y no elimina vehículos." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.JamResetStats)), "¿Poner las estadísticas a cero? Esto solo borra los contadores. Tus umbrales y el tráfico de tu ciudad no se tocan." },
                { ClearanceStats.ClearedId, "{TOTAL} objetos" },
                { ClearanceStats.RateId, "~{RATE} objetos / hora del juego" },
                { ClearanceStats.KindRateId, "~{RATE} / hora del juego" },
                { ClearanceStats.RateUnknownId, "—" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamEnableDebugging)), "Debugging" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.JamEnableDebugging)), "Registros detallados de atasco en Mods_JamThreshold.log. Ralentiza el juego mientras está activo. Apágalo para velocidad normal." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "Restablecer a vanilla" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)), "Desactiva este reemplazo y usa la comprobación original del juego (cadena 100, velocidad 6). No elimina el tráfico de toda la ciudad. Tus deslizadores se conservan si vuelves a activar el reemplazo." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetToVanilla)), "¿Usar la comprobación original de atasco del juego? Los atascos cortos volverán a quedarse quietos hasta que reactives esta mod. Esto no elimina vehículos." },
            };
        }

        public void Unload()
        {
            // IDictionarySource requires Unload; Colossal keeps the source for the session.
        }
    }
}
