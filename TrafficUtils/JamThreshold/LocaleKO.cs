namespace JamThreshold
{
    using Setting = TrafficUtils.Setting;
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// AI-generated Options strings from the English meaning. Keys match <see cref="LocaleEN"/>.
    /// </summary>
    public class LocaleKO : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleKO(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                { m_Setting.GetSettingsLocaleID(), "Jam Threshold" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamToggleGroup), "대체" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamThresholdGroup), "임계값" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamStatsGroup), "통계" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamRateGroup), "속도" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamVanillaGroup), "Vanilla" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamDebugGroup), "Debug" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamEnabled)), "사용" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.JamEnabled)), "켜면 게임의 원래 정체 검사가 꺼지고 아래 슬라이더로 이 대체가 실행됩니다. 끄면 바닐라 동작으로 돌아갑니다. 도시 전체 교통은 초기화하지 않습니다." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChainDepth)), "체인 깊이" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ChainDepth)), "막힌 차량 체인은 루프이거나 이 값보다 길면 정체로 표시됩니다. 바닐라는 100입니다. 기본값 40으로 더 짧은 정체부터 사라지기 시작합니다." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MaxStuckSpeed)), "속도 임계값" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.MaxStuckSpeed)), "원시 Blocker 속도 바이트(단위당 약 0.2 m/s). 어느 차량이 이 값 이상이면 체인 탐색이 멈춥니다. 바닐라 6은 약 1.2 m/s입니다." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ClearedText)), "이번 세션 해소" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ClearedText)), "도시를 불러온 뒤 이 대체 시스템이 정체로 표시한 오브젝트 수입니다. 차량에 탑승한 사람은 차량으로 한 번만 셉니다. 숫자가 갱신되지 않은 것 같으면 이 페이지를 다시 여세요." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamRateText)), "모든 오브젝트" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.JamRateText)), "게임 내 1시간당 해소된 오브젝트 수이며, 실제 시간 기준이 아닙니다. 일시정지 중에는 늘지 않습니다. 게임 내 시간이 충분히 지나면 표시됩니다." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCarText)), "승용차" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamDeliveryTruckText)), "배송 트럭" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamGarbageTruckText)), "쓰레기 트럭" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCargoTruckText)), "화물 트럭" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamRoadMaintenanceText)), "도로 정비" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamParkMaintenanceText)), "공원 정비" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamMaintenanceText)), "정비 차량" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamFireEngineText)), "소방차" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPoliceCarText)), "경찰차" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPostVanText)), "우편 밴" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAmbulanceText)), "구급차" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamHearseText)), "영구차" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPrisonerTransportText)), "수감 수송" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamEvacuationText)), "대피 차량" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTaxiText)), "택시" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTransitText)), "대중교통" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPassengerTrainText)), "여객 열차" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCargoTrainText)), "화물 열차" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTrainText)), "열차" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAirplaneText)), "비행기" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamHelicopterText)), "헬리콥터" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAircraftText)), "항공기" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamWatercraftText)), "선박" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamBicycleText)), "자전거" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPedestrianText)), "보행자" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamOtherText)), "기타" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCarRateText)), "승용차" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamDeliveryTruckRateText)), "배송 트럭" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamGarbageTruckRateText)), "쓰레기 트럭" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCargoTruckRateText)), "화물 트럭" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamRoadMaintenanceRateText)), "도로 정비" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamParkMaintenanceRateText)), "공원 정비" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamMaintenanceRateText)), "정비 차량" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamFireEngineRateText)), "소방차" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPoliceCarRateText)), "경찰차" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPostVanRateText)), "우편 밴" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAmbulanceRateText)), "구급차" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamHearseRateText)), "영구차" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPrisonerTransportRateText)), "수감 수송" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamEvacuationRateText)), "대피 차량" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTaxiRateText)), "택시" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTransitRateText)), "대중교통" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPassengerTrainRateText)), "여객 열차" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCargoTrainRateText)), "화물 열차" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTrainRateText)), "열차" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAirplaneRateText)), "비행기" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamHelicopterRateText)), "헬리콥터" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAircraftRateText)), "항공기" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamWatercraftRateText)), "선박" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamBicycleRateText)), "자전거" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPedestrianRateText)), "보행자" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamOtherRateText)), "기타" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamResetStats)), "통계 초기화" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.JamResetStats)), "모든 카운터를 0으로 되돌리고 게임 내 시간 측정을 다시 시작합니다. 임계값은 바뀌지 않으며 차량도 제거되지 않습니다." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.JamResetStats)), "통계를 0으로 되돌릴까요? 카운터만 지워지며, 임계값과 도시의 교통은 그대로입니다." },
                { ClearanceStats.ClearedId, "{TOTAL}개" },
                { ClearanceStats.RateId, "~{RATE}개 / 게임 내 1시간" },
                { ClearanceStats.KindRateId, "~{RATE} / 게임 내 1시간" },
                { ClearanceStats.RateUnknownId, "—" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamEnableDebugging)), "Debugging" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.JamEnableDebugging)), "Mods_JamThreshold.log에 자세한 정체 로그를 기록합니다. 켜져 있으면 게임이 느려집니다. 정상 속도를 위해 끄세요." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "바닐라로 되돌리기" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)), "이 대체를 끄고 게임의 원래 정체 검사(체인 100, 속도 6)를 사용합니다. 도시 전체 교통은 제거하지 않습니다. 다시 켜면 슬라이더는 유지됩니다." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetToVanilla)), "게임의 원래 정체 검사를 사용할까요? 이 모드를 다시 켤 때까지 짧은 정체는 다시 그대로 남습니다. 차량은 제거되지 않습니다." },
            };
        }

        public void Unload()
        {
            // IDictionarySource requires Unload; Colossal keeps the source for the session.
        }
    }
}
