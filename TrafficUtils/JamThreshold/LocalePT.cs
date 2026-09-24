namespace JamThreshold
{
    using Setting = TrafficUtils.Setting;
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// AI-generated Options strings from the English meaning. Keys match <see cref="LocaleEN"/>.
    /// </summary>
    public class LocalePT : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocalePT(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                { m_Setting.GetSettingsLocaleID(), "Jam Threshold" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamToggleGroup), "Substituição" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamThresholdGroup), "Limites" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamStatsGroup), "Estatísticas" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamRateGroup), "Ritmo" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamVanillaGroup), "Vanilla" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamDebugGroup), "Debug" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamEnabled)), "Ativado" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.JamEnabled)), "Quando ligado, a verificação original de veículos presos do jogo é desligada e esta substituição usa os controles abaixo. Quando desligado, o comportamento vanilla volta. Isso não redefine todo o tráfego." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChainDepth)), "Profundidade da cadeia" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ChainDepth)), "Uma cadeia de veículos bloqueados é marcada como presa se for um loop ou for mais longa que este valor. Vanilla é 100. Padrão 40 para que congestionamentos mais curtos comecem a desaparecer." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MaxStuckSpeed)), "Limite de velocidade" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.MaxStuckSpeed)), "Byte bruto de velocidade do Blocker (~0,2 m/s por unidade). A varredura da cadeia para se algum veículo estiver neste valor ou acima. Vanilla 6 é cerca de 1,2 m/s." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ClearedText)), "Liberados nesta sessão" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ClearedText)), "Objetos que esta substituição marcou como presos desde que a cidade foi carregada. Passageiros dentro de um veículo são contados uma vez, pelo veículo. Reabra esta página se os números parecerem desatualizados." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamRateText)), "Todos os objetos" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.JamRateText)), "Objetos liberados por hora de jogo, não por hora real. O tempo em pausa não conta. Aparece quando passa tempo de jogo suficiente." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCarText)), "Carros" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamDeliveryTruckText)), "Caminhões de entrega" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamGarbageTruckText)), "Caminhões de lixo" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCargoTruckText)), "Caminhões de carga" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamRoadMaintenanceText)), "Manutenção de vias" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamParkMaintenanceText)), "Manutenção de parques" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamMaintenanceText)), "Veículos de manutenção" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamFireEngineText)), "Caminhões de bombeiros" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPoliceCarText)), "Viaturas policiais" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPostVanText)), "Furgões dos correios" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAmbulanceText)), "Ambulâncias" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamHearseText)), "Carros funerários" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPrisonerTransportText)), "Transporte de presos" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamEvacuationText)), "Veículos de evacuação" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTaxiText)), "Táxis" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTransitText)), "Transporte" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPassengerTrainText)), "Trens de passageiros" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCargoTrainText)), "Trens de carga" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTrainText)), "Trens" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAirplaneText)), "Aviões" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamHelicopterText)), "Helicópteros" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAircraftText)), "Aeronaves" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamWatercraftText)), "Embarcações" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamBicycleText)), "Bicicletas" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPedestrianText)), "Pedestres" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamOtherText)), "Outros" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCarRateText)), "Carros" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamDeliveryTruckRateText)), "Caminhões de entrega" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamGarbageTruckRateText)), "Caminhões de lixo" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCargoTruckRateText)), "Caminhões de carga" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamRoadMaintenanceRateText)), "Manutenção de vias" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamParkMaintenanceRateText)), "Manutenção de parques" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamMaintenanceRateText)), "Veículos de manutenção" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamFireEngineRateText)), "Caminhões de bombeiros" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPoliceCarRateText)), "Viaturas policiais" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPostVanRateText)), "Furgões dos correios" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAmbulanceRateText)), "Ambulâncias" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamHearseRateText)), "Carros funerários" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPrisonerTransportRateText)), "Transporte de presos" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamEvacuationRateText)), "Veículos de evacuação" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTaxiRateText)), "Táxis" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTransitRateText)), "Transporte" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPassengerTrainRateText)), "Trens de passageiros" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCargoTrainRateText)), "Trens de carga" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTrainRateText)), "Trens" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAirplaneRateText)), "Aviões" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamHelicopterRateText)), "Helicópteros" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAircraftRateText)), "Aeronaves" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamWatercraftRateText)), "Embarcações" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamBicycleRateText)), "Bicicletas" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPedestrianRateText)), "Pedestres" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamOtherRateText)), "Outros" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamResetStats)), "Redefinir estatísticas" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.JamResetStats)), "Zera todos os contadores e reinicia a medição das horas de jogo. Não altera seus limites e não remove veículos." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.JamResetStats)), "Zerar as estatísticas? Isso limpa apenas os contadores. Seus limites e o trânsito da cidade ficam intactos." },
                { ClearanceStats.ClearedId, "{TOTAL} objetos" },
                { ClearanceStats.RateId, "~{RATE} objetos / hora de jogo" },
                { ClearanceStats.KindRateId, "~{RATE} / hora de jogo" },
                { ClearanceStats.RateUnknownId, "—" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamEnableDebugging)), "Debugging" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.JamEnableDebugging)), "Logs detalhados de congestionamento em Mods_JamThreshold.log. Deixa o jogo mais lento enquanto ligado. Desligue para velocidade normal." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "Redefinir para vanilla" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)), "Desliga esta substituição e usa a verificação original do jogo (cadeia 100, velocidade 6). Não remove o tráfego da cidade inteira. Seus controles são mantidos se você ativar a substituição de novo." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetToVanilla)), "Usar a verificação original de veículos presos do jogo? Congestionamentos curtos vão ficar de novo até você reativar este mod. Isso não remove veículos." },
            };
        }

        public void Unload()
        {
            // IDictionarySource requires Unload; Colossal keeps the source for the session.
        }
    }
}
