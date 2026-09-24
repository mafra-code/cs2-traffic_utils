namespace TrafficUtils
{
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// Page title, tab labels, and the superseded-mods note.
    /// English and German are written by hand. The other ten keep the mod names
    /// and a short translation of the note.
    /// Registered after the feature locales so this page title replaces the three old ones.
    /// </summary>
    public class LocalePages : IDictionarySource
    {
        private readonly Setting m_Setting;
        private readonly string m_Lang;

        public LocalePages(Setting setting, string lang)
        {
            m_Setting = setting;
            m_Lang = lang;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            string[] text = Texts(m_Lang);
            return new Dictionary<string, string>
            {
                { m_Setting.GetSettingsLocaleID(), text[0] },
                { m_Setting.GetOptionTabLocaleID(Setting.TabReset), text[1] },
                { m_Setting.GetOptionTabLocaleID(Setting.TabJam), text[2] },
                { m_Setting.GetOptionTabLocaleID(Setting.TabAccident), text[3] },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetNoticeGroup), text[4] },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SupersededNote)), text[5] },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SupersededNote)), text[6] },
                { Setting.SupersededNoteId, text[6] },
            };
        }

        public void Unload()
        {
        }

        private static string[] Texts(string lang)
        {
            switch (lang)
            {
                case "de-DE":
                    return new[]
                    {
                        "Traffic Utils",
                        "Reset Traffic",
                        "Jam Threshold",
                        "Accidents Be Gone",
                        "Hinweis",
                        "Ältere Mods",
                        "Reset Traffic, Jam Threshold und Accidents Be Gone werden durch Traffic Utils ersetzt. Schalte diese drei Mods aus. Wenn sie an bleiben, läuft jedes System doppelt.",
                    };
                case "es-ES":
                    return new[]
                    {
                        "Traffic Utils",
                        "Reset Traffic",
                        "Jam Threshold",
                        "Accidents Be Gone",
                        "Aviso",
                        "Mods anteriores",
                        "Reset Traffic, Jam Threshold y Accidents Be Gone quedan reemplazados por Traffic Utils. Desactívalos. Si siguen activos, cada sistema se ejecuta dos veces.",
                    };
                case "fr-FR":
                    return new[]
                    {
                        "Traffic Utils",
                        "Reset Traffic",
                        "Jam Threshold",
                        "Accidents Be Gone",
                        "Note",
                        "Anciens mods",
                        "Reset Traffic, Jam Threshold et Accidents Be Gone sont remplacés par Traffic Utils. Désactive-les. S'ils restent actifs, chaque système tourne deux fois.",
                    };
                case "it-IT":
                    return new[]
                    {
                        "Traffic Utils",
                        "Reset Traffic",
                        "Jam Threshold",
                        "Accidents Be Gone",
                        "Nota",
                        "Mod precedenti",
                        "Reset Traffic, Jam Threshold e Accidents Be Gone sono sostituiti da Traffic Utils. Disattivali. Se restano attivi, ogni sistema gira due volte.",
                    };
                case "ja-JP":
                    return new[]
                    {
                        "Traffic Utils",
                        "Reset Traffic",
                        "Jam Threshold",
                        "Accidents Be Gone",
                        "注意",
                        "以前のMod",
                        "Reset Traffic、Jam Threshold、Accidents Be Gone は Traffic Utils に置き換わりました。この3つを無効にしてください。有効のままだと各システムが二重に動きます。",
                    };
                case "ko-KR":
                    return new[]
                    {
                        "Traffic Utils",
                        "Reset Traffic",
                        "Jam Threshold",
                        "Accidents Be Gone",
                        "안내",
                        "이전 모드",
                        "Reset Traffic, Jam Threshold, Accidents Be Gone은 Traffic Utils로 대체되었습니다. 세 모드를 끄세요. 켜 두면 각 시스템이 두 번 실행됩니다.",
                    };
                case "pl-PL":
                    return new[]
                    {
                        "Traffic Utils",
                        "Reset Traffic",
                        "Jam Threshold",
                        "Accidents Be Gone",
                        "Uwaga",
                        "Starsze mody",
                        "Reset Traffic, Jam Threshold i Accidents Be Gone zastępuje Traffic Utils. Wyłącz te trzy mody. Jeśli zostaną włączone, każdy system działa dwa razy.",
                    };
                case "pt-BR":
                    return new[]
                    {
                        "Traffic Utils",
                        "Reset Traffic",
                        "Jam Threshold",
                        "Accidents Be Gone",
                        "Aviso",
                        "Mods antigos",
                        "Reset Traffic, Jam Threshold e Accidents Be Gone foram substituídos pelo Traffic Utils. Desative os três. Se continuarem ativos, cada sistema roda duas vezes.",
                    };
                case "ru-RU":
                    return new[]
                    {
                        "Traffic Utils",
                        "Reset Traffic",
                        "Jam Threshold",
                        "Accidents Be Gone",
                        "Примечание",
                        "Старые моды",
                        "Reset Traffic, Jam Threshold и Accidents Be Gone заменены на Traffic Utils. Отключите эти три мода. Если они останутся включены, каждая система выполняется дважды.",
                    };
                case "zh-HANS":
                    return new[]
                    {
                        "Traffic Utils",
                        "Reset Traffic",
                        "Jam Threshold",
                        "Accidents Be Gone",
                        "提示",
                        "旧模组",
                        "Reset Traffic、Jam Threshold 和 Accidents Be Gone 已由 Traffic Utils 取代。请禁用这三个模组。若仍然启用，每个系统会运行两次。",
                    };
                case "zh-HANT":
                    return new[]
                    {
                        "Traffic Utils",
                        "Reset Traffic",
                        "Jam Threshold",
                        "Accidents Be Gone",
                        "提示",
                        "舊模組",
                        "Reset Traffic、Jam Threshold 和 Accidents Be Gone 已由 Traffic Utils 取代。請停用這三個模組。若仍然啟用，每個系統會執行兩次。",
                    };
                default:
                    return new[]
                    {
                        "Traffic Utils",
                        "Reset Traffic",
                        "Jam Threshold",
                        "Accidents Be Gone",
                        "Note",
                        "Older mods",
                        "Reset Traffic, Jam Threshold, and Accidents Be Gone are superseded by Traffic Utils. Disable those three mods. Leaving them on runs each system twice.",
                    };
            }
        }
    }
}
