using BO;
using Common.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;

namespace DAL
{
    public class ParticipationDal : AbstractDalAutoIncrement<Participation, ApplicationDbContext>
    {
        public List<Participation> GetByUtilisateur(ApplicationUser user)
        {
            using (ApplicationDbContext e = new ApplicationDbContext())
            {
                return e.Set<Participation>().Where(p => p.ApplicationUser == user).ToList();
            }
        }

        public List<Participation> GetByUtilisateurWithTemps(ApplicationUser user)
        {
            using (ApplicationDbContext e = new ApplicationDbContext())
            {
                return e.Set<Participation>().Where(p => p.ApplicationUser == user && p.TempsDeCourse != null).ToList();
            }
        }

        public List<Participation> GetByCourse(Course course)
        {
            using (ApplicationDbContext e = new ApplicationDbContext())
            {
                return e.Set<Participation>().OrderBy(p => p.TempsDeCourse).Where(p => p.Course.Id == course.Id).ToList();
            }
        }

        public List<Participation> GetByCourseId(int id)
        {
            using (ApplicationDbContext e = new ApplicationDbContext())
            {
                return e.Set<Participation>()
                        .OrderBy(p => p.TempsDeCourse)
                        .Where(p => p.Course.Id == id && p.Course.Statut == Statut.Terminé)
                        .Include(p => p.Course)
                        .Include(p => p.ApplicationUser)
                        .ToList();
            }
        }


        /// <summary>
        /// Renvoie BO.Participation sinon NULL;
        /// </summary>
        /// <param name="user"></param>
        /// <param name="course"></param>
        /// <returns></returns>
        public Participation GetParticipationByUserIdAndCourse(string userId, Course course)
        {
            Participation participation = null;

            using (ApplicationDbContext e = new ApplicationDbContext())
            {
                participation = e
                    .Set<Participation>()
                    .Where(p => p.ApplicationUser.Id.Equals(userId))
                    .FirstOrDefault(p => p.Course.Id == course.Id);
            }

            return participation;
        }

        public override int Insert(Participation p)
        {
            using (ApplicationDbContext entities = new ApplicationDbContext())
            {
                entities.Course.Attach(p.Course);
                entities.Evenement.Attach(p.Course.Evenement);
                entities.Entry<ApplicationUser>(p.ApplicationUser).State = EntityState.Unchanged;
                try
                {
                    entities.Set<Participation>().Add(p);
                    entities.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    string errorMessages = string.Join("; ", ex.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.ErrorMessage));
                    throw new DbEntityValidationException(errorMessages);
                }

                return 1;
            }
        }

    }
}
