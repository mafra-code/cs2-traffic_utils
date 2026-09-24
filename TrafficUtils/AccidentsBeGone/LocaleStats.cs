namespace AccidentsBeGone
{
    using Setting = TrafficUtils.Setting;
    using System.Collections.Generic;

    /// <summary>
    /// Statistics and rate strings. Kind labels match Jam Threshold so the rows read the same.
    /// English and German chrome are written by hand. The other ten are translations of those.
    /// </summary>
    internal static class LocaleStats
    {
        private static readonly string[] Names =
        {
            nameof(Setting.AccidentCarText),
            nameof(Setting.AccidentDeliveryTruckText),
            nameof(Setting.AccidentGarbageTruckText),
            nameof(Setting.AccidentCargoTruckText),
            nameof(Setting.AccidentRoadMaintenanceText),
            nameof(Setting.AccidentParkMaintenanceText),
            nameof(Setting.AccidentMaintenanceText),
            nameof(Setting.AccidentFireEngineText),
            nameof(Setting.AccidentPoliceCarText),
            nameof(Setting.AccidentPostVanText),
            nameof(Setting.AccidentAmbulanceText),
            nameof(Setting.AccidentHearseText),
            nameof(Setting.AccidentPrisonerTransportText),
            nameof(Setting.AccidentEvacuationText),
            nameof(Setting.AccidentTaxiText),
            nameof(Setting.AccidentTransitText),
            nameof(Setting.AccidentPassengerTrainText),
            nameof(Setting.AccidentCargoTrainText),
            nameof(Setting.AccidentTrainText),
            nameof(Setting.AccidentAirplaneText),
            nameof(Setting.AccidentHelicopterText),
            nameof(Setting.AccidentAircraftText),
            nameof(Setting.AccidentWatercraftText),
            nameof(Setting.AccidentBicycleText),
            nameof(Setting.AccidentPedestrianText),
            nameof(Setting.AccidentOtherText),
        };

        private static readonly string[] RateNames =
        {
            nameof(Setting.AccidentCarRateText),
            nameof(Setting.AccidentDeliveryTruckRateText),
            nameof(Setting.AccidentGarbageTruckRateText),
            nameof(Setting.AccidentCargoTruckRateText),
            nameof(Setting.AccidentRoadMaintenanceRateText),
            nameof(Setting.AccidentParkMaintenanceRateText),
            nameof(Setting.AccidentMaintenanceRateText),
            nameof(Setting.AccidentFireEngineRateText),
            nameof(Setting.AccidentPoliceCarRateText),
            nameof(Setting.AccidentPostVanRateText),
            nameof(Setting.AccidentAmbulanceRateText),
            nameof(Setting.AccidentHearseRateText),
            nameof(Setting.AccidentPrisonerTransportRateText),
            nameof(Setting.AccidentEvacuationRateText),
            nameof(Setting.AccidentTaxiRateText),
            nameof(Setting.AccidentTransitRateText),
            nameof(Setting.AccidentPassengerTrainRateText),
            nameof(Setting.AccidentCargoTrainRateText),
            nameof(Setting.AccidentTrainRateText),
            nameof(Setting.AccidentAirplaneRateText),
            nameof(Setting.AccidentHelicopterRateText),
            nameof(Setting.AccidentAircraftRateText),
            nameof(Setting.AccidentWatercraftRateText),
            nameof(Setting.AccidentBicycleRateText),
            nameof(Setting.AccidentPedestrianRateText),
            nameof(Setting.AccidentOtherRateText),
        };

        internal static void Add(Dictionary<string, string> entries, Setting setting, string lang)
        {
            string[] chrome = Chrome(lang);
            string[] kinds = Kinds(lang);
            entries[setting.GetOptionGroupLocaleID(Setting.AccidentStatsGroup)] = chrome[0];
            entries[setting.GetOptionGroupLocaleID(Setting.AccidentRateGroup)] = chrome[1];
            entries[setting.GetOptionLabelLocaleID(nameof(Setting.InvolvedText))] = chrome[2];
            entries[setting.GetOptionDescLocaleID(nameof(Setting.InvolvedText))] = chrome[3];
            entries[setting.GetOptionLabelLocaleID(nameof(Setting.AccidentRateText))] = chrome[4];
            entries[setting.GetOptionDescLocaleID(nameof(Setting.AccidentRateText))] = chrome[5];
            entries[setting.GetOptionLabelLocaleID(nameof(Setting.AccidentResetStats))] = chrome[6];
            entries[setting.GetOptionDescLocaleID(nameof(Setting.AccidentResetStats))] = chrome[7];
            entries[setting.GetOptionWarningLocaleID(nameof(Setting.AccidentResetStats))] = chrome[8];
            entries[InvolvedStats.ClearedId] = chrome[9];
            entries[InvolvedStats.RateId] = chrome[10];
            entries[InvolvedStats.KindRateId] = chrome[11];
            entries[InvolvedStats.RateUnknownId] = chrome[12];
            for (int i = 0; i < Names.Length; i++)
            {
                entries[setting.GetOptionLabelLocaleID(Names[i])] = kinds[i];
                entries[setting.GetOptionLabelLocaleID(RateNames[i])] = kinds[i];
            }

            string[] interval = Interval(lang);
            entries[setting.GetOptionLabelLocaleID(nameof(Setting.UpdateInterval))] = interval[0];
            entries[setting.GetOptionDescLocaleID(nameof(Setting.UpdateInterval))] = interval[1];
        }

        private static string[] Interval(string lang)
        {
            switch (lang)
            {
                case "de":
                    return new[]
                    {
                        "Ausführung alle",
                        "Nicht ändern. Auf 1 lassen. Nur 1 garantiert keine neuen Unfälle: jedes Frame, bevor das Spiel würfelt, schreibt der Mod die Unfallchance wieder auf 0. Das Spiel kann die eigene Chance des Prefabs von selbst zurückkopieren. In einem übersprungenen Frame wird genau diese zurückgesetzte Chance gewürfelt, und ein Unfall kann entstehen. Jeder Wert über 1 gibt die Garantie auf.",
                    };
                case "es":
                    return new[]
                    {
                        "Ejecutar cada",
                        "No lo cambies. Déjalo en 1. Solo 1 garantiza que no haya accidentes nuevos: cada cuadro, antes de que el juego tire, el mod vuelve a escribir la probabilidad a 0. El juego puede copiar de nuevo la probabilidad propia del prefab. En un cuadro omitido se tira esa probabilidad restaurada y puede empezar un accidente. Cualquier valor por encima de 1 pierde la garantía.",
                    };
                case "fr":
                    return new[]
                    {
                        "Exécuter tous les",
                        "Ne le changez pas. Laissez 1. Seul 1 garantit l'absence de nouveaux accidents : à chaque image, avant le tirage, le mod réécrit la chance à 0. Le jeu peut recopier de lui-même la chance du prefab. Sur une image sautée, c'est cette chance restaurée qui est tirée, et un accident peut commencer. Toute valeur au-dessus de 1 abandonne la garantie.",
                    };
                case "it":
                    return new[]
                    {
                        "Esegui ogni",
                        "Non cambiarlo. Lascialo a 1. Solo 1 garantisce nessun nuovo incidente: ogni frame, prima del tiro, la mod riscrive la probabilità a 0. Il gioco può ricopiare da solo la probabilità del prefab. In un frame saltato viene tirata proprio quella probabilità ripristinata, e un incidente può iniziare. Qualsiasi valore sopra 1 perde la garanzia.",
                    };
                case "ja":
                    return new[]
                    {
                        "実行間隔",
                        "変更しないでください。必ず 1 のままにしてください。1 だけが新しい事故を確実に止めます。毎フレーム、抽選の前に事故確率を 0 に書き戻すからです。ゲームはプレハブ本来の確率を自分で戻すことがあります。飛ばしたフレームでは、その戻った確率が抽選され、事故が起き得ます。1 より大きい値では保証はなくなります。",
                    };
                case "ko":
                    return new[]
                    {
                        "실행 간격",
                        "바꾸지 마세요. 항상 1로 두세요. 1만 새 사고를 보장해서 막습니다. 매 프레임, 추첨 전에 사고 확률을 다시 0으로 쓰기 때문입니다. 게임은 프리팹 본래의 확률을 스스로 되돌릴 수 있습니다. 건너뛴 프레임에서는 그 되돌린 확률이 추첨되어 사고가 날 수 있습니다. 1보다 크면 보장이 사라집니다.",
                    };
                case "pl":
                    return new[]
                    {
                        "Uruchamiaj co",
                        "Nie zmieniaj. Zostaw 1. Tylko 1 gwarantuje brak nowych wypadków: w każdej klatce, przed losowaniem, mod zapisuje szansę z powrotem na 0. Gra może sama skopiować z powrotem szansę prefabrykatu. W pominiętej klatce losowana jest właśnie ta przywrócona szansa i wypadek może się zacząć. Każda wartość powyżej 1 odbiera gwarancję.",
                    };
                case "pt":
                    return new[]
                    {
                        "Executar a cada",
                        "Não mude. Deixe em 1. Só 1 garante nenhum acidente novo: em cada quadro, antes do sorteio, o mod volta a escrever a chance como 0. O jogo pode copiar de volta a chance própria do prefab. Num quadro ignorado é essa chance restaurada que é sorteada, e um acidente pode começar. Qualquer valor acima de 1 perde a garantia.",
                    };
                case "ru":
                    return new[]
                    {
                        "Запуск каждые",
                        "Не меняйте. Оставьте 1. Только 1 гарантирует отсутствие новых аварий: каждый кадр, до броска, мод снова записывает шанс как 0. Игра может сама вернуть собственный шанс префаба. В пропущенном кадре бросается именно этот возвращённый шанс, и авария может начаться. Любое значение больше 1 снимает гарантию.",
                    };
                case "zh-Hans":
                    return new[]
                    {
                        "每隔多少帧运行",
                        "不要改。始终保持 1。只有 1 能保证不再出现新事故：每一帧，在游戏掷出结果之前，模组都会把事故概率写回 0。游戏会自行把预制件原本的概率抄回去。被跳过的那一帧掷的就是抄回去的概率，事故仍可能开始。大于 1 的任何值都不再有这个保证。",
                    };
                case "zh-Hant":
                    return new[]
                    {
                        "每隔多少幀執行",
                        "不要改。始終保持 1。只有 1 能保證不再出現新事故：每一幀，在遊戲擲出結果之前，模組都會把事故機率寫回 0。遊戲會自行把預製件原本的機率抄回去。被跳過的那一幀擲的就是抄回去的機率，事故仍可能開始。大於 1 的任何值都不再有這個保證。",
                    };
                default:
                    return new[]
                    {
                        "Run every",
                        "Do not change this. Leave it at 1. Only 1 guarantees no new accidents: every frame, before the game rolls, this mod writes the accident chance back to 0. The game can copy the prefab's own chance back on its own. On a skipped frame that restored chance is what gets rolled, so an accident can start. Any value above 1 gives up the guarantee.",
                    };
            }
        }

        private static string[] Chrome(string lang)
        {
            switch (lang)
            {
                case "de":
                    return new[]
                    {
                        "Statistik",
                        "Rate",
                        "In dieser Sitzung beteiligt",
                        "Objekte, die seit dem Laden der Stadt die Unfallmarkierung bekommen haben. Mitfahrer zählen über das Fahrzeug. Eine Zeile bleibt verborgen, solange der Zähler null ist. Seite neu öffnen, falls eine Zahl veraltet wirkt.",
                        "Alle Objekte",
                        "Dieselben Objekte pro Spielstunde, nicht pro Echtzeitstunde. Pause zählt nicht.",
                        "Statistik zurücksetzen",
                        "Zähler auf null und die Spielstunde neu starten. Vorbeugung und Fahrzeuge bleiben unverändert.",
                        "Statistik auf null setzen? Das leert nur die Zähler.",
                        "{TOTAL} Objekte",
                        "~{RATE} Objekte / Spielstunde",
                        "~{RATE} / Spielstunde",
                        "—",
                    };
                case "es":
                    return new[]
                    {
                        "Estadísticas",
                        "Tasa",
                        "Implicados en esta sesión",
                        "Objetos que recibieron la marca de accidente desde que se cargó la ciudad. Los pasajeros cuentan a través del vehículo. Una fila permanece oculta mientras el recuento es cero. Vuelve a abrir esta página si un número parece desactualizado.",
                        "Todos los objetos",
                        "Esos objetos por hora de juego, no por hora real. El tiempo en pausa no cuenta.",
                        "Restablecer estadísticas",
                        "Pone los contadores a cero y reinicia la hora de juego. No cambia la prevención ni retira vehículos.",
                        "¿Restablecer las estadísticas a cero? Esto solo borra los contadores.",
                        "{TOTAL} objetos",
                        "~{RATE} objetos / hora de juego",
                        "~{RATE} / hora de juego",
                        "—",
                    };
                case "fr":
                    return new[]
                    {
                        "Statistiques",
                        "Taux",
                        "Impliqués cette session",
                        "Objets qui ont reçu le marqueur d'accident depuis le chargement de la ville. Les passagers comptent via le véhicule. Une ligne reste masquée tant que le compteur est à zéro. Rouvrez cette page si un nombre semble périmé.",
                        "Tous les objets",
                        "Ces objets par heure de jeu, pas par heure réelle. Le temps en pause ne compte pas.",
                        "Réinitialiser les statistiques",
                        "Remet les compteurs à zéro et relance l'heure de jeu. Ne change pas la prévention et ne retire pas de véhicules.",
                        "Remettre les statistiques à zéro ? Cela n'efface que les compteurs.",
                        "{TOTAL} objets",
                        "~{RATE} objets / heure de jeu",
                        "~{RATE} / heure de jeu",
                        "—",
                    };
                case "it":
                    return new[]
                    {
                        "Statistiche",
                        "Tasso",
                        "Coinvolti in questa sessione",
                        "Oggetti che hanno ricevuto il marcatore di incidente da quando la città è stata caricata. I passeggeri contano tramite il veicolo. Una riga resta nascosta finché il conteggio è zero. Riapri questa pagina se un numero sembra vecchio.",
                        "Tutti gli oggetti",
                        "Quegli oggetti per ora di gioco, non per ora reale. Il tempo in pausa non conta.",
                        "Azzera statistiche",
                        "Azzera i contatori e riavvia l'ora di gioco. Non cambia la prevenzione e non rimuove veicoli.",
                        "Azzerare le statistiche? Questo cancella solo i contatori.",
                        "{TOTAL} oggetti",
                        "~{RATE} oggetti / ora di gioco",
                        "~{RATE} / ora di gioco",
                        "—",
                    };
                case "ja":
                    return new[]
                    {
                        "統計",
                        "割合",
                        "このセッションで巻き込まれた数",
                        "都市を読み込んでから事故マークを受けた対象です。乗客は車両側で数えます。件数がゼロの行は隠れます。数字が古いときはこのページを開き直してください。",
                        "すべての対象",
                        "実時間ではなくゲーム内1時間あたりの件数です。一時停止中は進みません。",
                        "統計をリセット",
                        "カウンターをゼロにし、ゲーム内時間の計測をやり直します。防止設定と車両はそのままです。",
                        "統計をゼロに戻しますか？カウンターだけが消えます。",
                        "{TOTAL} 件",
                        "ゲーム内1時間あたり約 {RATE} 件",
                        "ゲーム内1時間あたり約 {RATE}",
                        "—",
                    };
                case "ko":
                    return new[]
                    {
                        "통계",
                        "비율",
                        "이번 세션에서 연루됨",
                        "도시를 불러온 뒤 사고 표시를 받은 대상입니다. 승객은 차량으로 셉니다. 횟수가 0인 행은 숨깁니다. 숫자가 오래되어 보이면 이 페이지를 다시 여세요.",
                        "모든 대상",
                        "실제 시간이 아니라 게임 내 1시간당 횟수입니다. 일시정지 중에는 늘지 않습니다.",
                        "통계 초기화",
                        "카운터를 0으로 만들고 게임 내 시간 측정을 다시 시작합니다. 예방과 차량은 바꾸지 않습니다.",
                        "통계를 0으로 되돌릴까요? 카운터만 지웁니다.",
                        "{TOTAL}개",
                        "게임 내 1시간당 약 {RATE}개",
                        "게임 내 1시간당 약 {RATE}",
                        "—",
                    };
                case "pl":
                    return new[]
                    {
                        "Statystyki",
                        "Tempo",
                        "Uczestnicy w tej sesji",
                        "Obiekty, które dostały znacznik wypadku od wczytania miasta. Pasażerowie liczą się przez pojazd. Wiersz zostaje ukryty, dopóki licznik wynosi zero. Otwórz stronę ponownie, jeśli liczba wygląda na nieaktualną.",
                        "Wszystkie obiekty",
                        "Te obiekty na godzinę gry, nie na godzinę rzeczywistą. Pauza się nie liczy.",
                        "Wyzeruj statystyki",
                        "Zeruje liczniki i uruchamia godzinę gry od nowa. Nie zmienia zapobiegania i nie usuwa pojazdów.",
                        "Wyzerować statystyki? To czyści tylko liczniki.",
                        "{TOTAL} obiektów",
                        "~{RATE} obiektów / godz. gry",
                        "~{RATE} / godz. gry",
                        "—",
                    };
                case "pt":
                    return new[]
                    {
                        "Estatísticas",
                        "Taxa",
                        "Envolvidos nesta sessão",
                        "Objetos que receberam a marca de acidente desde que a cidade foi carregada. Passageiros contam pelo veículo. Uma linha fica oculta enquanto a contagem é zero. Reabra esta página se um número parecer desatualizado.",
                        "Todos os objetos",
                        "Esses objetos por hora de jogo, não por hora real. O tempo em pausa não conta.",
                        "Repor estatísticas",
                        "Zera os contadores e reinicia a hora de jogo. Não muda a prevenção nem remove veículos.",
                        "Repor as estatísticas a zero? Isto só limpa os contadores.",
                        "{TOTAL} objetos",
                        "~{RATE} objetos / hora de jogo",
                        "~{RATE} / hora de jogo",
                        "—",
                    };
                case "ru":
                    return new[]
                    {
                        "Статистика",
                        "Темп",
                        "Участники за сессию",
                        "Объекты, получившие метку аварии с загрузки города. Пассажиры считаются через транспорт. Строка скрыта, пока счётчик равен нулю. Откройте страницу снова, если число выглядит устаревшим.",
                        "Все объекты",
                        "Эти объекты за игровой час, не за реальный. Пауза не считается.",
                        "Сбросить статистику",
                        "Обнуляет счётчики и заново начинает игровой час. Не меняет предотвращение и не убирает транспорт.",
                        "Сбросить статистику до нуля? Это очистит только счётчики.",
                        "{TOTAL} объектов",
                        "~{RATE} объектов / игровой час",
                        "~{RATE} / игровой час",
                        "—",
                    };
                case "zh-Hans":
                    return new[]
                    {
                        "统计",
                        "频率",
                        "本局卷入次数",
                        "自城市载入后获得事故标记的对象。乘客通过车辆计数。次数为零的行会隐藏。数字看起来过时就重新打开此页。",
                        "全部对象",
                        "按游戏内小时计，不是现实小时。暂停不计入。",
                        "重置统计",
                        "将计数归零并重新开始游戏内小时。不改变预防，也不移除车辆。",
                        "将统计归零？这只会清除计数。",
                        "{TOTAL} 个对象",
                        "每游戏小时约 {RATE} 个",
                        "每游戏小时约 {RATE}",
                        "—",
                    };
                case "zh-Hant":
                    return new[]
                    {
                        "統計",
                        "頻率",
                        "本局捲入次數",
                        "自城市載入後獲得事故標記的物件。乘客透過車輛計數。次數為零的列會隱藏。數字看起來過時就重新開啟此頁。",
                        "全部物件",
                        "按遊戲內小時計，不是現實小時。暫停不計入。",
                        "重設統計",
                        "將計數歸零並重新開始遊戲內小時。不改變預防，也不移除車輛。",
                        "將統計歸零？這只會清除計數。",
                        "{TOTAL} 個物件",
                        "每遊戲小時約 {RATE} 個",
                        "每遊戲小時約 {RATE}",
                        "—",
                    };
                default:
                    return new[]
                    {
                        "Statistics",
                        "Rate",
                        "Involved this session",
                        "Objects that gained the accident marker since this city loaded. Passengers in a vehicle are counted through the vehicle. A row stays hidden while its count is zero. Re-open this page if a number looks stale.",
                        "All objects",
                        "Those objects per in-game hour, not per real-time hour. Paused time does not count.",
                        "Reset statistics",
                        "Zero the counters and restart the in-game hour. Does not change prevention and does not remove vehicles.",
                        "Reset the statistics to zero? This only clears the counters.",
                        "{TOTAL} objects",
                        "~{RATE} objects / in-game hour",
                        "~{RATE} / in-game hour",
                        "—",
                    };
            }
        }

        private static string[] Kinds(string lang)
        {
            switch (lang)
            {
                case "de":
                    return new[]
                    {
                        "Autos", "Lieferwagen", "Müllwagen", "Fracht-Lkw", "Straßenwartung", "Parkwartung", "Wartungsfahrzeuge",
                        "Feuerwehr", "Polizeiwagen", "Postwagen", "Krankenwagen", "Leichenwagen", "Gefangenentransport",
                        "Evakuierungsfahrzeuge", "Taxis", "ÖPNV", "Personenzüge", "Güterzüge", "Züge", "Flugzeuge",
                        "Hubschrauber", "Luftfahrzeuge", "Wasserfahrzeuge", "Fahrräder", "Fußgänger", "Sonstige",
                    };
                case "es":
                    return new[]
                    {
                        "Coches", "Camiones de reparto", "Camiones de basura", "Camiones de carga", "Mantenimiento de carreteras",
                        "Mantenimiento de parques", "Vehículos de mantenimiento", "Camiones de bomberos", "Coches de policía",
                        "Furgonetas de correos", "Ambulancias", "Coches fúnebres", "Transporte de presos", "Vehículos de evacuación",
                        "Taxis", "Transporte", "Trenes de pasajeros", "Trenes de carga", "Trenes", "Aviones", "Helicópteros",
                        "Aeronaves", "Embarcaciones", "Bicicletas", "Peatones", "Otros",
                    };
                case "fr":
                    return new[]
                    {
                        "Voitures", "Camions de livraison", "Camions-poubelles", "Camions de fret", "Entretien des routes",
                        "Entretien des parcs", "Véhicules d'entretien", "Camions de pompiers", "Voitures de police",
                        "Camionnettes postales", "Ambulances", "Corbillards", "Transport de détenus", "Véhicules d'évacuation",
                        "Taxis", "Transports", "Trains de passagers", "Trains de fret", "Trains", "Avions", "Hélicoptères",
                        "Aéronefs", "Bateaux", "Vélos", "Piétons", "Autres",
                    };
                case "it":
                    return new[]
                    {
                        "Auto", "Furgoni delle consegne", "Camion della spazzatura", "Camion merci", "Manutenzione stradale",
                        "Manutenzione parchi", "Veicoli di manutenzione", "Autopompe", "Auto della polizia", "Furgoni postali",
                        "Ambulanze", "Carri funebri", "Trasporto detenuti", "Veicoli di evacuazione", "Taxi", "Trasporti",
                        "Treni passeggeri", "Treni merci", "Treni", "Aerei", "Elicotteri", "Aeromobili", "Imbarcazioni",
                        "Biciclette", "Pedoni", "Altro",
                    };
                case "ja":
                    return new[]
                    {
                        "乗用車", "配送トラック", "ゴミ収集車", "貨物トラック", "道路維持", "公園維持", "維持車両", "消防車", "パトカー",
                        "郵便バン", "救急車", "霊柩車", "囚人輸送", "避難車両", "タクシー", "公共交通", "旅客列車", "貨物列車", "列車",
                        "飛行機", "ヘリコプター", "航空機", "船舶", "自転車", "歩行者", "その他",
                    };
                case "ko":
                    return new[]
                    {
                        "승용차", "배송 트럭", "쓰레기 트럭", "화물 트럭", "도로 정비", "공원 정비", "정비 차량", "소방차", "경찰차",
                        "우편 밴", "구급차", "영구차", "수감 수송", "대피 차량", "택시", "대중교통", "여객 열차", "화물 열차", "열차",
                        "비행기", "헬리콥터", "항공기", "선박", "자전거", "보행자", "기타",
                    };
                case "pl":
                    return new[]
                    {
                        "Samochody", "Ciężarówki dostawcze", "Śmieciarki", "Ciężarówki towarowe", "Utrzymanie dróg",
                        "Utrzymanie parków", "Pojazdy utrzymania", "Wozy strażackie", "Radiowozy", "Furgonetki pocztowe",
                        "Karetki", "Karawany", "Transport więźniów", "Pojazdy ewakuacyjne", "Taksówki", "Transport",
                        "Pociągi pasażerskie", "Pociągi towarowe", "Pociągi", "Samoloty", "Śmigłowce", "Statki powietrzne",
                        "Jednostki pływające", "Rowery", "Piesi", "Inne",
                    };
                case "pt":
                    return new[]
                    {
                        "Carros", "Caminhões de entrega", "Caminhões de lixo", "Caminhões de carga", "Manutenção de vias",
                        "Manutenção de parques", "Veículos de manutenção", "Caminhões de bombeiros", "Viaturas policiais",
                        "Furgões dos correios", "Ambulâncias", "Carros funerários", "Transporte de presos", "Veículos de evacuação",
                        "Táxis", "Transporte", "Trens de passageiros", "Trens de carga", "Trens", "Aviões", "Helicópteros",
                        "Aeronaves", "Embarcações", "Bicicletas", "Pedestres", "Outros",
                    };
                case "ru":
                    return new[]
                    {
                        "Автомобили", "Грузовики доставки", "Мусоровозы", "Грузовые грузовики", "Дорожная служба",
                        "Обслуживание парков", "Служебный транспорт", "Пожарные машины", "Полицейские машины", "Почтовые фургоны",
                        "Скорые", "Катафалки", "Перевозка заключённых", "Эвакуационный транспорт", "Такси", "Транспорт",
                        "Пассажирские поезда", "Грузовые поезда", "Поезда", "Самолёты", "Вертолёты", "Воздушные суда",
                        "Суда", "Велосипеды", "Пешеходы", "Прочее",
                    };
                case "zh-Hans":
                    return new[]
                    {
                        "汽车", "配送卡车", "垃圾车", "货运卡车", "道路养护", "公园养护", "养护车辆", "消防车", "警车", "邮政车",
                        "救护车", "灵车", "囚犯运输", "疏散车辆", "出租车", "公共交通", "客运列车", "货运列车", "列车", "飞机",
                        "直升机", "航空器", "船只", "自行车", "行人", "其他",
                    };
                case "zh-Hant":
                    return new[]
                    {
                        "汽車", "配送卡車", "垃圾車", "貨運卡車", "道路養護", "公園養護", "養護車輛", "消防車", "警車", "郵政車",
                        "救護車", "靈車", "囚犯運輸", "疏散車輛", "計程車", "大眾運輸", "客運列車", "貨運列車", "列車", "飛機",
                        "直升機", "航空器", "船隻", "自行車", "行人", "其他",
                    };
                default:
                    return new[]
                    {
                        "Cars", "Delivery trucks", "Garbage trucks", "Cargo trucks", "Road maintenance", "Park maintenance",
                        "Maintenance vehicles", "Fire engines", "Police cars", "Post vans", "Ambulances", "Hearses",
                        "Prisoner transport", "Evacuation vehicles", "Taxis", "Transit", "Passenger trains", "Cargo trains",
                        "Trains", "Airplanes", "Helicopters", "Aircraft", "Watercraft", "Bicycles", "Pedestrians", "Other",
                    };
            }
        }
    }
}
