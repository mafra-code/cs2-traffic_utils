namespace AccidentsBeGone
{
    using Setting = TrafficUtils.Setting;
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// Options strings for all 12 game languages. English and German are written by hand.
    /// The other ten are translations of those strings. Keys come from <see cref="Setting"/>
    /// so a renamed property stays bound.
    /// </summary>
    internal static class LocaleTable
    {
        public static Dictionary<string, string> Bind(Setting setting, string[] text, string lang)
        {
            Dictionary<string, string> entries = new Dictionary<string, string>
            {
                { setting.GetSettingsLocaleID(), text[0] },
                { setting.GetOptionGroupLocaleID(Setting.AccidentToggleGroup), text[1] },
                { setting.GetOptionGroupLocaleID(Setting.AccidentClearGroup), text[2] },
                { setting.GetOptionGroupLocaleID(Setting.AccidentDebugGroup), text[3] },
                { setting.GetOptionLabelLocaleID(nameof(Setting.AccidentEnabled)), text[4] },
                { setting.GetOptionDescLocaleID(nameof(Setting.AccidentEnabled)), text[5] },
                { setting.GetOptionLabelLocaleID(nameof(Setting.ClearOnLoad)), text[6] },
                { setting.GetOptionDescLocaleID(nameof(Setting.ClearOnLoad)), text[7] },
                { setting.GetOptionLabelLocaleID(nameof(Setting.ClearNow)), text[8] },
                { setting.GetOptionDescLocaleID(nameof(Setting.ClearNow)), text[9] },
                { setting.GetOptionWarningLocaleID(nameof(Setting.ClearNow)), text[10] },
                { setting.GetOptionLabelLocaleID(nameof(Setting.StatusText)), text[11] },
                { setting.GetOptionDescLocaleID(nameof(Setting.StatusText)), text[12] },
                { setting.GetOptionLabelLocaleID(nameof(Setting.AccidentEnableDebugging)), text[13] },
                { setting.GetOptionDescLocaleID(nameof(Setting.AccidentEnableDebugging)), text[14] },
                { AccidentsBeGoneSystem.StatusIdleId, text[15] },
                { AccidentsBeGoneSystem.StatusClearedId, text[16] },
            };
            LocaleStats.Add(entries, setting, lang);
            return entries;
        }
    }

    public class LocaleEN : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleEN(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return LocaleTable.Bind(m_Setting, new[]
            {
                "Accidents Be Gone",
                "Prevention",
                "Clear",
                "Debug",
                "Enabled",
                "While on, the traffic-accident chance is held at zero every tick, including locked accident prefabs. Turning it off restores the prefab's own chance. Fires, crime scenes, and medical calls stay. This mod does not use Disable Accidents.",
                "Clear existing wrecks",
                "When on, loading a city or turning prevention on removes traffic-accident sites already on the roads and lets involved vehicles drive again. Roads stay. Fires and crime scenes stay.",
                "Clear wrecks now",
                "Remove traffic-accident sites that are on the roads right now. Involved vehicles can drive on. Does nothing for fires or crime scenes.",
                "Remove current traffic accidents? Involved vehicles can drive on. Fires and crime scenes stay.",
                "Last clear",
                "Events removed, road sites cleared, and vehicles released from the accident. Re-open this page if the line looks stale.",
                "Debugging",
                "Verbose lines in Mods_AccidentsBeGone.log. Leave off unless you are diagnosing.",
                "No wrecks cleared this session.",
                "Last clear: {0} events, {1} sites, {2} vehicles released.",
            }, "en");
        }

        public void Unload()
        {
        }
    }

    public class LocaleDE : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleDE(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return LocaleTable.Bind(m_Setting, new[]
            {
                "Accidents Be Gone",
                "Vorbeugung",
                "Räumen",
                "Debug",
                "Aktiv",
                "Wenn an, wird die Unfallchance jeden Tick auf null gehalten, auch bei gesperrten Unfall-Prefabs. Wenn aus, gilt wieder die Chance des Prefabs. Brände, Tatorte und Krankentransporte bleiben. Dieser Mod nutzt Disable Accidents nicht.",
                "Bestehende Unfälle räumen",
                "Wenn an, entfernt das Laden einer Stadt oder das Einschalten der Vorbeugung Unfallstellen, die schon auf den Straßen liegen, und lässt beteiligte Fahrzeuge weiterfahren. Straßen bleiben. Brände und Tatorte bleiben.",
                "Jetzt räumen",
                "Entfernt Unfallstellen, die gerade auf den Straßen liegen. Beteiligte Fahrzeuge können weiterfahren. Brände und Tatorte bleiben unberührt.",
                "Aktuelle Verkehrsunfälle entfernen? Beteiligte Fahrzeuge können weiterfahren. Brände und Tatorte bleiben.",
                "Letztes Räumen",
                "Entfernte Ereignisse, geräumte Straßenstellen und Fahrzeuge, die vom Unfall gelöst wurden. Diese Seite neu öffnen, falls die Zeile veraltet wirkt.",
                "Debugging",
                "Ausführliche Zeilen in Mods_AccidentsBeGone.log. Aus lassen, außer du diagnostizierst.",
                "In dieser Sitzung wurden keine Unfälle geräumt.",
                "Letztes Räumen: {0} Ereignisse, {1} Stellen, {2} Fahrzeuge freigegeben.",
            }, "de");
        }

        public void Unload()
        {
        }
    }

    public class LocaleES : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleES(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return LocaleTable.Bind(m_Setting, new[]
            {
                "Accidents Be Gone",
                "Prevención",
                "Retirar",
                "Depuración",
                "Activado",
                "Si está activo, la probabilidad de accidente de tráfico se mantiene en cero cada tick, incluidos los prefabs bloqueados. Al desactivarlo vuelve la probabilidad del prefab. Los incendios, las escenas del crimen y las urgencias médicas siguen igual. Este mod no usa Disable Accidents.",
                "Retirar accidentes existentes",
                "Si está activo, al cargar una ciudad o al activar la prevención se quitan los accidentes que ya están en las calles y los vehículos implicados pueden seguir. Las calles se quedan. Los incendios y las escenas del crimen se quedan.",
                "Retirar accidentes ahora",
                "Quita los accidentes de tráfico que hay ahora en las calles. Los vehículos implicados pueden seguir. No afecta a incendios ni a escenas del crimen.",
                "¿Quitar los accidentes de tráfico actuales? Los vehículos implicados pueden seguir. Los incendios y las escenas del crimen se quedan.",
                "Última retirada",
                "Eventos eliminados, lugares de la calle quitados y vehículos liberados del accidente. Vuelve a abrir esta página si la línea parece antigua.",
                "Depuración",
                "Líneas detalladas en Mods_AccidentsBeGone.log. Déjalo desactivado salvo que estés diagnosticando.",
                "No se ha retirado ningún accidente en esta sesión.",
                "Última retirada: {0} eventos, {1} lugares, {2} vehículos liberados.",
            }, "es");
        }

        public void Unload()
        {
        }
    }

    public class LocaleFR : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleFR(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return LocaleTable.Bind(m_Setting, new[]
            {
                "Accidents Be Gone",
                "Prévention",
                "Retrait",
                "Débogage",
                "Activé",
                "Quand c'est activé, la chance d'accident de la route reste à zéro à chaque tick, y compris pour les prefabs verrouillés. La désactivation restaure la chance du prefab. Incendies, scènes de crime et urgences médicales restent. Ce mod n'utilise pas Disable Accidents.",
                "Retirer les accidents déjà présents",
                "Quand c'est activé, charger une ville ou activer la prévention retire les accidents déjà sur les routes et laisse repartir les véhicules impliqués. Les routes restent. Incendies et scènes de crime restent.",
                "Retirer les accidents maintenant",
                "Retire les accidents de la route présents en ce moment. Les véhicules impliqués peuvent repartir. Les incendies et les scènes de crime ne sont pas touchés.",
                "Retirer les accidents de la route en cours ? Les véhicules impliqués peuvent repartir. Incendies et scènes de crime restent.",
                "Dernier retrait",
                "Événements supprimés, sites de route retirés et véhicules libérés de l'accident. Rouvrez cette page si la ligne semble périmée.",
                "Débogage",
                "Lignes détaillées dans Mods_AccidentsBeGone.log. Laissez désactivé sauf pour un diagnostic.",
                "Aucun accident retiré cette session.",
                "Dernier retrait : {0} événements, {1} sites, {2} véhicules libérés.",
            }, "fr");
        }

        public void Unload()
        {
        }
    }

    public class LocaleIT : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleIT(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return LocaleTable.Bind(m_Setting, new[]
            {
                "Accidents Be Gone",
                "Prevenzione",
                "Rimozione",
                "Debug",
                "Attivo",
                "Se attivo, la probabilità di incidente stradale resta a zero a ogni tick, anche per i prefab bloccati. Disattivandolo torna la probabilità del prefab. Incendi, scene del crimine e emergenze mediche restano. Questo mod non usa Disable Accidents.",
                "Rimuovi incidenti già presenti",
                "Se attivo, caricare una città o attivare la prevenzione toglie gli incidenti già sulle strade e lascia ripartire i veicoli coinvolti. Le strade restano. Incendi e scene del crimine restano.",
                "Rimuovi gli incidenti ora",
                "Toglie gli incidenti stradali presenti adesso. I veicoli coinvolti possono ripartire. Non tocca incendi né scene del crimine.",
                "Rimuovere gli incidenti stradali attuali? I veicoli coinvolti possono ripartire. Incendi e scene del crimine restano.",
                "Ultima rimozione",
                "Eventi eliminati, siti sulla strada tolti e veicoli liberati dall'incidente. Riapri questa pagina se la riga sembra vecchia.",
                "Debug",
                "Righe dettagliate in Mods_AccidentsBeGone.log. Lascialo spento salvo per una diagnosi.",
                "Nessun incidente rimosso in questa sessione.",
                "Ultima rimozione: {0} eventi, {1} siti, {2} veicoli liberati.",
            }, "it");
        }

        public void Unload()
        {
        }
    }

    public class LocaleJA : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleJA(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return LocaleTable.Bind(m_Setting, new[]
            {
                "Accidents Be Gone",
                "防止",
                "撤去",
                "デバッグ",
                "有効",
                "オンの間、交通事故の発生率はロックされたプレハブを含めて毎ティック 0 に保たれます。オフにするとプレハブ本来の発生率に戻ります。火災、犯罪現場、救急はそのままです。この MOD は Disable Accidents を使いません。",
                "既存の事故を撤去",
                "オンのとき、都市の読み込みまたは防止をオンにしたタイミングで、道路上の交通事故現場を消し、関わっていた車両が再び走れるようにします。道路は残します。火災と犯罪現場は残します。",
                "今すぐ事故を撤去",
                "今道路上にある交通事故現場を消します。関わっていた車両は再び走れます。火災と犯罪現場には影響しません。",
                "現在の交通事故を撤去しますか？関わっていた車両は再び走れます。火災と犯罪現場は残ります。",
                "前回の撤去",
                "消したイベント、撤去した道路上の現場、事故から解放した車両です。行が古いときはこのページを開き直してください。",
                "デバッグ",
                "Mods_AccidentsBeGone.log に詳細を書きます。調査するとき以外はオフにしてください。",
                "このセッションでは事故を撤去していません。",
                "前回の撤去: イベント {0}、現場 {1}、解放した車両 {2}。",
            }, "ja");
        }

        public void Unload()
        {
        }
    }

    public class LocaleKO : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleKO(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return LocaleTable.Bind(m_Setting, new[]
            {
                "Accidents Be Gone",
                "예방",
                "제거",
                "디버그",
                "사용",
                "켜져 있으면 잠긴 프리팹을 포함해 교통사고 확률이 매 틱 0으로 유지됩니다. 끄면 프리팹 원래 확률로 돌아갑니다. 화재, 범죄 현장, 구급은 그대로입니다. 이 모드는 Disable Accidents를 쓰지 않습니다.",
                "이미 있는 사고 제거",
                "켜져 있으면 도시를 불러올 때나 예방을 켤 때 도로 위의 교통사고 현장을 없애고, 연루된 차량이 다시 움직이게 합니다. 도로는 남습니다. 화재와 범죄 현장은 남습니다.",
                "지금 사고 제거",
                "지금 도로 위에 있는 교통사고 현장을 없앱니다. 연루된 차량은 다시 움직일 수 있습니다. 화재와 범죄 현장은 건드리지 않습니다.",
                "현재 교통사고를 제거할까요? 연루된 차량은 다시 움직일 수 있습니다. 화재와 범죄 현장은 남습니다.",
                "마지막 제거",
                "제거한 이벤트, 치운 도로 현장, 사고에서 풀어 준 차량입니다. 줄이 오래돼 보이면 이 페이지를 다시 여세요.",
                "디버그",
                "Mods_AccidentsBeGone.log에 자세한 줄을 남깁니다. 진단할 때가 아니면 끄세요.",
                "이번 세션에서 제거한 사고가 없습니다.",
                "마지막 제거: 이벤트 {0}, 현장 {1}, 다시 움직인 차량 {2}.",
            }, "ko");
        }

        public void Unload()
        {
        }
    }

    public class LocalePL : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocalePL(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return LocaleTable.Bind(m_Setting, new[]
            {
                "Accidents Be Gone",
                "Zapobieganie",
                "Usuwanie",
                "Debug",
                "Włączone",
                "Gdy włączone, szansa na wypadek drogowy jest co tick trzymana na zero, także dla zablokowanych prefabów. Wyłączenie przywraca szansę prefabu. Pożary, miejsca zbrodni i wezwania medyczne zostają. Ten mod nie używa Disable Accidents.",
                "Usuń istniejące wypadki",
                "Gdy włączone, wczytanie miasta lub włączenie zapobiegania usuwa wypadki już leżące na drogach i pozwala wplątanym pojazdom jechać dalej. Drogi zostają. Pożary i miejsca zbrodni zostają.",
                "Usuń wypadki teraz",
                "Usuwa wypadki drogowe, które są teraz na drogach. Wplątane pojazdy mogą jechać dalej. Pożary i miejsca zbrodni zostają.",
                "Usunąć obecne wypadki drogowe? Wplątane pojazdy mogą jechać dalej. Pożary i miejsca zbrodni zostają.",
                "Ostatnie usunięcie",
                "Usunięte zdarzenia, zdjęte miejsca na drodze i pojazdy zwolnione z wypadku. Otwórz tę stronę ponownie, jeśli wiersz wygląda na nieaktualny.",
                "Debug",
                "Szczegółowe wiersze w Mods_AccidentsBeGone.log. Zostaw wyłączone, chyba że diagnozujesz.",
                "W tej sesji nie usunięto wypadków.",
                "Ostatnie usunięcie: {0} zdarzeń, {1} miejsc, {2} pojazdów zwolnionych.",
            }, "pl");
        }

        public void Unload()
        {
        }
    }

    public class LocalePT : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocalePT(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return LocaleTable.Bind(m_Setting, new[]
            {
                "Accidents Be Gone",
                "Prevenção",
                "Limpar",
                "Depuração",
                "Ativado",
                "Enquanto ligado, a chance de acidente de trânsito fica em zero a cada tick, inclusive em prefabs bloqueados. Desligar restaura a chance do prefab. Incêndios, cenas de crime e chamados médicos continuam. Este mod não usa Disable Accidents.",
                "Limpar acidentes já existentes",
                "Enquanto ligado, carregar uma cidade ou ligar a prevenção remove acidentes que já estão nas ruas e deixa os veículos envolvidos seguir. As ruas ficam. Incêndios e cenas de crime ficam.",
                "Limpar acidentes agora",
                "Remove os acidentes de trânsito que estão nas ruas agora. Os veículos envolvidos podem seguir. Não mexe em incêndios nem em cenas de crime.",
                "Remover os acidentes de trânsito atuais? Os veículos envolvidos podem seguir. Incêndios e cenas de crime ficam.",
                "Última limpeza",
                "Eventos removidos, locais na rua limpos e veículos liberados do acidente. Abra esta página de novo se a linha parecer velha.",
                "Depuração",
                "Linhas detalhadas em Mods_AccidentsBeGone.log. Deixe desligado, salvo para diagnosticar.",
                "Nenhum acidente limpo nesta sessão.",
                "Última limpeza: {0} eventos, {1} locais, {2} veículos liberados.",
            }, "pt");
        }

        public void Unload()
        {
        }
    }

    public class LocaleRU : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleRU(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return LocaleTable.Bind(m_Setting, new[]
            {
                "Accidents Be Gone",
                "Предотвращение",
                "Уборка",
                "Отладка",
                "Включено",
                "Пока включено, шанс дорожной аварии каждый тик держится на нуле, включая заблокированные префабы. Выключение возвращает шанс самого префаба. Пожары, места преступлений и медицина остаются. Этот мод не использует Disable Accidents.",
                "Убрать уже случившиеся аварии",
                "Пока включено, загрузка города или включение предотвращения убирает аварии, которые уже лежат на дорогах, и отпускает попавшие в них машины. Дороги остаются. Пожары и места преступлений остаются.",
                "Убрать аварии сейчас",
                "Убирает дорожные аварии, которые сейчас на дорогах. Попавшие в них машины могут ехать дальше. Пожары и места преступлений не трогает.",
                "Убрать текущие дорожные аварии? Попавшие в них машины могут ехать дальше. Пожары и места преступлений останутся.",
                "Последняя уборка",
                "Удалённые события, снятые места на дороге и машины, отпущенные из аварии. Откройте страницу снова, если строка кажется устаревшей.",
                "Отладка",
                "Подробные строки в Mods_AccidentsBeGone.log. Оставьте выключенным, если не ищете причину.",
                "В этом сеансе аварии не убирались.",
                "Последняя уборка: {0} событий, {1} мест, {2} машин отпущены.",
            }, "ru");
        }

        public void Unload()
        {
        }
    }

    public class LocaleZHHans : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleZHHans(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return LocaleTable.Bind(m_Setting, new[]
            {
                "Accidents Be Gone",
                "预防",
                "清除",
                "调试",
                "启用",
                "开启时，每个时刻都把交通事故概率保持为 0，包括被锁定的事故预制件。关闭后恢复预制件自己的概率。火灾、犯罪现场和医疗呼叫不变。此模组不使用 Disable Accidents。",
                "清除已有事故",
                "开启时，载入城市或打开预防会移除已经在路上的交通事故现场，并让涉事车辆继续行驶。道路保留。火灾和犯罪现场保留。",
                "立即清除事故",
                "移除当前在路上的交通事故现场。涉事车辆可以继续行驶。不影响火灾和犯罪现场。",
                "要移除当前的交通事故吗？涉事车辆可以继续行驶。火灾和犯罪现场会保留。",
                "上次清除",
                "已删除的事件、已清除的道路现场，以及从事故中放开的车辆。如果这一行看起来过时，请重新打开本页。",
                "调试",
                "向 Mods_AccidentsBeGone.log 写入详细行。除非正在排查，否则保持关闭。",
                "本次会话尚未清除事故。",
                "上次清除：{0} 个事件，{1} 处现场，{2} 辆车已放开。",
            }, "zh-Hans");
        }

        public void Unload()
        {
        }
    }

    public class LocaleZHHant : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleZHHant(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return LocaleTable.Bind(m_Setting, new[]
            {
                "Accidents Be Gone",
                "預防",
                "清除",
                "除錯",
                "啟用",
                "開啟時，每個時刻都把交通事故機率維持在 0，包括被鎖定的事故預製件。關閉後恢復預製件自己的機率。火災、犯罪現場和醫療呼叫不變。此模組不使用 Disable Accidents。",
                "清除既有事故",
                "開啟時，載入城市或打開預防會移除已經在路上的交通事故現場，並讓涉事車輛繼續行駛。道路保留。火災和犯罪現場保留。",
                "立即清除事故",
                "移除目前在路上的交通事故現場。涉事車輛可以繼續行駛。不影響火災和犯罪現場。",
                "要移除目前的交通事故嗎？涉事車輛可以繼續行駛。火災和犯罪現場會保留。",
                "上次清除",
                "已刪除的事件、已清除的道路現場，以及從事故中放開的車輛。如果這一行看起來過時，請重新開啟本頁。",
                "除錯",
                "將詳細行寫入 Mods_AccidentsBeGone.log。除非正在排查，否則保持關閉。",
                "本次工作階段尚未清除事故。",
                "上次清除：{0} 個事件，{1} 處現場，{2} 輛車已放開。",
            }, "zh-Hant");
        }

        public void Unload()
        {
        }
    }
}
