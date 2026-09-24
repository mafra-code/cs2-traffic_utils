namespace JamThreshold
{
    using Setting = TrafficUtils.Setting;
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// AI-generated Options strings from the English meaning. Keys match <see cref="LocaleEN"/>.
    /// </summary>
    public class LocaleIT : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleIT(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                { m_Setting.GetSettingsLocaleID(), "Jam Threshold" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamToggleGroup), "Sostituzione" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamThresholdGroup), "Soglie" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamStatsGroup), "Statistiche" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamRateGroup), "Ritmo" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamVanillaGroup), "Vanilla" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamDebugGroup), "Debug" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamEnabled)), "Attivo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.JamEnabled)), "Quando è attivo, il controllo originale di blocco del gioco è disattivato e questa sostituzione usa i cursori sotto. Quando è disattivo, torna il comportamento vanilla. Questo non reimposta tutto il traffico." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChainDepth)), "Profondità della catena" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ChainDepth)), "Una catena di veicoli bloccati viene segnalata come bloccata se è un loop o è più lunga di questo valore. Vanilla è 100. Predefinito 40 così gli ingorghi più corti iniziano a sparire." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MaxStuckSpeed)), "Soglia di velocità" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.MaxStuckSpeed)), "Byte di velocità Blocker grezzo (~0,2 m/s per unità). Il percorso della catena si ferma se un veicolo è a questo valore o sopra. Vanilla 6 è circa 1,2 m/s." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ClearedText)), "Liberati in questa sessione" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ClearedText)), "Oggetti che questa sostituzione ha segnato come bloccati da quando è stata caricata la città. I passeggeri a bordo di un veicolo sono contati una volta, tramite il veicolo. Riapri questa pagina se i numeri sembrano fermi." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamRateText)), "Tutti gli oggetti" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.JamRateText)), "Oggetti liberati per ora di gioco, non per ora reale. Il tempo in pausa non conta. Viene mostrato quando è passato abbastanza tempo di gioco." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCarText)), "Auto" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamDeliveryTruckText)), "Furgoni delle consegne" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamGarbageTruckText)), "Camion della spazzatura" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCargoTruckText)), "Camion merci" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamRoadMaintenanceText)), "Manutenzione stradale" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamParkMaintenanceText)), "Manutenzione parchi" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamMaintenanceText)), "Veicoli di manutenzione" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamFireEngineText)), "Autopompe" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPoliceCarText)), "Auto della polizia" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPostVanText)), "Furgoni postali" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAmbulanceText)), "Ambulanze" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamHearseText)), "Carri funebri" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPrisonerTransportText)), "Trasporto detenuti" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamEvacuationText)), "Veicoli di evacuazione" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTaxiText)), "Taxi" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTransitText)), "Trasporti" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPassengerTrainText)), "Treni passeggeri" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCargoTrainText)), "Treni merci" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTrainText)), "Treni" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAirplaneText)), "Aerei" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamHelicopterText)), "Elicotteri" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAircraftText)), "Aeromobili" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamWatercraftText)), "Imbarcazioni" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamBicycleText)), "Biciclette" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPedestrianText)), "Pedoni" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamOtherText)), "Altro" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCarRateText)), "Auto" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamDeliveryTruckRateText)), "Furgoni delle consegne" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamGarbageTruckRateText)), "Camion della spazzatura" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCargoTruckRateText)), "Camion merci" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamRoadMaintenanceRateText)), "Manutenzione stradale" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamParkMaintenanceRateText)), "Manutenzione parchi" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamMaintenanceRateText)), "Veicoli di manutenzione" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamFireEngineRateText)), "Autopompe" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPoliceCarRateText)), "Auto della polizia" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPostVanRateText)), "Furgoni postali" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAmbulanceRateText)), "Ambulanze" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamHearseRateText)), "Carri funebri" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPrisonerTransportRateText)), "Trasporto detenuti" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamEvacuationRateText)), "Veicoli di evacuazione" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTaxiRateText)), "Taxi" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTransitRateText)), "Trasporti" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPassengerTrainRateText)), "Treni passeggeri" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCargoTrainRateText)), "Treni merci" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTrainRateText)), "Treni" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAirplaneRateText)), "Aerei" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamHelicopterRateText)), "Elicotteri" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAircraftRateText)), "Aeromobili" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamWatercraftRateText)), "Imbarcazioni" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamBicycleRateText)), "Biciclette" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPedestrianRateText)), "Pedoni" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamOtherRateText)), "Altro" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamResetStats)), "Azzera statistiche" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.JamResetStats)), "Riporta tutti i contatori a zero e riavvia la misura delle ore di gioco. Non cambia le tue soglie e non rimuove veicoli." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.JamResetStats)), "Azzerare le statistiche? Questo cancella solo i contatori. Le tue soglie e il traffico della città restano intatti." },
                { ClearanceStats.ClearedId, "{TOTAL} oggetti" },
                { ClearanceStats.RateId, "~{RATE} oggetti / ora di gioco" },
                { ClearanceStats.KindRateId, "~{RATE} / ora di gioco" },
                { ClearanceStats.RateUnknownId, "—" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamEnableDebugging)), "Debugging" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.JamEnableDebugging)), "Log dettagliati di blocco in Mods_JamThreshold.log. Rallenta il gioco finché è attivo. Disattiva per la velocità normale." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "Ripristina vanilla" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)), "Disattiva questa sostituzione e usa il controllo originale del gioco (catena 100, velocità 6). Non rimuove il traffico in tutta la città. I cursori restano se riattivi la sostituzione." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetToVanilla)), "Usare il controllo originale di blocco del gioco? Gli ingorghi corti resteranno di nuovo fermi finché non riattivi questa mod. Questo non rimuove veicoli." },
            };
        }

        public void Unload()
        {
            // IDictionarySource requires Unload; Colossal keeps the source for the session.
        }
    }
}
