namespace JamThreshold
{
    using Setting = TrafficUtils.Setting;
    using System.Collections.Generic;
    using Colossal;

    /// <summary>
    /// AI-generated Options strings from the English meaning. Keys match <see cref="LocaleEN"/>.
    /// </summary>
    public class LocaleFR : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleFR(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(IList<IDictionaryEntryError> errors, Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                { m_Setting.GetSettingsLocaleID(), "Jam Threshold" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamToggleGroup), "Remplacement" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamThresholdGroup), "Seuils" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamStatsGroup), "Statistiques" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamRateGroup), "Cadence" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamVanillaGroup), "Vanilla" },
                { m_Setting.GetOptionGroupLocaleID(Setting.JamDebugGroup), "Debug" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamEnabled)), "Activé" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.JamEnabled)), "Lorsque c'est activé, le contrôle d'immobilisation d'origine du jeu est coupé et ce remplacement utilise les curseurs ci-dessous. Lorsque c'est désactivé, le comportement vanilla est rétabli. Cela ne réinitialise pas tout le trafic." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ChainDepth)), "Profondeur de chaîne" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ChainDepth)), "Une chaîne de véhicules bloqués est marquée coincée si c'est une boucle ou si elle est plus longue que cette valeur. Vanilla est 100. Par défaut 40 pour que les embouteillages plus courts commencent à disparaître." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.MaxStuckSpeed)), "Seuil de vitesse" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.MaxStuckSpeed)), "Octet de vitesse Blocker brut (~0,2 m/s par unité). Le parcours de la chaîne s'arrête si un véhicule est à cette valeur ou au-dessus. Vanilla 6 vaut environ 1,2 m/s." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ClearedText)), "Dégagés cette session" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ClearedText)), "Objets que ce remplacement a marqués comme bloqués depuis le chargement de la ville. Les passagers d'un véhicule sont comptés une fois, via le véhicule. Rouvrez cette page si les nombres semblent figés." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamRateText)), "Tous les objets" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.JamRateText)), "Objets dégagés par heure de jeu, pas par heure réelle. Le temps en pause ne compte pas. Affiché dès qu'assez de temps de jeu s'est écoulé." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCarText)), "Voitures" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamDeliveryTruckText)), "Camions de livraison" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamGarbageTruckText)), "Camions-poubelles" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCargoTruckText)), "Camions de fret" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamRoadMaintenanceText)), "Entretien des routes" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamParkMaintenanceText)), "Entretien des parcs" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamMaintenanceText)), "Véhicules d'entretien" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamFireEngineText)), "Camions de pompiers" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPoliceCarText)), "Voitures de police" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPostVanText)), "Camionnettes postales" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAmbulanceText)), "Ambulances" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamHearseText)), "Corbillards" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPrisonerTransportText)), "Transport de détenus" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamEvacuationText)), "Véhicules d'évacuation" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTaxiText)), "Taxis" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTransitText)), "Transports" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPassengerTrainText)), "Trains de passagers" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCargoTrainText)), "Trains de fret" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTrainText)), "Trains" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAirplaneText)), "Avions" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamHelicopterText)), "Hélicoptères" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAircraftText)), "Aéronefs" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamWatercraftText)), "Bateaux" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamBicycleText)), "Vélos" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPedestrianText)), "Piétons" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamOtherText)), "Autres" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCarRateText)), "Voitures" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamDeliveryTruckRateText)), "Camions de livraison" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamGarbageTruckRateText)), "Camions-poubelles" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCargoTruckRateText)), "Camions de fret" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamRoadMaintenanceRateText)), "Entretien des routes" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamParkMaintenanceRateText)), "Entretien des parcs" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamMaintenanceRateText)), "Véhicules d'entretien" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamFireEngineRateText)), "Camions de pompiers" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPoliceCarRateText)), "Voitures de police" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPostVanRateText)), "Camionnettes postales" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAmbulanceRateText)), "Ambulances" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamHearseRateText)), "Corbillards" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPrisonerTransportRateText)), "Transport de détenus" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamEvacuationRateText)), "Véhicules d'évacuation" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTaxiRateText)), "Taxis" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTransitRateText)), "Transports" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPassengerTrainRateText)), "Trains de passagers" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamCargoTrainRateText)), "Trains de fret" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamTrainRateText)), "Trains" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAirplaneRateText)), "Avions" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamHelicopterRateText)), "Hélicoptères" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamAircraftRateText)), "Aéronefs" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamWatercraftRateText)), "Bateaux" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamBicycleRateText)), "Vélos" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamPedestrianRateText)), "Piétons" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamOtherRateText)), "Autres" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamResetStats)), "Réinitialiser les statistiques" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.JamResetStats)), "Remet tous les compteurs à zéro et redémarre la mesure des heures de jeu. Ne change pas vos seuils et ne supprime aucun véhicule." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.JamResetStats)), "Remettre les statistiques à zéro ? Cela efface seulement les compteurs. Vos seuils et le trafic de votre ville ne sont pas touchés." },
                { ClearanceStats.ClearedId, "{TOTAL} objets" },
                { ClearanceStats.RateId, "~{RATE} objets / heure de jeu" },
                { ClearanceStats.KindRateId, "~{RATE} / heure de jeu" },
                { ClearanceStats.RateUnknownId, "—" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JamEnableDebugging)), "Debugging" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.JamEnableDebugging)), "Journaux détaillés de blocage dans Mods_JamThreshold.log. Ralentit le jeu tant que c'est activé. Désactivez pour la vitesse normale." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetToVanilla)), "Réinitialiser à vanilla" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetToVanilla)), "Désactive ce remplacement et utilise le contrôle d'immobilisation d'origine (chaîne 100, vitesse 6). N'enlève pas le trafic dans toute la ville. Vos curseurs sont conservés si vous réactivez le remplacement." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetToVanilla)), "Utiliser le contrôle d'immobilisation d'origine du jeu ? Les petits embouteillages resteront à nouveau jusqu'à ce que vous réactiviez ce mod. Cela n'enlève aucun véhicule." },
            };
        }

        public void Unload()
        {
            // IDictionarySource requires Unload; Colossal keeps the source for the session.
        }
    }
}
