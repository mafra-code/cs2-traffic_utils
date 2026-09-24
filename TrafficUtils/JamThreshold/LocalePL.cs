namespace JamThreshold
{
    using Setting = TrafficUtils.Setting;
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// AI-generated Options strings from the English meaning. Keys match <see cref="LocaleEN"/>.
    /// </summary>
    public class LocalePL : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocalePL(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                { m_Setting.GetSettingsLocaleID(), "Jam Threshold" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamToggleGroup), "Zamiennik" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamThresholdGroup), "Progi" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamStatsGroup), "Statystyki" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamRateGroup), "Tempo" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamVanillaGroup), "Vanilla" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamDebugGroup), "Debug" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamEnabled)), "Włączone" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.JamEnabled)), "Gdy włączone, oryginalne sprawdzanie zatorów jest wyłączone, a ten zamiennik działa z suwakami poniżej. Gdy wyłączone, wraca zachowanie vanilla. To nie resetuje całego ruchu." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChainDepth)), "Głębokość łańcucha" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ChainDepth)), "Łańcuch zablokowanych pojazdów jest oznaczany jako zablokowany, jeśli jest pętlą lub dłuższy niż ta wartość. Vanilla to 100. Domyślnie 40, żeby krótsze korki zaczynały znikać." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MaxStuckSpeed)), "Próg prędkości" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.MaxStuckSpeed)), "Surowy bajt prędkości Blocker (~0,2 m/s na jednostkę). Przechodzenie łańcucha kończy się, gdy jakiś pojazd jest na tej wartości lub powyżej. Vanilla 6 to około 1,2 m/s." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ClearedText)), "Usunięte w tej sesji" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ClearedText)), "Obiekty oznaczone jako zakorkowane przez ten zamiennik od wczytania miasta. Pasażerowie jadący pojazdem liczą się raz, przez pojazd. Otwórz tę stronę ponownie, jeśli liczby wyglądają na nieaktualne." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamRateText)), "Wszystkie obiekty" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.JamRateText)), "Obiekty usunięte na godzinę w grze, nie na godzinę rzeczywistą. Czas pauzy się nie liczy. Pojawia się, gdy minie dość czasu w grze." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCarText)), "Samochody" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamDeliveryTruckText)), "Ciężarówki dostawcze" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamGarbageTruckText)), "Śmieciarki" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCargoTruckText)), "Ciężarówki towarowe" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamRoadMaintenanceText)), "Utrzymanie dróg" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamParkMaintenanceText)), "Utrzymanie parków" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamMaintenanceText)), "Pojazdy utrzymania" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamFireEngineText)), "Wozy strażackie" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPoliceCarText)), "Radiowozy" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPostVanText)), "Furgonetki pocztowe" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAmbulanceText)), "Karetki" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamHearseText)), "Karawany" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPrisonerTransportText)), "Transport więźniów" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamEvacuationText)), "Pojazdy ewakuacyjne" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTaxiText)), "Taksówki" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTransitText)), "Transport" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPassengerTrainText)), "Pociągi pasażerskie" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCargoTrainText)), "Pociągi towarowe" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTrainText)), "Pociągi" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAirplaneText)), "Samoloty" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamHelicopterText)), "Śmigłowce" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAircraftText)), "Statki powietrzne" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamWatercraftText)), "Jednostki pływające" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamBicycleText)), "Rowery" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPedestrianText)), "Piesi" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamOtherText)), "Inne" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCarRateText)), "Samochody" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamDeliveryTruckRateText)), "Ciężarówki dostawcze" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamGarbageTruckRateText)), "Śmieciarki" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCargoTruckRateText)), "Ciężarówki towarowe" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamRoadMaintenanceRateText)), "Utrzymanie dróg" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamParkMaintenanceRateText)), "Utrzymanie parków" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamMaintenanceRateText)), "Pojazdy utrzymania" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamFireEngineRateText)), "Wozy strażackie" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPoliceCarRateText)), "Radiowozy" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPostVanRateText)), "Furgonetki pocztowe" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAmbulanceRateText)), "Karetki" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamHearseRateText)), "Karawany" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPrisonerTransportRateText)), "Transport więźniów" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamEvacuationRateText)), "Pojazdy ewakuacyjne" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTaxiRateText)), "Taksówki" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTransitRateText)), "Transport" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPassengerTrainRateText)), "Pociągi pasażerskie" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCargoTrainRateText)), "Pociągi towarowe" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTrainRateText)), "Pociągi" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAirplaneRateText)), "Samoloty" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamHelicopterRateText)), "Śmigłowce" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAircraftRateText)), "Statki powietrzne" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamWatercraftRateText)), "Jednostki pływające" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamBicycleRateText)), "Rowery" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPedestrianRateText)), "Piesi" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamOtherRateText)), "Inne" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamResetStats)), "Zresetuj statystyki" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.JamResetStats)), "Zeruje wszystkie liczniki i zaczyna pomiar godzin w grze od nowa. Nie zmienia progów i nie usuwa pojazdów." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.JamResetStats)), "Wyzerować statystyki? To czyści tylko liczniki. Twoje progi i ruch w mieście pozostają nietknięte." },
                { ClearanceStats.ClearedId, "{TOTAL} obiektów" },
                { ClearanceStats.RateId, "~{RATE} obiektów / godzinę w grze" },
                { ClearanceStats.KindRateId, "~{RATE} / godzinę w grze" },
                { ClearanceStats.RateUnknownId, "—" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamEnableDebugging)), "Debugging" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.JamEnableDebugging)), "Szczegółowe logi zatorów w Mods_JamThreshold.log. Spowalnia grę, gdy włączone. Wyłącz dla normalnej prędkości." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "Przywróć vanilla" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)), "Wyłącza ten zamiennik i używa oryginalnego sprawdzania zatorów (łańcuch 100, prędkość 6). Nie usuwa ruchu w całym mieście. Suwaki zostają, jeśli włączysz zamiennik ponownie." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetToVanilla)), "Użyć oryginalnego sprawdzania zatorów gry? Krótkie korki znów zostaną, aż ponownie włączysz ten mod. To nie usuwa pojazdów." },
            };
        }

        public void Unload()
        {
            // IDictionarySource requires Unload; Colossal keeps the source for the session.
        }
    }
}
