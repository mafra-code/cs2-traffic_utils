namespace ResetTraffic
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
                { m_Setting.GetSettingsLocaleID(), "Reset Traffic" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetVehicles)), "Réinitialiser la sélection" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetVehicles)), "Une fois : retire les types cochés qui existent maintenant. Le trafic nouvellement apparu n'est pas touché. Fermez Options, puis réglez la vitesse sur 1." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetVehicles)), "Réinitialiser les véhicules et piétons cochés qui existent maintenant ? Le trafic nouvellement apparu ne sera pas retiré. Fermez Options, puis réglez la vitesse sur 1." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ProgressText)), "État" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ProgressText)), "Inactif ou en cours, plus restants / retirés / instantané. Rouvrez Options si la ligne ne se met pas à jour pendant un reset." },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetActionGroup), "Reset" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetFeedbackGroup), "Retours" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetDefaultsGroup), "Valeurs par défaut" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetMovingGroup), "Véhicules et piétons en mouvement" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetParkedGroup), "Stationnés" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetPaceGroup), "Rythme" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetKeybindingGroup), "Raccourci" },
                { m_Setting.GetOptionGroupLocaleID(Setting.ResetDebugGroup), "Debug" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingCars)), "Voitures" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingCars)), "Voitures personnelles en train de rouler." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingBicycles)), "Vélos" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingBicycles)), "Vélos actuellement en mouvement." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingTrains)), "Trains" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingTrains)), "Trains et métro actuellement en mouvement." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingPublicTransport)), "Transports en commun" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingPublicTransport)), "Bus, taxis et autres transports en commun en mouvement (pas les trains)." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingTrucks)), "Camions et services" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingTrucks)), "Camions de livraison, ordures, police, pompiers, poste, ambulances et similaires." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveMovingOther)), "Avions et bateaux" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveMovingOther)), "Avions, hélicoptères et bateaux actuellement en mouvement." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemovePedestrians)), "Piétons" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemovePedestrians)), "Cims à pied. Désactivé par défaut. Les personnes déjà dans un véhicule ne sont pas visées." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveParkedCars)), "Voitures stationnées" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveParkedCars)), "Voitures sur parkings, au bord des rues et dans les garages des bâtiments (y compris véhicules de service et de dépôt). Activé par défaut." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveParkedBicycles)), "Vélos stationnés" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveParkedBicycles)), "Vélos à l'arrêt. Activé par défaut." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveParkedTrains)), "Trains stationnés" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveParkedTrains)), "Trains dans les dépôts ou les gares de triage." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.RemoveParkedOther)), "Autres stationnés" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.RemoveParkedOther)), "Tout autre véhicule stationné (bateaux à quai, avions aux portes, et similaires)." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.VehiclesPerFrame)), "Entités par image" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.VehiclesPerFrame)), "Combien d'entités retirer par lot (1–64)." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.FrameInterval)), "Images extra entre les lots" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.FrameInterval)), "Attendre autant d'images d'affichage extra après chaque lot. 0 = chaque image, 4 ≈ quatre fois plus lent." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetHotkey)), "Raccourci de reset" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetHotkey)), "Touche pour lancer un reset sans ouvrir Options. Par défaut F9. Cliquez la touche, puis appuyez sur une nouvelle pour la changer." },
                { m_Setting.GetBindingKeyLocaleID(nameof(Setting.ResetHotkey)), "Réinitialiser la sélection" },
                { m_Setting.GetBindingMapLocaleID(), "Reset Traffic" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetBindings)), "Réinitialiser les raccourcis" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetBindings)), "Restaure le raccourci de reset sur F9." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetEnableDebugging)), "Debugging" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetEnableDebugging)), "Journaux de reset détaillés dans Mods_ResetTraffic.log. Ralentit le jeu tant que c'est activé. Désactivez pour la vitesse normale." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.ResetModSettings)), "Restaurer les valeurs par défaut" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.ResetModSettings)), "Restaure les filtres de type, les curseurs de rythme et le debugging à leurs valeurs d'origine. Ne change pas le raccourci et ne retire pas de trafic." },
                { m_Setting.GetOptionWarningLocaleID(nameof(Setting.ResetModSettings)), "Restaurer les filtres de type, les curseurs de rythme et le debugging aux valeurs par défaut ? Cela ne change pas le raccourci et ne retire pas de trafic." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.JoinDiscord)), "Rejoindre le Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.JoinDiscord)), "Ouvre l'invitation dans votre navigateur web, en dehors du jeu. Vos commentaires et retours sont les bienvenus : combien de temps a pris un reset complet, la population de votre ville et ce qui a cassé." },
                { ResetTrafficSystem.FinishDialogTitleId, "Reset Traffic" },
                { ResetTrafficSystem.FinishDialogOkId, "OK" },
                { ResetTrafficSystem.FinishDialogCountsId, "Restants {REMAINING}  ·  Retirés {REMOVED}  ·  Instantané {SNAPSHOT}" },
                { ResetTrafficSystem.StatusIdlePrefixId, "Inactif." },
                { ResetTrafficSystem.StatusIdleFreshId, "Inactif. Aucun reset dans cette session pour le moment." },
                { ResetTrafficSystem.StatusRunningId, "En cours." },
                { ResetTrafficSystem.StatusQueuedId, "En file d'attente. Fermez Options, puis réglez la vitesse sur 1." },
                { ResetTrafficSystem.StatusWaitingId, "En attente de la vitesse 1." },
                { ResetTrafficSystem.StatusNoTypesId, "Ignoré : aucun type n'est coché." },
                { ResetTrafficSystem.StatusNothingMatchedId, "Reset terminé : rien ne correspondait aux types cochés." },
                { ResetTrafficSystem.StatusSnapshotReadyId, "Instantané {SNAPSHOT}. Seules les entités listées sont retirées." },
                { ResetTrafficSystem.StatusProgressId, "En cours : {REMOVED} retirés, {REMAINING} restants." },
                { ResetTrafficSystem.StatusCompleteId, "Reset terminé : {REMOVED} entités." },
            };
        }

        public void Unload()
        {
            // IDictionarySource requires Unload; Colossal keeps the source for the session.
        }
    }
}
