using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using _2QXRunning.ViewModels.EspacePerso;


namespace _2QXRunning.Controllers
{
    public class EspacePersoController : Controller
    {
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View("Index");
            }
            return RedirectToAction("Login", "Account");

        }

        public ActionResult AffichageResultats()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View("Resultats");
            }

            return RedirectToAction("Login", "Account");
        }

        public ActionResult DonneesPerso()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View("DonnesPerso");
            }
            return RedirectToAction("Login", "Account");

        }

        public ActionResult ChangeEmail()
        {
            if (User.Identity.IsAuthenticated)
            {
                EspacePersoViewModels.ChangeEmailViewModel model = new EspacePersoViewModels.ChangeEmailViewModel();
                model.AncienEmail = User.Identity.GetUserName();
                return View("ChangeEmail", model);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult ChangeEmail(EspacePersoViewModels.ChangeEmailViewModel model)
        {
            var userManager = Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = userManager.FindById(User.Identity.GetUserId());
            // change username and email
            user.UserName = model.NouvelEmail;
            user.Email = model.NouvelEmail;

            userManager.Update(user);


            HttpContext.GetOwinContext().Get<ApplicationSignInManager>().SignIn(user, isPersistent: false, rememberBrowser: false);

            return RedirectToAction("Index", new { Message = "Changement d'adresse E-mail effectué avec succès" });
        }
    }
}