using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using Common.DAL;
using System.Data.Entity;
using System.Diagnostics.PerformanceData;

namespace DAL
{
    public class CourseDal : AbstractDalAutoIncrement<Course, ApplicationDbContext>
    {
        public List<Course> GetByEvenement(Evenement evenement)
        {
            List<Course> courses = new List<Course>();

            using (ApplicationDbContext e = new ApplicationDbContext())
            {
                courses = e.Set<Course>().Where(c => c.Evenement.Id == evenement.Id).Where(c => c.Statut == Statut.InscriptionEnCours).ToList();
            }

            return courses;
        }

        public List<Course> GetCourseByStatutAndUserId(Statut statutCourse, string userId)
        {
            using (ApplicationDbContext entities = new ApplicationDbContext())
            {
                List<Course> courses = (from course in entities.Course
                                        join categorie in entities.CategorieCourse on course.Categorie.Id equals categorie.Id
                                        where course.Statut == statutCourse
                                        select course).Include(c => c.Categorie).ToList();

                return courses;
            }
                
        }

        public override List<Course> GetAll()
        {
            List<Course> courses = new List<Course>();
            using (ApplicationDbContext course = new ApplicationDbContext())
            {
                courses = course.Set<Course>().Include(c => c.Evenement).Include(c => c.Evenement.Ville.Departement).ToList();
            }

            return courses;
        }



        public List<Course> GetCourseStatutTerminee()
        {
            List<Course> courses = new List<Course>();
            using (ApplicationDbContext course = new ApplicationDbContext())
            {
                courses = course.Set<Course>().Include(c => c.Evenement).Include(c => c.Evenement.Ville.Departement).Where(c => c.Statut == Statut.Terminé).ToList();
            }

            return courses;
        }
        public List<Course> GetCourseAVenir()
        {
            List<Course> courses = new List<Course>();
            using (ApplicationDbContext course = new ApplicationDbContext())
            {
                courses = course.Set<Course>().Include(c => c.Evenement).Include(c => c.Evenement.Ville.Departement).Where(c => c.Statut == Statut.InscriptionEnCours).ToList();
            }

            return courses;
        }
        

        public override int Insert(Course c)
        {
            using (ApplicationDbContext entities = new ApplicationDbContext())
            {
                int i = -1;
                entities.Entry<Course>(c).State = EntityState.Added;
                entities.CategorieCourse.Attach(c.Categorie);
                entities.Evenement.Attach(c.Evenement);
                entities.Users.Attach(c.Evenement.Createur);
                entities.Entry<Evenement>(c.Evenement).State = EntityState.Detached;

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

        public override int Update(Course c)
        {
            using (ApplicationDbContext entities = new ApplicationDbContext())
            {
                int i = -1;
                entities.Entry<Course>(c).State = EntityState.Modified;
                entities.CategorieCourse.Attach(c.Categorie);
                entities.Evenement.Attach(c.Evenement);
                entities.Users.Attach(c.Evenement.Createur);
                entities.Entry<Evenement>(c.Evenement).State = EntityState.Detached;

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

        public override Course GetById(int id)
        {

            using (ApplicationDbContext entities = new ApplicationDbContext())
            {
                return entities.Set<Course>()
                    .Where(c => c.Id == id)
                    .Include(c => c.Evenement)
                    .Include(c => c.Evenement.Ville)
                    .Include(c => c.Evenement.TypeManifestation)
                    .Include(c => c.Evenement.Createur)
                    .Include(c => c.Evenement.Ville.Departement)
                    .Include(c => c.Categorie)
                    .FirstOrDefault();
            }
        }
    }
}
