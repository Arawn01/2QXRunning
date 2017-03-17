using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _2QXRunning.ViewModels.EspacePerso
{
    public class EspacePersoViewModels
    {
        public class ChangeEmailViewModel
        {
            [Display(Name = "Email actuel")]
            public string AncienEmail { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "Le {0} doit compter au moins {2} caractères.", MinimumLength = 6)]
            [EmailAddress]
            [Display(Name = "Nouvel email")]
            public string NouvelEmail { get; set; }
        }
    }
}