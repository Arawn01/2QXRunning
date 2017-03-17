using System.Collections.Generic;
using System.Web.Mvc;
using BO;
using BO.Enums;
using _2QXRunning.Ressources;

namespace _2QXRunning.ViewModels.Home
{
    public class HomeModel
    {
        public SelectList ListCategoriesCourses { get; set; }
        public List<SelectListItem> ListIntervalleTemps { get; set; } = new List<SelectListItem>();
        public string CategorieCourseId { get; set; }
        public string IntervalleTempsId { get; set; }
        public int VilleId { get; set; }

        public HomeModel()
        {
            
        }

        public HomeModel(List<CategorieCourse> pListeCategorieCourses)
        {
            VilleId = -1;
            ListIntervalleTemps.Add(new SelectListItem() { Value = Enums.IntervalleTemps.WeekEndProchain.ToString("D"), Text = RessourcesViewModels.intervalle_weekEndProchain});
            ListIntervalleTemps.Add(new SelectListItem() { Value = Enums.IntervalleTemps.TrenteProchainsJours.ToString("D"), Text = RessourcesViewModels.intervalle_30ProchainsJours });
            ListIntervalleTemps.Add(new SelectListItem() { Value = Enums.IntervalleTemps.SixProchainsMois.ToString("D"), Text = RessourcesViewModels.intervalle_6ProchainsMois });
            ListIntervalleTemps.Add(new SelectListItem() { Value = Enums.IntervalleTemps.DouzeProchainsMois.ToString("D"), Text = RessourcesViewModels.intervalle_12ProchainsMois });
            ListCategoriesCourses = new SelectList(pListeCategorieCourses, "Id", "Libelle");
        }
    }

    
}