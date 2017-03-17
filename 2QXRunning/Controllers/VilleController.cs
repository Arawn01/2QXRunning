using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using BO;

namespace _2QXRunning.Controllers
{
    public class VilleController : Controller
    {
        public JsonResult Search(string prefix)
        {

            VilleMgt villeMgt = new VilleMgt();

            //Récupère les villes contenant la chaine prefix
            var CityName = (from v in villeMgt.GetByNomLike(prefix)
                            select new { v.Id, v.Nom, v.CodePostal });
            return Json(CityName, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SearchByIdDepartement_NomStartsWith(int idDepartement, string rech)
        {
            VilleMgt villeMgt = new VilleMgt();

            //var CityName = (from v in 
            //                select new { v.Id, v.Nom, v.CodePostal });

            List<object> villes = new List<object>();

            foreach (Ville ville in villeMgt.GetByIdDepartement_NomStartsWith(idDepartement, rech, 20))
            {
                villes.Add(new
                {
                    value = ville.Id,
                    text = $"{ville.Nom} ({ville.CodePostal})",
                    selected = false
                });
            }

            return Json(villes, JsonRequestBehavior.AllowGet);
        }
    }
}