namespace JamThreshold
{
    using Setting = TrafficUtils.Setting;
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// AI-generated Options strings from the English meaning. Keys match <see cref="LocaleEN"/>.
    /// </summary>
    public class LocaleRU : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleRU(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                { m_Setting.GetSettingsLocaleID(), "Jam Threshold" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamToggleGroup), "Замена" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamThresholdGroup), "Пороги" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamStatsGroup), "Статистика" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamRateGroup), "Темп" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamVanillaGroup), "Vanilla" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamDebugGroup), "Debug" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamEnabled)), "Включено" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.JamEnabled)), "Если включено, оригинальная проверка затора отключается, и эта замена работает с ползунками ниже. Если выключено, возвращается поведение vanilla. Это не сбрасывает весь трафик." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChainDepth)), "Глубина цепочки" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ChainDepth)), "Цепочка заблокированных машин помечается как застрявшая, если это петля или она длиннее этого значения. Vanilla — 100. По умолчанию 40, чтобы более короткие пробки начинали исчезать." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MaxStuckSpeed)), "Порог скорости" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.MaxStuckSpeed)), "Сырой байт скорости Blocker (~0,2 м/с за единицу). Обход цепочки останавливается, если какая-то машина на этом значении или выше. Vanilla 6 — около 1,2 м/с." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ClearedText)), "Убрано за сессию" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ClearedText)), "Объекты, которые эта замена пометила как застрявшие с момента загрузки города. Пассажиры в транспорте считаются один раз — через сам транспорт. Откройте страницу заново, если числа выглядят устаревшими." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamRateText)), "Все объекты" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.JamRateText)), "Убранные объекты за игровой час, а не за реальный. Время на паузе не учитывается. Показывается, когда прошло достаточно игрового времени." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCarText)), "Автомобили" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamDeliveryTruckText)), "Грузовики доставки" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamGarbageTruckText)), "Мусоровозы" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCargoTruckText)), "Грузовые грузовики" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamRoadMaintenanceText)), "Дорожная служба" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamParkMaintenanceText)), "Обслуживание парков" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamMaintenanceText)), "Служебный транспорт" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamFireEngineText)), "Пожарные машины" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPoliceCarText)), "Полицейские машины" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPostVanText)), "Почтовые фургоны" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAmbulanceText)), "Скорые" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamHearseText)), "Катафалки" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPrisonerTransportText)), "Перевозка заключённых" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamEvacuationText)), "Эвакуационный транспорт" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTaxiText)), "Такси" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTransitText)), "Транспорт" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPassengerTrainText)), "Пассажирские поезда" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCargoTrainText)), "Грузовые поезда" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTrainText)), "Поезда" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAirplaneText)), "Самолёты" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamHelicopterText)), "Вертолёты" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAircraftText)), "Воздушные суда" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamWatercraftText)), "Суда" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamBicycleText)), "Велосипеды" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPedestrianText)), "Пешеходы" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamOtherText)), "Прочее" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCarRateText)), "Автомобили" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamDeliveryTruckRateText)), "Грузовики доставки" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamGarbageTruckRateText)), "Мусоровозы" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCargoTruckRateText)), "Грузовые грузовики" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamRoadMaintenanceRateText)), "Дорожная служба" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamParkMaintenanceRateText)), "Обслуживание парков" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamMaintenanceRateText)), "Служебный транспорт" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamFireEngineRateText)), "Пожарные машины" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPoliceCarRateText)), "Полицейские машины" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPostVanRateText)), "Почтовые фургоны" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAmbulanceRateText)), "Скорые" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamHearseRateText)), "Катафалки" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPrisonerTransportRateText)), "Перевозка заключённых" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamEvacuationRateText)), "Эвакуационный транспорт" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTaxiRateText)), "Такси" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTransitRateText)), "Транспорт" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPassengerTrainRateText)), "Пассажирские поезда" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCargoTrainRateText)), "Грузовые поезда" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTrainRateText)), "Поезда" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAirplaneRateText)), "Самолёты" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamHelicopterRateText)), "Вертолёты" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAircraftRateText)), "Воздушные суда" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamWatercraftRateText)), "Суда" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamBicycleRateText)), "Велосипеды" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPedestrianRateText)), "Пешеходы" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamOtherRateText)), "Прочее" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamResetStats)), "Сбросить статистику" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.JamResetStats)), "Обнуляет все счётчики и заново запускает отсчёт игровых часов. Не меняет пороги и не удаляет транспорт." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.JamResetStats)), "Обнулить статистику? Это очистит только счётчики. Пороги и движение в городе останутся нетронутыми." },
                { ClearanceStats.ClearedId, "{TOTAL} объектов" },
                { ClearanceStats.RateId, "~{RATE} объектов / игровой час" },
                { ClearanceStats.KindRateId, "~{RATE} / игровой час" },
                { ClearanceStats.RateUnknownId, "—" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamEnableDebugging)), "Debugging" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.JamEnableDebugging)), "Подробные журналы заторов в Mods_JamThreshold.log. Замедляет игру, пока включено. Выключите для обычной скорости." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "Сбросить к vanilla" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)), "Выключает эту замену и использует оригинальную проверку затора (цепочка 100, скорость 6). Не убирает трафик по всему городу. Ползунки сохраняются, если включить замену снова." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetToVanilla)), "Использовать оригинальную проверку затора? Короткие пробки снова останутся, пока вы не включите мод снова. Транспорт не удаляется." },
            };
        }

        public void Unload()
        {
            // IDictionarySource requires Unload; Colossal keeps the source for the session.
        }
    }
}
