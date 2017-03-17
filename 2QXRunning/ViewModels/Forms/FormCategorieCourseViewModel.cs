using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BO;
using _2QXRunning.Ressources;

namespace _2QXRunning.ViewModels.Forms
{
    public class FormCategorieCourseViewModel
    {
        [Required(ErrorMessageResourceType = typeof(RessourcesViewModels), ErrorMessageResourceName = "required_Libelle")]
        [StringLength(CategorieCourse.MaxLibelleLength, MinimumLength = CategorieCourse.MinLibelleLength)]
        public string Libelle { get; set; }
    }
}