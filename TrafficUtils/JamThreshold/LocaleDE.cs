namespace JamThreshold
{
    using Setting = TrafficUtils.Setting;
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// German Options strings. Keys match <see cref="LocaleEN"/> so all languages bind to the
    /// same <see cref="Setting"/> properties.
    /// </summary>
    public class LocaleDE : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleDE(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                { m_Setting.GetSettingsLocaleID(), "Jam Threshold" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamToggleGroup), "Ersatz" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamThresholdGroup), "Schwellen" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamStatsGroup), "Statistik" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamRateGroup), "Rate" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamVanillaGroup), "Vanilla" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamDebugGroup), "Debug" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamEnabled)), "Aktiv" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.JamEnabled)), "Wenn an, ist die originale Feststeck-Prüfung des Spiels aus und dieser Ersatz läuft mit den Schiebern darunter. Wenn aus, gilt wieder Vanilla. Das setzt nicht den ganzen Verkehr zurück." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChainDepth)), "Kettentiefe" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ChainDepth)), "Eine Kette blockierter Fahrzeuge gilt als feststeckend, wenn sie eine Schleife ist oder länger als dieser Wert. Vanilla ist 100. Standard 40, damit kürzere Staus despawnen." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MaxStuckSpeed)), "Geschwindigkeitsschwelle" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.MaxStuckSpeed)), "Roher Blocker-Geschwindigkeitsbyte (~0,2 m/s pro Einheit). Der Kettenlauf stoppt, wenn ein Fahrzeug darauf oder darüber liegt. Vanilla 6 sind etwa 1,2 m/s." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ClearedText)), "In dieser Sitzung geräumt" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ClearedText)), "Objekte, die dieser Ersatz seit dem Laden der Stadt als feststeckend markiert hat. Mitfahrende in einem Fahrzeug werden einmal gezählt, über das Fahrzeug. Seite neu öffnen, falls die Zahlen veraltet aussehen." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamRateText)), "Alle Objekte" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.JamRateText)), "Geräumte Objekte pro Spielstunde, nicht pro echter Stunde. Pausierte Zeit zählt nicht. Wird angezeigt, sobald genug Spielzeit vergangen ist." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCarText)), "Autos" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamDeliveryTruckText)), "Lieferwagen" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamGarbageTruckText)), "Müllwagen" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCargoTruckText)), "Fracht-Lkw" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamRoadMaintenanceText)), "Straßenwartung" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamParkMaintenanceText)), "Parkwartung" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamMaintenanceText)), "Wartungsfahrzeuge" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamFireEngineText)), "Feuerwehr" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPoliceCarText)), "Polizeiwagen" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPostVanText)), "Postwagen" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAmbulanceText)), "Krankenwagen" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamHearseText)), "Leichenwagen" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPrisonerTransportText)), "Gefangenentransport" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamEvacuationText)), "Evakuierungsfahrzeuge" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTaxiText)), "Taxis" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTransitText)), "ÖPNV" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPassengerTrainText)), "Personenzüge" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCargoTrainText)), "Güterzüge" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTrainText)), "Züge" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAirplaneText)), "Flugzeuge" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamHelicopterText)), "Hubschrauber" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAircraftText)), "Luftfahrzeuge" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamWatercraftText)), "Wasserfahrzeuge" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamBicycleText)), "Fahrräder" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPedestrianText)), "Fußgänger" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamOtherText)), "Sonstige" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCarRateText)), "Autos" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamDeliveryTruckRateText)), "Lieferwagen" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamGarbageTruckRateText)), "Müllwagen" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCargoTruckRateText)), "Fracht-Lkw" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamRoadMaintenanceRateText)), "Straßenwartung" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamParkMaintenanceRateText)), "Parkwartung" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamMaintenanceRateText)), "Wartungsfahrzeuge" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamFireEngineRateText)), "Feuerwehr" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPoliceCarRateText)), "Polizeiwagen" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPostVanRateText)), "Postwagen" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAmbulanceRateText)), "Krankenwagen" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamHearseRateText)), "Leichenwagen" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPrisonerTransportRateText)), "Gefangenentransport" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamEvacuationRateText)), "Evakuierungsfahrzeuge" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTaxiRateText)), "Taxis" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTransitRateText)), "ÖPNV" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPassengerTrainRateText)), "Personenzüge" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCargoTrainRateText)), "Güterzüge" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTrainRateText)), "Züge" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAirplaneRateText)), "Flugzeuge" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamHelicopterRateText)), "Hubschrauber" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAircraftRateText)), "Luftfahrzeuge" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamWatercraftRateText)), "Wasserfahrzeuge" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamBicycleRateText)), "Fahrräder" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPedestrianRateText)), "Fußgänger" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamOtherRateText)), "Sonstige" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamResetStats)), "Statistik zurücksetzen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.JamResetStats)), "Setzt alle Zähler auf null und startet die Messung der Spielstunden neu. Ändert deine Schwellen nicht und entfernt keine Fahrzeuge." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.JamResetStats)), "Die Statistik auf null zurücksetzen? Das leert nur die Zähler. Deine Schwellen und der Verkehr in deiner Stadt bleiben unberührt." },
                { ClearanceStats.ClearedId, "{TOTAL} Objekte" },
                { ClearanceStats.RateId, "~{RATE} Objekte / Spielstunde" },
                { ClearanceStats.KindRateId, "~{RATE} / Spielstunde" },
                { ClearanceStats.RateUnknownId, "—" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamEnableDebugging)), "Debugging" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.JamEnableDebugging)), "Ausführliche Feststeck-Logs in Mods_JamThreshold.log. Bremst das Spiel, solange an. Für normale Geschwindigkeit aus." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "Auf Vanilla zurücksetzen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)), "Schaltet diesen Ersatz aus und nutzt die originale Feststeck-Prüfung des Spiels (Kette 100, Tempo 6). Entfernt keinen Verkehr stadtweit. Deine Schieber bleiben, wenn du den Ersatz wieder einschaltest." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetToVanilla)), "Die originale Feststeck-Prüfung des Spiels nutzen? Kurze Staus bleiben dann wieder sitzen, bis du die Mod wieder aktivierst. Es werden keine Fahrzeuge entfernt." },
            };
        }

        public void Unload()
        {
            // IDictionarySource requires Unload; Colossal keeps the source for the session.
        }
    }
}
