using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BO;
using Common.ViewModels.Lists;
using _2QXRunning.ViewModels.Forms;
using _2QXRunning.ViewModels.Home;
using _2QXRunning.ViewModels.Detail;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json.Linq;
using Microsoft.AspNet.Identity.EntityFramework;

namespace _2QXRunning.Controllers
{
    public class EvenementController : Controller
    {
        // GET: Evenement
        public ActionResult Index()
        {
            EvenementMgt evenementMgt = new EvenementMgt();
            try
            {
                ListViewModel<Evenement> lvm = new ListViewModel<Evenement>("Calendrier des évenements", string.Empty, evenementMgt.GetAllEvenementsAVenir());
                return View(lvm);
            }
            catch (Exception e)
            {
                // TODO : Afficher page erreur avec e.Message
                return Content(e.Message);
            }
            
        }

        [HttpPost]
        public ActionResult Recherche(HomeModel model)
        {
            EvenementMgt evenementMgt = new EvenementMgt();
            List<BO.Evenement> listEvenements =
                evenementMgt.GetByVilleIdAndCategorieCourseIdAndIntervalleTemps(model.VilleId, model.CategorieCourseId,
                    model.IntervalleTempsId);
            ListViewModel<Evenement> lvm = new ListViewModel<Evenement>("Calendrier des courses", string.Empty, listEvenements);
            return View("Index", lvm);
        }

        public ActionResult Create(int Id)
        {

            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");

            TypeManifestationMgt mgtTypeManifestation = new TypeManifestationMgt();
            DepartementMgt mgtDepartement = new DepartementMgt();
            TypeDePaiementMgt mgtTypeDePaiement = new TypeDePaiementMgt();
            EvenementMgt mgtEvenement = new EvenementMgt();

            FormEvenementViewModel fevm = new FormEvenementViewModel();
            
            if (Id != -1)
            {
                fevm.Evenement = mgtEvenement.GetById(Id);
                fevm.EvenementId = fevm.Evenement.Id;
            }
            else
            {
                fevm.EvenementId = -1;
            }

            fevm.TypeManifestations = new List<SelectListItem>();
            fevm.Departements = new List<SelectListItem>();
            fevm.TypesDePaiement = new List<SelectListItem>();

            mgtTypeManifestation.GetAll().ForEach(
                p => fevm.TypeManifestations.Add(
                    new SelectListItem() {
                        Text = p.Libelle,
                        Value = p.Id.ToString(),
                        Selected = (fevm.Evenement != null && fevm.Evenement.TypeManifestation != null && p.Id.Equals(fevm.Evenement.TypeManifestation.Id))
                    })
            );
            mgtDepartement.GetAll().OrderBy(p => p.Id).ToList().ForEach(
                p => fevm.Departements.Add(
                    new SelectListItem() {
                        Text = $"{p.Code} - {p.Nom}",
                        Value = p.Id.ToString(),
                        Selected = (fevm.Evenement != null && fevm.Evenement.Ville != null && p.Id.Equals(fevm.Evenement.Ville.Id))
                })
            );

            // Types de paiement
            mgtTypeDePaiement.GetAll().OrderBy(p => p.Id).ToList().ForEach(
                p => fevm.TypesDePaiement.Add(
                    new SelectListItem()
                    {
                        Text = p.Nom,
                        Value = p.Id.ToString(),
                        Selected = (mgtEvenement.ATypeDePaiement(fevm.Evenement, p))
                    })
            );
            

            // Création d'une selectItemList vide pour les ville (remplie en Ajax sur OnChange() de DD Departements)
            fevm.Villes = new List<SelectListItem>();
            if (fevm.Evenement != null && fevm.Evenement.Ville != null)
            {
                fevm.VilleId = fevm.Evenement.Ville.Id;
                if (fevm.Evenement.Ville.Departement != null)
                    fevm.DepartementId = fevm.Evenement.Ville.Departement.Id;
            }
            if (fevm.Evenement != null && fevm.Evenement.TypeManifestation != null)
                fevm.TypeManifestationsId= fevm.Evenement.TypeManifestation.Id;

            return View("FormEvenement", fevm);
        }

        public ActionResult Detail(int id)
        {
            EvenementMgt evenementMgt = new EvenementMgt();
            CourseMgt courseMgt = new CourseMgt();
            ParticipationMgt participationMgt = new ParticipationMgt();

            DetailEvenementViewModel vm = new DetailEvenementViewModel();

            vm.Evenement = evenementMgt.GetById(id);
            vm.CoursesDetail = new List<CourseDetail>();
            List<Course> courses = courseMgt.GetByEvenement(vm.Evenement);
            List<Participation> participations = new List<Participation>();

            foreach (Course course in courses)
            {
                CourseDetail cd = new CourseDetail()
                {
                    Course = course
                };

                Participation p = participationMgt.GetParticipation(User.Identity.GetUserId(), course);

                if (p == null)
                    cd.ParticipationUtilisateur = ParticipationUtilisateur.Non_inscrit;
                else
                {
                    if (p.Valider)
                        cd.ParticipationUtilisateur = ParticipationUtilisateur.Inscription_validée;
                    else
                        cd.ParticipationUtilisateur = ParticipationUtilisateur.En_attende_de_validation;
                }

                vm.CoursesDetail.Add(cd);
            }
            vm.DateDebut = EvenementMgt.GetDateEvenement(vm.Evenement);


                
            

            return View(vm);
        }



        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Enregistrer(FormEvenementViewModel vm)
        {
            EvenementMgt evenementMgt = new EvenementMgt();
            VilleMgt villeMgt = new VilleMgt();
            TypeManifestationMgt typeManifestationMgt = new TypeManifestationMgt();
            TypeDePaiementMgt typeDePaiementMgt = new TypeDePaiementMgt();
            Evenement e;

            if (vm.EvenementId != -1)
                e = evenementMgt.GetById(vm.EvenementId);
            else
            {
                e = new Evenement();
                UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                e.Createur = UserManager.FindById(User.Identity.GetUserId());
                e.CreateurId = User.Identity.GetUserId();
            }

            // En test car pas de courses pour l'instant
            e.Courses = new List<Course>();

            e.Titre = vm.Evenement.Titre;
            e.Description = vm.Evenement.Description;

            e.Ville = villeMgt.GetById(vm.VilleId);
            e.VilleId = e.Ville.Id;

            e.TypeManifestation = typeManifestationMgt.GetById(vm.TypeManifestationsId);
            e.TypeManifestationId = e.TypeManifestation.Id;

            e.TypesDePaiement = new List<TypeDePaiement>();
            e.TypesDePaiementIds = new List<int>();

            if (vm.TypeDePaiementIdSelectionnes == null)
                vm.TypeDePaiementIdSelectionnes = new List<int>();

            foreach (int TypeDePaiementId in vm.TypeDePaiementIdSelectionnes)
            {
                TypeDePaiement t = typeDePaiementMgt.GetById(TypeDePaiementId);
                e.TypesDePaiement.Add(t);
                e.TypesDePaiementIds.Add(t.Id);
            }



            if (vm.EvenementId != -1)
                evenementMgt.Update(e);
            else
                evenementMgt.Insert(e);

            return RedirectToAction("Detail", new { id = e.Id });
        }

    }
}