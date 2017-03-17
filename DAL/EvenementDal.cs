using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DAL;
using System.Data.Entity;

namespace DAL
{
    public class EvenementDal : AbstractDalAutoIncrement<Evenement, ApplicationDbContext>
    {
        public override List<Evenement> GetAll()
        {
            using (ApplicationDbContext entities = new ApplicationDbContext())
            {
                return entities.Set<Evenement>()
                    .Include(e => e.Createur)
                    .Include(e => e.TypeManifestation)
                    .Include(e => e.TypesDePaiement)
                    .Include(e => e.Ville)
                    .Include(e => e.Ville.Departement)
                    .ToList();
            }
        }

        public List<Evenement> GetAllEvenementsAVenir()
        {
            using (ApplicationDbContext entities = new ApplicationDbContext())
            {
                return entities.Set<Evenement>()
                    .Where(e => e.Courses.Any(course => course.Statut == Statut.InscriptionEnCours))
                    .Include(e => e.Createur)
                    .Include(e => e.TypeManifestation)
                    .Include(e => e.TypesDePaiement)
                    .Include(e => e.Ville)
                    .Include(e => e.Ville.Departement)
                    .ToList();
            }
        }


        public override Evenement GetById(int id)
        {
            using (ApplicationDbContext entities = new ApplicationDbContext())
            {
                return entities.Set<Evenement>()
                    .Where(e => e.Id == id)
                    .Include(e => e.Createur)
                    .Include(e => e.TypeManifestation)
                    .Include(e => e.TypesDePaiement)
                    .Include(e => e.Ville)
                    .Include(e => e.Ville.Departement)
                    .Include(e => e.TypesDePaiement)
                    .FirstOrDefault();
            }
        }

     

        public List<Evenement> GetByCreateur(string idCreateur)
        {
            List<Evenement> evenements = new List<Evenement>();


            using (ApplicationDbContext e = new ApplicationDbContext())
            {
                evenements = e.Set<Evenement>().Where(evnt => evnt.Createur.Id == idCreateur).ToList();
            }

            return evenements;
        }

        public List<Evenement> GetByVilleIdAndCategorieCourseIdAndIntervalle(int villeId, int categorieCourseId, DateTime dateStart, DateTime dateStop)
        {
            using (ApplicationDbContext entities = new ApplicationDbContext())
            {
                List<Evenement> evenements = (from evenement in entities.Evenement
                               join course in entities.Course on evenement.Id equals course.Evenement.Id
                               where evenement.Ville.Id == villeId && course.Categorie.Id == categorieCourseId && course.DateDepart > dateStart && course.DateDepart < dateStop 
                               select evenement).Include(e => e.Ville.Departement).ToList();

                return evenements;
            }
        }

        public override int Insert(Evenement e)
        {
            using (ApplicationDbContext entities = new ApplicationDbContext())
            {
                int i = -1;
                entities.Entry<Evenement>(e).State = EntityState.Added;
                entities.Entry<ApplicationUser>(e.Createur).State = EntityState.Unchanged;

                try
                {
                    i = entities.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return i;
            }
        }
    }
}
