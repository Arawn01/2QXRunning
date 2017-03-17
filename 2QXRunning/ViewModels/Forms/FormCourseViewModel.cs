using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BO;
using _2QXRunning.Ressources;
using System.Web.Mvc;

namespace _2QXRunning.ViewModels.Forms
{
    public class FormCourseViewModel
    {
        [Required(ErrorMessageResourceType = typeof(RessourcesViewModels), ErrorMessageResourceName = "required_Evenement")]
        public Evenement Evenement { get; set; }

        public int EvenementId { get; set; }

        [Required(ErrorMessageResourceType = typeof(RessourcesViewModels), ErrorMessageResourceName = "required_Titre")]
        [StringLength(Course.MaxTitreLength, MinimumLength = Course.MinTitreLength)]
        public string Titre { get; set; }

        [Required(ErrorMessageResourceType = typeof(RessourcesViewModels), ErrorMessageResourceName = "required_Description")]
        [StringLength(Course.MaxDescriptionLength, MinimumLength = Course.MinDescriptionLength)]
        public string Description { get; set; }

        [Required(ErrorMessageResourceType = typeof(RessourcesViewModels), ErrorMessageResourceName = "required_Date")]
        [Display(Name = "DateDepart", ResourceType = typeof(RessourcesViewModels))]
        public DateTime DateDepart { get; set; } = DateTime.Now;
    
        [Required(ErrorMessageResourceType = typeof(RessourcesViewModels), ErrorMessageResourceName = "required_Statut")]
        public Statut Statuts { get; set; }

        [Required(ErrorMessageResourceType = typeof(RessourcesViewModels), ErrorMessageResourceName = "required_Tarif")]
        public double? Tarif { get; set; }

        public List<SelectListItem> Categories { get; set; }
      
        public int CategorieId { get; set; }

        public float? Distance { get; set; }

        public int CourseId { get; set; }
    }
}