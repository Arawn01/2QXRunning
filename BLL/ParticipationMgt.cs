using BO;
using Common.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DAL;
using DAL;

namespace BLL
{
    public class ParticipationMgt : AbstractMgt<Participation, int>
    {
        public override IDal<Participation, int> Dal
        {
            get
            {
                return new ParticipationDal();
            }
        }

        public List<Participation> GetByUtilisateur(ApplicationUser user)
        {
            List<Participation> participations = new List<Participation>();

            participations = ((ParticipationDal)Dal).GetByUtilisateur(user);

            return participations;
        }

        public List<Participation> GetByUserIdWithTempsNotNull(string userId)
        {
            return new List<Participation>();
        }

        public List<Participation> GetByCourse(Course course)
        {
            List<Participation> participations = new List<Participation>();

            participations = ((ParticipationDal)Dal).GetByCourse(course);

            return participations;
        }

        public List<Participation> GetByCourseId(int courseId)
        {
            List<Participation> participations = new List<Participation>();

            participations = ((ParticipationDal)Dal).GetByCourseId(courseId);

            return participations;
        }

        public int NombreDeParticipantsParCourse(int id)
        {
            List<Participation> participations = new List<Participation>();

            participations = ((ParticipationDal)Dal).GetByCourseId(id);

            return participations.Count;
        }
        /// <summary>
        /// Renvoie BO.Participation sinon NULL;
        /// </summary>
        /// <param name="user"></param>
        /// <param name="course"></param>
        /// <returns></returns>
        public Participation GetParticipation(string userId, Course course)
        {
            return ((ParticipationDal)Dal).GetParticipationByUserIdAndCourse(userId, course);
        }

        
    }
}
