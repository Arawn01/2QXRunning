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
    public class CourseMgt : AbstractMgt<Course, int>
    {
        public override IDal<Course, int> Dal
        {
            get
            {
                return new CourseDal();
            }
        }

        public List<Course> GetByEvenement(Evenement evenement)
        {
            return ((CourseDal)Dal).GetByEvenement(evenement);
        }

        public List<Course> GetCourseByStatutAndUserId(Statut statutCourse, string userId)
        {
            return ((CourseDal)Dal).GetCourseByStatutAndUserId(statutCourse, userId);
        }

        public List<Course> GetCourseStatutTerminee()
        {
            return ((CourseDal)Dal).GetCourseStatutTerminee();
        }

        public List<Course> GetCourseAVenir()
        {
            return ((CourseDal)Dal).GetCourseAVenir();
        }
        

    }
}
