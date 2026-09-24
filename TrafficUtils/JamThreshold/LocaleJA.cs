namespace JamThreshold
{
    using Setting = TrafficUtils.Setting;
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// AI-generated Options strings from the English meaning. Keys match <see cref="LocaleEN"/>.
    /// </summary>
    public class LocaleJA : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleJA(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                { m_Setting.GetSettingsLocaleID(), "Jam Threshold" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamToggleGroup), "置換" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamThresholdGroup), "しきい値" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamStatsGroup), "統計" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamRateGroup), "ペース" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamVanillaGroup), "Vanilla" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamDebugGroup), "Debug" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamEnabled)), "有効" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.JamEnabled)), "オンのとき、ゲーム本来の立ち往生判定はオフになり、下のスライダーでこの置換が動きます。オフのとき、バニラの動作に戻ります。交通全体はリセットしません。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChainDepth)), "チェーンの深さ" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ChainDepth)), "塞がれた車両の連鎖は、ループであるか、この値より長い場合に立ち往生と判定されます。バニラは 100。既定 40 で、より短い渋滞から消滅し始めます。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MaxStuckSpeed)), "速度しきい値" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.MaxStuckSpeed)), "Blocker の生の速度バイト（1 単位あたり約 0.2 m/s）。いずれかの車両がこの値以上なら連鎖の走査は止まります。バニラの 6 は約 1.2 m/s です。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ClearedText)), "このセッションで解消" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ClearedText)), "街を読み込んでから、この置換が立ち往生と判定したオブジェクトの数です。車両に乗っている人は、その車両として一度だけ数えます。数値が古く見える場合は、このページを開き直してください。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamRateText)), "すべてのオブジェクト" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.JamRateText)), "ゲーム内1時間あたりの解消オブジェクト数で、実時間あたりではありません。一時停止中は進みません。ゲーム内時間が十分に経つと表示されます。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCarText)), "乗用車" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamDeliveryTruckText)), "配送トラック" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamGarbageTruckText)), "ゴミ収集車" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCargoTruckText)), "貨物トラック" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamRoadMaintenanceText)), "道路維持" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamParkMaintenanceText)), "公園維持" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamMaintenanceText)), "維持車両" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamFireEngineText)), "消防車" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPoliceCarText)), "パトカー" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPostVanText)), "郵便バン" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAmbulanceText)), "救急車" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamHearseText)), "霊柩車" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPrisonerTransportText)), "囚人輸送" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamEvacuationText)), "避難車両" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTaxiText)), "タクシー" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTransitText)), "公共交通" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPassengerTrainText)), "旅客列車" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCargoTrainText)), "貨物列車" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTrainText)), "列車" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAirplaneText)), "飛行機" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamHelicopterText)), "ヘリコプター" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAircraftText)), "航空機" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamWatercraftText)), "船舶" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamBicycleText)), "自転車" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPedestrianText)), "歩行者" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamOtherText)), "その他" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCarRateText)), "乗用車" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamDeliveryTruckRateText)), "配送トラック" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamGarbageTruckRateText)), "ゴミ収集車" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCargoTruckRateText)), "貨物トラック" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamRoadMaintenanceRateText)), "道路維持" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamParkMaintenanceRateText)), "公園維持" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamMaintenanceRateText)), "維持車両" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamFireEngineRateText)), "消防車" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPoliceCarRateText)), "パトカー" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPostVanRateText)), "郵便バン" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAmbulanceRateText)), "救急車" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamHearseRateText)), "霊柩車" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPrisonerTransportRateText)), "囚人輸送" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamEvacuationRateText)), "避難車両" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTaxiRateText)), "タクシー" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTransitRateText)), "公共交通" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPassengerTrainRateText)), "旅客列車" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCargoTrainRateText)), "貨物列車" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTrainRateText)), "列車" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAirplaneRateText)), "飛行機" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamHelicopterRateText)), "ヘリコプター" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAircraftRateText)), "航空機" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamWatercraftRateText)), "船舶" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamBicycleRateText)), "自転車" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPedestrianRateText)), "歩行者" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamOtherRateText)), "その他" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamResetStats)), "統計をリセット" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.JamResetStats)), "すべてのカウンターをゼロに戻し、ゲーム内時間の計測をやり直します。しきい値は変わらず、車両も削除されません。" },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.JamResetStats)), "統計をゼロに戻しますか？ カウンターを消すだけで、しきい値や街の交通はそのままです。" },
                { ClearanceStats.ClearedId, "{TOTAL} 個" },
                { ClearanceStats.RateId, "約 {RATE} 個 / ゲーム内1時間" },
                { ClearanceStats.KindRateId, "約 {RATE} / ゲーム内1時間" },
                { ClearanceStats.RateUnknownId, "—" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamEnableDebugging)), "Debugging" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.JamEnableDebugging)), "Mods_JamThreshold.logに詳細な立ち往生ログを書き込みます。オンの間はゲームが遅くなります。通常速度にするにはオフにしてください。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "バニラに戻す" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)), "この置換をオフにし、ゲーム本来の立ち往生判定（チェーン 100、速度 6）を使います。街全体の交通は消しません。再び有効にするとスライダーはそのままです。" },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetToVanilla)), "ゲーム本来の立ち往生判定を使いますか？ この Mod を再び有効にするまで、短い渋滞はまた残り続けます。車両は削除されません。" },
            };
        }

        public void Unload()
        {
            // IDictionarySource requires Unload; Colossal keeps the source for the session.
        }
    }
}
