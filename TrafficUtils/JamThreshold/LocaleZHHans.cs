namespace JamThreshold
{
    using Setting = TrafficUtils.Setting;
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// AI-generated Options strings from the English meaning. Keys match <see cref="LocaleEN"/>.
    /// </summary>
    public class LocaleZHHans : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleZHHans(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                { m_Setting.GetSettingsLocaleID(), "Jam Threshold" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamToggleGroup), "替代" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamThresholdGroup), "阈值" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamStatsGroup), "统计" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamRateGroup), "速率" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamVanillaGroup), "Vanilla" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamDebugGroup), "Debug" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamEnabled)), "启用" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.JamEnabled)), "开启时，游戏原来的卡住检测会关闭，此替代项按下方滑块运行。关闭时恢复原版行为。这不会重置全城交通。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChainDepth)), "链条深度" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ChainDepth)), "被堵住的车辆链如果是环，或长度超过此值，就会被标记为卡住。原版为 100。默认 40，让更短的拥堵开始消失。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MaxStuckSpeed)), "速度阈值" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.MaxStuckSpeed)), "原始 Blocker 速度字节（每单位约 0.2 m/s）。若有车辆达到或超过此值，链条遍历会停止。原版 6 约为 1.2 m/s。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ClearedText)), "本次会话已清除" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ClearedText)), "自载入城市以来，本替换判定为堵死的对象数量。车内乘客只通过车辆计一次。若数字看起来没有刷新，请重新打开本页。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamRateText)), "全部对象" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.JamRateText)), "每游戏小时清除的对象数，不是现实小时。暂停时不计。游戏时间足够后才会显示。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCarText)), "汽车" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamDeliveryTruckText)), "配送卡车" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamGarbageTruckText)), "垃圾车" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCargoTruckText)), "货运卡车" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamRoadMaintenanceText)), "道路养护" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamParkMaintenanceText)), "公园养护" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamMaintenanceText)), "养护车辆" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamFireEngineText)), "消防车" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPoliceCarText)), "警车" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPostVanText)), "邮政车" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAmbulanceText)), "救护车" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamHearseText)), "灵车" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPrisonerTransportText)), "囚犯运输" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamEvacuationText)), "疏散车辆" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTaxiText)), "出租车" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTransitText)), "公共交通" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPassengerTrainText)), "客运列车" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCargoTrainText)), "货运列车" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTrainText)), "列车" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAirplaneText)), "飞机" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamHelicopterText)), "直升机" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAircraftText)), "航空器" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamWatercraftText)), "船只" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamBicycleText)), "自行车" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPedestrianText)), "行人" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamOtherText)), "其他" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCarRateText)), "汽车" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamDeliveryTruckRateText)), "配送卡车" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamGarbageTruckRateText)), "垃圾车" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCargoTruckRateText)), "货运卡车" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamRoadMaintenanceRateText)), "道路养护" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamParkMaintenanceRateText)), "公园养护" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamMaintenanceRateText)), "养护车辆" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamFireEngineRateText)), "消防车" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPoliceCarRateText)), "警车" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPostVanRateText)), "邮政车" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAmbulanceRateText)), "救护车" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamHearseRateText)), "灵车" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPrisonerTransportRateText)), "囚犯运输" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamEvacuationRateText)), "疏散车辆" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTaxiRateText)), "出租车" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTransitRateText)), "公共交通" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPassengerTrainRateText)), "客运列车" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCargoTrainRateText)), "货运列车" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTrainRateText)), "列车" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAirplaneRateText)), "飞机" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamHelicopterRateText)), "直升机" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAircraftRateText)), "航空器" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamWatercraftRateText)), "船只" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamBicycleRateText)), "自行车" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPedestrianRateText)), "行人" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamOtherRateText)), "其他" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamResetStats)), "重置统计" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.JamResetStats)), "把所有计数器归零并重新开始游戏小时计时。不会改动你的阈值，也不会移除车辆。" },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.JamResetStats)), "要把统计归零吗？这只会清空计数器，你的阈值和城市里的交通都不受影响。" },
                { ClearanceStats.ClearedId, "{TOTAL} 个对象" },
                { ClearanceStats.RateId, "约 {RATE} 个对象 / 游戏小时" },
                { ClearanceStats.KindRateId, "约 {RATE} / 游戏小时" },
                { ClearanceStats.RateUnknownId, "—" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamEnableDebugging)), "Debugging" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.JamEnableDebugging)), "在 Mods_JamThreshold.log 中写入详细卡住日志。开启时会拖慢游戏。关闭以恢复正常速度。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "恢复原版" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)), "关闭此替代项并使用游戏原来的卡住检测（链条 100，速度 6）。不会清除全城车辆。再次启用时滑块会保留。" },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetToVanilla)), "使用游戏原来的卡住检测？在你再次启用此模组之前，短拥堵会再次一直停着。这不会移除车辆。" },
            };
        }

        public void Unload()
        {
            // IDictionarySource requires Unload; Colossal keeps the source for the session.
        }
    }
}
