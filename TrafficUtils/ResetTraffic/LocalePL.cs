namespace ResetTraffic
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
                { m_Setting.GetSettingsLocaleID(), "Reset Traffic" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetVehicles)), "Zresetuj zaznaczone" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetVehicles)), "Jednorazowo: usuwa zaznaczone typy, które istnieją teraz. Nowo zespawnowany ruch zostaje. Zamknij Opcje, potem ustaw prędkość na 1." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetVehicles)), "Zresetować zaznaczone pojazdy i pieszych, które istnieją teraz? Nowo zespawnowany ruch nie zostanie usunięty. Zamknij Opcje, potem ustaw prędkość na 1." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ProgressText)), "Status" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ProgressText)), "Bezczynny lub w toku, plus pozostało / usunięto / migawka. Otwórz Opcje ponownie, jeśli wiersz nie odświeża się podczas resetu." },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetActionGroup), "Reset" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetFeedbackGroup), "Opinie" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetDefaultsGroup), "Domyślne" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetMovingGroup), "Pojazdy i piesi w ruchu" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetParkedGroup), "Zaparkowane" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetPaceGroup), "Tempo" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetKeybindingGroup), "Skrót" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetDebugGroup), "Debug" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingCars)), "Samochody" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingCars)), "Prywatne samochody jadące teraz." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingBicycles)), "Rowery" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingBicycles)), "Rowery w ruchu." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingTrains)), "Pociągi" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingTrains)), "Pociągi i metro w ruchu." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingPublicTransport)), "Transport publiczny" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingPublicTransport)), "Autobusy, taksówki i inny transport publiczny w ruchu (bez pociągów)." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingTrucks)), "Ciężarówki i służby" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingTrucks)), "Dostawczaki, śmieciarki, policja, straż, poczta, karetki i podobne." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingOther)), "Samoloty i jednostki pływające" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingOther)), "Samoloty, helikoptery i łodzie w ruchu." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemovePedestrians)), "Piesi" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemovePedestrians)), "Idący Cims. Domyślnie wyłączone. Osoby już w pojazdach nie są celem." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveParkedCars)), "Zaparkowane samochody" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveParkedCars)), "Samochody na parkingach, przy krawężniku i w garażach budynków (w tym pojazdy służb i zajezdni). Domyślnie włączone." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveParkedBicycles)), "Zaparkowane rowery" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveParkedBicycles)), "Nieruchome rowery. Domyślnie włączone." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveParkedTrains)), "Zaparkowane pociągi" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveParkedTrains)), "Pociągi w zajezdniach lub na torach odstawczych." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveParkedOther)), "Inne zaparkowane" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveParkedOther)), "Wszelkie inne zaparkowane pojazdy (łodzie przy nabrzeżach, samoloty przy bramkach i podobne)." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VehiclesPerFrame)), "Obiekty na klatkę" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VehiclesPerFrame)), "Ile obiektów usuwać w każdej partii (1–64)." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FrameInterval)), "Dodatkowe klatki między partiami" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.FrameInterval)), "Czekaj tyle dodatkowych klatek wyświetlania po każdej partii. 0 = każda klatka, 4 ≈ cztery razy wolniej." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetHotkey)), "Skrót resetu" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetHotkey)), "Klawisz kolejkuje reset bez otwierania Opcji. Domyślnie F9. Kliknij klawisz, potem naciśnij nowy, aby zmienić." },
                { m_Setting.GetBindingKeyLocaleID(nameof(Setting.ResetHotkey)), "Zresetuj zaznaczone" },
                { m_Setting.GetBindingMapLocaleID(), "Reset Traffic" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetBindings)), "Resetuj skróty" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetBindings)), "Przywraca skrót resetu na F9." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetEnableDebugging)), "Debugging" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetEnableDebugging)), "Szczegółowe logi resetu w Mods_ResetTraffic.log. Spowalnia grę, gdy włączone. Wyłącz dla normalnej prędkości." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetModSettings)), "Przywróć domyślne" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetModSettings)), "Przywraca filtry typów, suwaki tempa i debugging do oryginalnych wartości. Nie zmienia skrótu i nie usuwa ruchu." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetModSettings)), "Przywrócić filtry typów, suwaki tempa i debugging do wartości domyślnych? To nie zmienia skrótu i nie usuwa ruchu." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JoinDiscord)), "Dołącz do Discorda" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.JoinDiscord)), "Otwiera zaproszenie w przeglądarce internetowej, poza grą. Komentarze i opinie są bardzo mile widziane: napisz, ile trwał pełny reset, jaka jest populacja twojego miasta i co się zepsuło." },
                { ResetTrafficSystem.FinishDialogTitleId, "Reset Traffic" },
                { ResetTrafficSystem.FinishDialogOkId, "OK" },
                { ResetTrafficSystem.FinishDialogCountsId, "Pozostało {REMAINING}  ·  Usunięto {REMOVED}  ·  Migawka {SNAPSHOT}" },
                { ResetTrafficSystem.StatusIdlePrefixId, "Bezczynny." },
                { ResetTrafficSystem.StatusIdleFreshId, "Bezczynny. W tej sesji nie było jeszcze resetu." },
                { ResetTrafficSystem.StatusRunningId, "W toku." },
                { ResetTrafficSystem.StatusQueuedId, "W kolejce. Zamknij Opcje, potem ustaw prędkość na 1." },
                { ResetTrafficSystem.StatusWaitingId, "Oczekiwanie na prędkość 1." },
                { ResetTrafficSystem.StatusNoTypesId, "Pominięto: nie zaznaczono żadnego typu." },
                { ResetTrafficSystem.StatusNothingMatchedId, "Reset zakończony: nic nie pasowało do zaznaczonych typów." },
                { ResetTrafficSystem.StatusSnapshotReadyId, "Migawka {SNAPSHOT}. Usuwane są tylko wypisane obiekty." },
                { ResetTrafficSystem.StatusProgressId, "W toku: usunięto {REMOVED}, pozostało {REMAINING}." },
                { ResetTrafficSystem.StatusCompleteId, "Reset zakończony: {REMOVED} obiektów." },
            };
        }

        public void Unload()
        {
            // IDictionarySource requires Unload; Colossal keeps the source for the session.
        }
    }
}
