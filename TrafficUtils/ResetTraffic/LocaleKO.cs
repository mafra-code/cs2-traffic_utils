namespace ResetTraffic
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
                { m_Setting.GetSettingsLocaleID(), "Reset Traffic" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetVehicles)), "선택 항목 초기화" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetVehicles)), "한 번만: 지금 존재하는 선택된 유형을 제거합니다. 새로 생성된 교통은 그대로 둡니다. 옵션을 닫은 다음 속도를 1로 설정하세요." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetVehicles)), "지금 존재하는 선택된 차량과 보행자를 초기화할까요? 새로 생성된 교통은 제거되지 않습니다. 옵션을 닫은 다음 속도를 1로 설정하세요." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ProgressText)), "상태" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ProgressText)), "대기 또는 진행 중, 남은 수 / 제거됨 / 스냅샷. 초기화 중 줄이 갱신되지 않으면 옵션을 다시 여세요." },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetActionGroup), "Reset" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetFeedbackGroup), "피드백" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetDefaultsGroup), "기본값" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetMovingGroup), "이동 중인 차량과 보행자" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetParkedGroup), "주차됨" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetPaceGroup), "속도" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetDebugGroup), "Debug" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingCars)), "자동차" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingCars)), "현재 주행 중인 개인 자동차." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingBicycles)), "자전거" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingBicycles)), "현재 이동 중인 자전거." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingTrains)), "기차" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingTrains)), "현재 이동 중인 기차와 지하철." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingPublicTransport)), "대중교통" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingPublicTransport)), "이동 중인 버스, 택시 및 기타 대중교통(기차 제외)." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingTrucks)), "트럭과 서비스" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingTrucks)), "배송 트럭, 쓰레기, 경찰, 소방, 우편, 구급차 등." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingOther)), "항공기와 선박" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingOther)), "현재 이동 중인 비행기, 헬리콥터, 배." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemovePedestrians)), "보행자" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemovePedestrians)), "걸어 다니는 Cims. 기본값은 꺼짐. 이미 차량에 탄 사람은 대상이 아닙니다." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveParkedCars)), "주차된 자동차" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveParkedCars)), "주차장, 도로변, 건물 차고의 자동차(서비스 및 기지 차량 포함). 기본값은 켜짐." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveParkedBicycles)), "주차된 자전거" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveParkedBicycles)), "정지해 있는 자전거. 기본값은 켜짐." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveParkedTrains)), "주차된 기차" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveParkedTrains)), "기지 또는 조차장에 있는 기차." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveParkedOther)), "기타 주차" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveParkedOther)), "기타 주차된 차량(부두의 배, 게이트의 비행기 등)." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VehiclesPerFrame)), "프레임당 개체" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VehiclesPerFrame)), "각 배치에서 제거할 개체 수(1–64)." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FrameInterval)), "배치 사이 추가 프레임" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.FrameInterval)), "각 배치 후 기다릴 추가 화면 프레임 수. 0 = 매 프레임, 4 ≈ 약 4배 느림." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetEnableDebugging)), "Debugging" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetEnableDebugging)), "Mods_ResetTraffic.log에 자세한 초기화 로그를 기록합니다. 켜져 있으면 게임이 느려집니다. 정상 속도를 위해 끄세요." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetModSettings)), "기본값으로 되돌리기" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetModSettings)), "유형 필터, 페이스 슬라이더, 디버깅을 원래 값으로 되돌립니다. 교통은 제거하지 않습니다." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetModSettings)), "유형 필터, 페이스 슬라이더, 디버깅을 기본값으로 되돌릴까요? 교통은 제거되지 않습니다." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JoinDiscord)), "Discord 참여" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.JoinDiscord)), "초대 링크를 게임 밖의 웹 브라우저에서 엽니다. 의견과 피드백은 언제나 환영입니다. 전체 초기화에 걸린 시간, 도시 인구, 문제가 생긴 점을 알려주세요." },
                { ResetTrafficSystem.FinishDialogTitleId, "Reset Traffic" },
                { ResetTrafficSystem.FinishDialogOkId, "OK" },
                { ResetTrafficSystem.FinishDialogCountsId, "남음 {REMAINING}  ·  제거됨 {REMOVED}  ·  스냅샷 {SNAPSHOT}" },
                { ResetTrafficSystem.StatusIdlePrefixId, "대기 중." },
                { ResetTrafficSystem.StatusIdleFreshId, "대기 중. 이 세션에서는 아직 초기화하지 않았습니다." },
                { ResetTrafficSystem.StatusRunningId, "진행 중." },
                { ResetTrafficSystem.StatusQueuedId, "대기열에 추가됨. 옵션을 닫은 다음 속도를 1로 설정하세요." },
                { ResetTrafficSystem.StatusWaitingId, "속도 1을 기다리는 중." },
                { ResetTrafficSystem.StatusNoTypesId, "건너뜀: 선택된 유형이 없습니다." },
                { ResetTrafficSystem.StatusNothingMatchedId, "초기화 완료: 선택된 유형과 일치하는 항목이 없습니다." },
                { ResetTrafficSystem.StatusSnapshotReadyId, "스냅샷 {SNAPSHOT}. 목록에 있는 엔티티만 제거합니다." },
                { ResetTrafficSystem.StatusProgressId, "진행 중: {REMOVED}개 제거됨, {REMAINING}개 남음." },
                { ResetTrafficSystem.StatusCompleteId, "초기화 완료: 엔티티 {REMOVED}개." },
            };
        }

        public void Unload()
        {
            // IDictionarySource requires Unload; Colossal keeps the source for the session.
        }
    }
}
