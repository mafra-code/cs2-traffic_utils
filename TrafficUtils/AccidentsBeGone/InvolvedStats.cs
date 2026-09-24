namespace AccidentsBeGone
{
    using System;
    using Game.SceneFlow;

    /// <summary>
    /// Exclusive object classes for the Options rows. Values are slot indices.
    /// Same order as Jam Threshold so the rows read the same way.
    /// </summary>
    internal enum InvolvedKind
    {
        Car = 0,
        DeliveryTruck = 1,
        GarbageTruck = 2,
        CargoTruck = 3,
        RoadMaintenance = 4,
        ParkMaintenance = 5,
        Maintenance = 6,
        FireEngine = 7,
        PoliceCar = 8,
        PostVan = 9,
        Ambulance = 10,
        Hearse = 11,
        PrisonerTransport = 12,
        Evacuation = 13,
        Taxi = 14,
        Transit = 15,
        PassengerTrain = 16,
        CargoTrain = 17,
        Train = 18,
        Airplane = 19,
        Helicopter = 20,
        Aircraft = 21,
        Watercraft = 22,
        Bicycle = 23,
        Pedestrian = 24,
        Other = 25,
    }

    /// <summary>
    /// Session counts of objects that gained <c>InvolvedInAccident</c>, plus the rate per
    /// in-game hour. Main thread only. Not written to the settings file.
    /// </summary>
    internal static class InvolvedStats
    {
        internal const int KindCount = (int)InvolvedKind.Other + 1;

        internal const string ClearedId = "AccidentsBeGone.Stats.Cleared";
        internal const string RateId = "AccidentsBeGone.Stats.Rate";
        internal const string KindRateId = "AccidentsBeGone.Stats.KindRate";
        internal const string RateUnknownId = "AccidentsBeGone.Stats.RateUnknown";

        private const double MinHoursForRate = 0.05;

        private static readonly int[] s_Counts = new int[KindCount];
        private static readonly int[] s_PublishedKindRates = new int[KindCount];

        private static int s_Total;
        private static double s_ElapsedHours;
        private static int s_PublishedTotal = -1;
        private static int s_PublishedRate = -1;
        private static bool s_ResetPending;

        internal static int UiVersion { get; private set; }

        internal static void Add(int kind)
        {
            if (kind < 0 || kind >= KindCount)
            {
                kind = (int)InvolvedKind.Other;
            }

            s_Counts[kind]++;
            s_Total++;
        }

        internal static void Publish(double elapsedHours)
        {
            s_ElapsedHours = elapsedHours;
            int rate = CurrentRate();
            bool changed = s_Total != s_PublishedTotal || rate != s_PublishedRate;
            if (!changed)
            {
                for (int i = 0; i < KindCount; i++)
                {
                    if (CurrentKindRate(i) != s_PublishedKindRates[i])
                    {
                        changed = true;
                        break;
                    }
                }
            }

            if (!changed)
            {
                return;
            }

            s_PublishedTotal = s_Total;
            s_PublishedRate = rate;
            for (int i = 0; i < KindCount; i++)
            {
                s_PublishedKindRates[i] = CurrentKindRate(i);
            }

            UiVersion++;
        }

        internal static void RequestReset()
        {
            ResetNow();
            s_ResetPending = true;
        }

        internal static void ResetNow()
        {
            for (int i = 0; i < KindCount; i++)
            {
                s_Counts[i] = 0;
                s_PublishedKindRates[i] = -1;
            }

            s_Total = 0;
            s_ElapsedHours = 0.0;
            s_PublishedTotal = -1;
            s_PublishedRate = -1;
            s_ResetPending = false;
            UiVersion++;
        }

        internal static bool ConsumePendingReset()
        {
            if (!s_ResetPending)
            {
                return false;
            }

            s_ResetPending = false;
            return true;
        }

        internal static string FormatCleared()
        {
            return TryLocalize(ClearedId, "{TOTAL} objects")
                .Replace("{TOTAL}", s_Total.ToString());
        }

        internal static string FormatRate()
        {
            int rate = CurrentRate();
            if (rate < 0)
            {
                return TryLocalize(RateUnknownId, "—");
            }

            return TryLocalize(RateId, "~{RATE} objects / in-game hour")
                .Replace("{RATE}", rate.ToString());
        }

        internal static string FormatKindRate(InvolvedKind kind)
        {
            int rate = CurrentKindRate((int)kind);
            if (rate < 0)
            {
                return TryLocalize(RateUnknownId, "—");
            }

            return TryLocalize(KindRateId, "~{RATE} / in-game hour")
                .Replace("{RATE}", rate.ToString());
        }

        internal static string FormatCount(InvolvedKind kind)
        {
            return s_Counts[(int)kind].ToString();
        }

        internal static bool IsZero(InvolvedKind kind)
        {
            return s_Counts[(int)kind] == 0;
        }

        private static int CurrentRate()
        {
            return RateFromCount(s_Total);
        }

        private static int CurrentKindRate(int kind)
        {
            return RateFromCount(s_Counts[kind]);
        }

        private static int RateFromCount(int count)
        {
            if (s_ElapsedHours < MinHoursForRate)
            {
                return -1;
            }

            return (int)Math.Round(count / s_ElapsedHours);
        }

        private static string TryLocalize(string id, string fallback)
        {
            GameManager gameManager = GameManager.instance;
            if (gameManager?.localizationManager?.activeDictionary != null
                && gameManager.localizationManager.activeDictionary.TryGetValue(id, out string value)
                && !string.IsNullOrEmpty(value))
            {
                return value;
            }

            return fallback;
        }
    }
}
