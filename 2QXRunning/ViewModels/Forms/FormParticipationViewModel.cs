using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BO;
using _2QXRunning.Ressources;

namespace _2QXRunning.ViewModels.Forms
{
    public class FormParticipationViewModel
    {
        [Required(ErrorMessageResourceType = typeof(RessourcesViewModels), ErrorMessageResourceName = "required_Titre")]
 
        public List<TypeDePaiement> TypesDePaiement { get; set; }
        public Boolean CertificatFourni { get; set; }

    }

}