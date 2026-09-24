namespace ResetTraffic
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
                { m_Setting.GetSettingsLocaleID(), "Reset Traffic" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetVehicles)), "Reimposta selezione" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetVehicles)), "Una tantum: rimuove i tipi selezionati che esistono ora. Il traffico appena spawnato non viene toccato. Chiudi Opzioni, poi imposta la velocità su 1." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetVehicles)), "Reimpostare i veicoli e i pedoni selezionati che esistono ora? Il traffico appena spawnato non verrà rimosso. Chiudi Opzioni, poi imposta la velocità su 1." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ProgressText)), "Stato" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ProgressText)), "Inattivo o in corso, più rimanenti / rimossi / istantanea. Riapri Opzioni se la riga non si aggiorna durante un reset." },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetActionGroup), "Reset" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetFeedbackGroup), "Feedback" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetDefaultsGroup), "Valori predefiniti" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetMovingGroup), "Veicoli e pedoni in movimento" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetParkedGroup), "Parcheggiati" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetPaceGroup), "Ritmo" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetDebugGroup), "Debug" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingCars)), "Auto" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingCars)), "Auto private in circolazione." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingBicycles)), "Biciclette" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingBicycles)), "Biciclette in movimento." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingTrains)), "Treni" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingTrains)), "Treni e metro in movimento." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingPublicTransport)), "Trasporto pubblico" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingPublicTransport)), "Bus, taxi e altro trasporto pubblico in movimento (non i treni)." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingTrucks)), "Camion e servizi" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingTrucks)), "Camion delle consegne, rifiuti, polizia, vigili del fuoco, poste, ambulanze e simili." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingOther)), "Aerei e imbarcazioni" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingOther)), "Aerei, elicotteri e barche in movimento." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemovePedestrians)), "Pedoni" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemovePedestrians)), "Cims a piedi. Disattivato di default. Chi è già in un veicolo non viene preso di mira." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveParkedCars)), "Auto parcheggiate" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveParkedCars)), "Auto in parcheggi, lungo il marciapiede e nei garage degli edifici (inclusi veicoli di servizio e di deposito). Attivo di default." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveParkedBicycles)), "Biciclette parcheggiate" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveParkedBicycles)), "Biciclette ferme. Attivo di default." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveParkedTrains)), "Treni parcheggiati" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveParkedTrains)), "Treni nei depositi o nei piazzali." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveParkedOther)), "Altri parcheggiati" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveParkedOther)), "Qualsiasi altro veicolo parcheggiato (barche ai moli, aerei ai gate e simili)." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VehiclesPerFrame)), "Entità per fotogramma" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VehiclesPerFrame)), "Quante entità rimuovere per lotto (1–64)." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FrameInterval)), "Fotogrammi extra tra i lotti" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.FrameInterval)), "Attendi tanti fotogrammi di visualizzazione extra dopo ogni lotto. 0 = ogni fotogramma, 4 ≈ quattro volte più lento." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetEnableDebugging)), "Debugging" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetEnableDebugging)), "Log di reset dettagliati in Mods_ResetTraffic.log. Rallenta il gioco finché è attivo. Disattiva per la velocità normale." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetModSettings)), "Ripristina valori predefiniti" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetModSettings)), "Ripristina filtri tipo, cursori di ritmo e debugging ai valori originali. Non rimuove traffico." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetModSettings)), "Ripristinare filtri tipo, cursori di ritmo e debugging ai valori predefiniti? Questo non rimuove traffico." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JoinDiscord)), "Entra nel Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.JoinDiscord)), "Apre l'invito nel tuo browser web, fuori dal gioco. Commenti e feedback sono i benvenuti: quanto è durato un reset completo, la popolazione della tua città e qualsiasi cosa si sia rotta." },
                { ResetTrafficSystem.FinishDialogTitleId, "Reset Traffic" },
                { ResetTrafficSystem.FinishDialogOkId, "OK" },
                { ResetTrafficSystem.FinishDialogCountsId, "Rimanenti {REMAINING}  ·  Rimossi {REMOVED}  ·  Istantanea {SNAPSHOT}" },
                { ResetTrafficSystem.StatusIdlePrefixId, "Inattivo." },
                { ResetTrafficSystem.StatusIdleFreshId, "Inattivo. Nessun reset finora in questa sessione." },
                { ResetTrafficSystem.StatusRunningId, "In corso." },
                { ResetTrafficSystem.StatusQueuedId, "In coda. Chiudi Opzioni, poi imposta la velocità su 1." },
                { ResetTrafficSystem.StatusWaitingId, "In attesa della velocità 1." },
                { ResetTrafficSystem.StatusNoTypesId, "Saltato: nessun tipo è selezionato." },
                { ResetTrafficSystem.StatusNothingMatchedId, "Reset completato: nulla corrispondeva ai tipi selezionati." },
                { ResetTrafficSystem.StatusSnapshotReadyId, "Istantanea {SNAPSHOT}. Vengono rimosse solo le entità elencate." },
                { ResetTrafficSystem.StatusProgressId, "In corso: {REMOVED} rimossi, {REMAINING} rimanenti." },
                { ResetTrafficSystem.StatusCompleteId, "Reset completato: {REMOVED} entità." },
            };
        }

        public void Unload()
        {
            // IDictionarySource requires Unload; Colossal keeps the source for the session.
        }
    }
}
