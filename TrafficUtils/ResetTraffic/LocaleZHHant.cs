namespace ResetTraffic
{
    using Setting = TrafficUtils.Setting;
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// AI-generated Options strings from the English meaning. Keys match <see cref="LocaleEN"/>.
    /// </summary>
    public class LocaleZHHant : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleZHHant(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                { m_Setting.GetSettingsLocaleID(), "Reset Traffic" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetVehicles)), "重設所選" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetVehicles)), "一次性：移除目前存在的已勾選類型。之後新生成的交通不會被處理。關閉選項，然後將速度設為 1。" },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetVehicles)), "要重設目前存在的已勾選車輛和行人嗎？之後新生成的交通不會被移除。關閉選項，然後將速度設為 1。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ProgressText)), "狀態" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ProgressText)), "閒置或進行中，以及剩餘 / 已移除 / 快照。若重設期間該行未重新整理，請重新開啟選項。" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetActionGroup), "Reset" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetFeedbackGroup), "意見回饋" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetDefaultsGroup), "預設值" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetMovingGroup), "行駛中的車輛和行人" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetParkedGroup), "停放" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetPaceGroup), "節奏" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetDebugGroup), "Debug" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingCars)), "汽車" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingCars)), "正在行駛的私人汽車。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingBicycles)), "自行車" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingBicycles)), "正在移動的自行車。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingTrains)), "列車" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingTrains)), "正在行駛的列車和捷運。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingPublicTransport)), "大眾運輸" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingPublicTransport)), "正在行駛的公車、計程車及其他大眾運輸（不含列車）。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingTrucks)), "貨車與公務車" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingTrucks)), "配送貨車、垃圾車、警察、消防、郵政、救護車等。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingOther)), "飛機與船舶" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingOther)), "正在移動的飛機、直升機和船隻。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemovePedestrians)), "行人" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemovePedestrians)), "步行中的 Cims。預設關閉。已在車內的人不會被選中。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveParkedCars)), "停放的汽車" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveParkedCars)), "停車場、路邊和建築車庫中的汽車（含公務與車隊車輛）。預設開啟。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveParkedBicycles)), "停放的自行車" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveParkedBicycles)), "靜止的自行車。預設開啟。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveParkedTrains)), "停放的列車" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveParkedTrains)), "停在車場或編組場的列車。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveParkedOther)), "其他停放" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveParkedOther)), "其他停放的載具（碼頭的船、登機門的飛機等）。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VehiclesPerFrame)), "每幀實體數" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VehiclesPerFrame)), "每批移除多少實體（1–64）。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FrameInterval)), "批次間額外幀" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.FrameInterval)), "每批之後額外等待多少顯示幀。0 = 每幀，4 ≈ 約慢四倍。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetEnableDebugging)), "Debugging" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetEnableDebugging)), "在 Mods_ResetTraffic.log 寫入詳細重設紀錄。開啟時會拖慢遊戲。關閉以恢復正常速度。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetModSettings)), "恢復預設值" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetModSettings)), "將類型篩選、節奏滑桿和偵錯恢復為原始值。不會清除交通。" },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetModSettings)), "要將類型篩選、節奏滑桿和偵錯恢復為預設值嗎？這不會清除交通。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JoinDiscord)), "加入 Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.JoinDiscord)), "會在遊戲之外的網頁瀏覽器中開啟邀請連結。非常歡迎留言與回饋：完整重設花了多久、城市人口以及哪裡出了問題。" },
                { ResetTrafficSystem.FinishDialogTitleId, "Reset Traffic" },
                { ResetTrafficSystem.FinishDialogOkId, "OK" },
                { ResetTrafficSystem.FinishDialogCountsId, "剩餘 {REMAINING}  ·  已移除 {REMOVED}  ·  快照 {SNAPSHOT}" },
                { ResetTrafficSystem.StatusIdlePrefixId, "閒置。" },
                { ResetTrafficSystem.StatusIdleFreshId, "閒置。本次工作階段尚未執行重設。" },
                { ResetTrafficSystem.StatusRunningId, "進行中。" },
                { ResetTrafficSystem.StatusQueuedId, "已排入佇列。關閉選項，然後將速度設為 1。" },
                { ResetTrafficSystem.StatusWaitingId, "等待速度 1。" },
                { ResetTrafficSystem.StatusNoTypesId, "已略過：未勾選任何類型。" },
                { ResetTrafficSystem.StatusNothingMatchedId, "重設完成：沒有物件符合已勾選的類型。" },
                { ResetTrafficSystem.StatusSnapshotReadyId, "快照 {SNAPSHOT}。僅移除清單中的物件。" },
                { ResetTrafficSystem.StatusProgressId, "進行中：已移除 {REMOVED}，剩餘 {REMAINING}。" },
                { ResetTrafficSystem.StatusCompleteId, "重設完成：{REMOVED} 個物件。" },
            };
        }

        public void Unload()
        {
            // IDictionarySource requires Unload; Colossal keeps the source for the session.
        }
    }
}
