using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using BO;
using Common.ViewModels.Lists;
using DAL;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using _2QXRunning.ViewModels.Forms;

namespace _2QXRunning.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index()
        {
            CourseMgt courseMgt = new CourseMgt();
            try
            {
                ListViewModel<Course> vm = new ListViewModel<Course>("Courses", "Les courses", courseMgt.GetCourseAVenir());
                return View(vm);
            }
            catch (Exception e)
            {
                // TODO : Afficher page erreur avec e.Message
                return Content(e.Message);
            }
            
        }

        public ActionResult Resultats()
        {
            CourseMgt courseMgt = new CourseMgt();
            try
            {
                ListViewModel<Course> vm = new ListViewModel<Course>("Courses", "Les courses", courseMgt.GetCourseStatutTerminee());
                return View(vm);
            }
            catch (Exception e)
            {
                // TODO : Afficher page erreur avec e.Message
                return Content(e.Message);
            }

        }

        public ActionResult Create(int EvenementId, int CourseId)
        {
            FormCourseViewModel f = new FormCourseViewModel();
            CategorieCourseMgt mgtCategorieCourse = new CategorieCourseMgt();
            TypeDePaiementMgt mgtTypeDePaiementMgt = new TypeDePaiementMgt();
            CourseMgt mgtCourse = new CourseMgt();

            f.Categories = new List<SelectListItem>();

            mgtCategorieCourse.GetAll().ForEach(
            p => f.Categories.Add(
                new SelectListItem() { Text = p.Libelle, Value = p.Id.ToString() }));

            if (CourseId != -1)
            {
                Course c = mgtCourse.GetById(CourseId);
                if (c != null)
                {
                    f.CourseId = c.Id;
                    f.CategorieId = c.Categorie.Id;
                    f.DateDepart = c.DateDepart;
                    f.Description = c.Description;
                    f.EvenementId = c.Evenement.Id;
                    f.Tarif = c.Tarif;
                    f.Titre = c.Titre;
                    f.Distance = c.Distance;
                }
                else
                {
                    f.CourseId = -1;
                    f.EvenementId = EvenementId;
                }
            }

            return View("FormCourse", f);
           
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Enregistrer(FormCourseViewModel v)
        {
            Course c;
            CourseMgt mgtCourse = new CourseMgt();
            CategorieCourseMgt mgtCategorieCourse = new CategorieCourseMgt();
            EvenementMgt mgtEvement = new EvenementMgt();


            if (v.CourseId != -1)
                c = mgtCourse.GetById(v.CourseId);
            else
                c = new Course();


            c.Categorie = mgtCategorieCourse.GetById(v.CategorieId);
            c.DateDepart = v.DateDepart;
            c.Description = v.Description;
            c.Distance = v.Distance.Value;
            c.Evenement = mgtEvement.GetById(v.EvenementId);
            c.Statut = v.Statuts;
            c.Tarif = v.Tarif.Value;
            c.Titre = v.Titre;

            int nbUpdate = 0;

            if (v.CourseId != -1)
                nbUpdate = mgtCourse.Update(c);
            else
                nbUpdate = mgtCourse.Insert(c);

            return RedirectToAction("Detail", "Evenement", new { Id = v.EvenementId });
            
        }

        public ActionResult Delete(int CourseId, int EvenementId)
        {
            if (!User.Identity.IsAuthenticated)
                RedirectToAction("Login", "Account");

            CourseMgt mgtCourse = new CourseMgt();
            Course c;

            if (CourseId != -1)
            {
                c = mgtCourse.GetById(CourseId);
                if (c != null)
                    mgtCourse.Delete(c);
            }

            return RedirectToAction("Detail", "Evenement", new { Id = EvenementId });
        }

        /// <summary>
        /// Retourne la liste des courses non terminées auquelles l'utilisateur est inscrit
        /// </summary>
        /// <returns></returns>
        public ContentResult InscriptionsUtilisateur()
        {
            CourseMgt courseMgt = new CourseMgt();
            JsonSerializerSettings serializerSettings = new JsonSerializerSettings();
            serializerSettings.Converters.Add(new IsoDateTimeConverter());

            return Content(JsonConvert.SerializeObject(courseMgt.GetCourseByStatutAndUserId(Statut.InscriptionEnCours, User.Identity.GetUserId()), serializerSettings));
        }

        




    }
}