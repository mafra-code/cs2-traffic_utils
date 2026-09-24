namespace ResetTraffic
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
                { m_Setting.GetSettingsLocaleID(), "Reset Traffic" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetVehicles)), "重置所选" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetVehicles)), "一次性：移除当前存在的已勾选类型。之后新生成的交通不会被处理。关闭选项，然后将速度设为 1。" },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetVehicles)), "要重置当前存在的已勾选车辆和行人吗？之后新生成的交通不会被移除。关闭选项，然后将速度设为 1。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ProgressText)), "状态" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ProgressText)), "空闲或进行中，以及剩余 / 已移除 / 快照。若重置期间该行不刷新，请重新打开选项。" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetActionGroup), "Reset" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetFeedbackGroup), "反馈" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetDefaultsGroup), "默认值" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetMovingGroup), "行驶中的车辆和行人" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetParkedGroup), "停放" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetPaceGroup), "节奏" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetDebugGroup), "Debug" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingCars)), "汽车" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingCars)), "正在行驶的私家车。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingBicycles)), "自行车" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingBicycles)), "正在移动的自行车。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingTrains)), "列车" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingTrains)), "正在行驶的列车和地铁。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingPublicTransport)), "公共交通" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingPublicTransport)), "正在行驶的公交车、出租车及其他公共交通（不含列车）。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingTrucks)), "货车与公务车" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingTrucks)), "配送货车、垃圾车、警察、消防、邮政、救护车等。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingOther)), "飞机与船舶" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingOther)), "正在移动的飞机、直升机和船只。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemovePedestrians)), "行人" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemovePedestrians)), "步行中的 Cims。默认关闭。已在车内的人不会被选中。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveParkedCars)), "停放的汽车" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveParkedCars)), "停车场、路边和建筑车库中的汽车（含公务与车队车辆）。默认开启。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveParkedBicycles)), "停放的自行车" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveParkedBicycles)), "静止的自行车。默认开启。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveParkedTrains)), "停放的列车" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveParkedTrains)), "停在车场或编组场的列车。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveParkedOther)), "其他停放" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveParkedOther)), "其他停放的载具（码头的船、登机口的飞机等）。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VehiclesPerFrame)), "每帧实体数" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VehiclesPerFrame)), "每批移除多少实体（1–64）。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FrameInterval)), "批次间额外帧" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.FrameInterval)), "每批之后额外等待多少显示帧。0 = 每帧，4 ≈ 约慢四倍。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetEnableDebugging)), "Debugging" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetEnableDebugging)), "在 Mods_ResetTraffic.log 中写入详细重置日志。开启时会拖慢游戏。关闭以恢复正常速度。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetModSettings)), "恢复默认值" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetModSettings)), "将类型筛选、节奏滑块和调试恢复为原始值。不会清除交通。" },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetModSettings)), "要将类型筛选、节奏滑块和调试恢复为默认值吗？这不会清除交通。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JoinDiscord)), "加入 Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.JoinDiscord)), "会在游戏之外的网页浏览器中打开邀请链接。非常欢迎留言和反馈：完整重置花了多长时间、城市人口以及哪里出了问题。" },
                { ResetTrafficSystem.FinishDialogTitleId, "Reset Traffic" },
                { ResetTrafficSystem.FinishDialogOkId, "OK" },
                { ResetTrafficSystem.FinishDialogCountsId, "剩余 {REMAINING}  ·  已移除 {REMOVED}  ·  快照 {SNAPSHOT}" },
                { ResetTrafficSystem.StatusIdlePrefixId, "空闲。" },
                { ResetTrafficSystem.StatusIdleFreshId, "空闲。本次会话尚未执行重置。" },
                { ResetTrafficSystem.StatusRunningId, "进行中。" },
                { ResetTrafficSystem.StatusQueuedId, "已排队。关闭选项，然后将速度设为 1。" },
                { ResetTrafficSystem.StatusWaitingId, "等待速度 1。" },
                { ResetTrafficSystem.StatusNoTypesId, "已跳过：未勾选任何类型。" },
                { ResetTrafficSystem.StatusNothingMatchedId, "重置完成：没有对象匹配已勾选的类型。" },
                { ResetTrafficSystem.StatusSnapshotReadyId, "快照 {SNAPSHOT}。仅移除列表中的对象。" },
                { ResetTrafficSystem.StatusProgressId, "进行中：已移除 {REMOVED}，剩余 {REMAINING}。" },
                { ResetTrafficSystem.StatusCompleteId, "重置完成：{REMOVED} 个对象。" },
            };
        }

        public void Unload()
        {
            // IDictionarySource requires Unload; Colossal keeps the source for the session.
        }
    }
}
