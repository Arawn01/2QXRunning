using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BO;
using _2QXRunning.Ressources;
using System.ComponentModel;

namespace _2QXRunning.ViewModels.Forms
{
    public class FormEvenementViewModel
    {
        #region AFFICHAGE

        [DisplayName("Departement")]
        public int DepartementId { get; set; }

        public List<SelectListItem> Departements { get; set; }

        public List<SelectListItem> Villes { get; set; }

        public List<SelectListItem> TypeManifestations { get; set; }

        public List<SelectListItem> TypesDePaiement { get; set; }

        #endregion


        #region RECUPERATION DES DONNEES

        [DisplayName("Ville")]
        public int VilleId { get; set; }
        public int TypeManifestationsId { get; set; }
        public int EvenementId { get; set; }
        public List<int> TypeDePaiementIdSelectionnes { get; set; }

        #endregion

        // Utiliser pour l'affichage et la récupération
        public Evenement Evenement { get; set; }

    }
}