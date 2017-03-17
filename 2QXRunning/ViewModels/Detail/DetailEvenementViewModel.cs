using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2QXRunning.ViewModels.Detail
{
    public enum ParticipationUtilisateur
    {
        Non_inscrit,
        En_attende_de_validation,
        Inscription_validée
    }

    public class CourseDetail
    {
        public Course Course { get; set; }
        public ParticipationUtilisateur ParticipationUtilisateur { get; set; }
    }

    public class DetailEvenementViewModel
    {
        public Evenement Evenement { get; set; }
        public List<CourseDetail> CoursesDetail { get; set; }

        public List<Course> Courses { get; set; }
        
        public DateTime? DateDebut { get; set; }
    }
}