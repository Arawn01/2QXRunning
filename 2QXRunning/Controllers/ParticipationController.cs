using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using BLL;
using BO;
using Common.Tools.Helper.Object;
using Common.ViewModels.Lists;
using DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using _2QXRunning.ViewModels.Forms;

namespace _2QXRunning.Controllers
{
    public class ParticipationController : Controller
    {
        public ActionResult Index(int courseId)
        {
            HttpContext.User.Identity.GetUserId();

            ParticipationMgt participationMgt = new ParticipationMgt();
            try
            {
                ListViewModel<Participation> vm = new ListViewModel<Participation>("Participations",
                    "Les participations", participationMgt.GetByCourseId(courseId));
                return View(vm);
            }
            catch (Exception e)
            {
                // TODO : Afficher page erreur avec e.Message
                return Content(e.Message);
            }


        }

        public ActionResult Create(int courseId)
        {
            if (User.Identity.IsAuthenticated)
            {
                ParticipationMgt mgt = new ParticipationMgt();
                ApplicationUser user =
                        HttpContext.GetOwinContext()
                            .GetUserManager<ApplicationUserManager>()
                            .FindById(User.Identity.GetUserId());
                CourseMgt courseMgt = new CourseMgt();

                

                try
                {
                    //ApplicationDbContext entities = new ApplicationDbContext();
                    Participation p = new Participation();
                    p.ApplicationUser = user;
                    p.Course = courseMgt.GetById(courseId);
                    p.Paye = false;
                    p.CertificatFourni = false;
                    mgt.Insert(p);
                 
                }
                catch (ApplicationException ex)
                {
                    // TODO : Afficher page erreur avec e.Message
                    ModelState.AddModelError("error", ex.Message);
                }
            }
            else
            {

                return RedirectToAction("Login", "Account", null);
            }
            return RedirectToAction("Index", "Evenement");
        }
        /// <summary>
        /// Retourne la liste des courses terminées auquelles l'utilisateur a participé
        /// </summary>
        /// <returns></returns>
        public JsonResult ResultatsUtilisateur()
        {
            CourseMgt courseMgt = new CourseMgt();
            ParticipationMgt participationMgt = new ParticipationMgt();

            return Json(courseMgt.GetCourseByStatutAndUserId(Statut.Terminé, User.Identity.GetUserId()));
        }

    }



}
