using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using _2QXRunning.ViewModels.Home;

namespace _2QXRunning.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            CategorieCourseDal categorieCourseDal = new CategorieCourseDal();
            categorieCourseDal.GetAll();
            HomeModel accueilModel = new HomeModel(categorieCourseDal.GetAll());
            return View(accueilModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}