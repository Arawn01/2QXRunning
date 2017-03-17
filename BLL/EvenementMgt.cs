using BO;
using Common.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using BO.Enums;
using DAL;
using Common.DAL;
using Common.Tools;

namespace BLL
{
    public class EvenementMgt : AbstractMgt<Evenement, int>
    {
        public override IDal<Evenement, int> Dal
        {
            get
            {
                return new EvenementDal();
            }
        }

        public List<Evenement> GetByCreateur(string idCreateur)
        {
            return ((EvenementDal)Dal).GetByCreateur(idCreateur);
        }



        public List<Evenement> GetByVilleIdAndCategorieCourseIdAndIntervalleTemps(int villeId, string categorieCourse, string intervalleTemps)
        {
            int intervalleTempsId = 0;
            if (int.TryParse(intervalleTemps, out intervalleTempsId))
            {
                int categorieCourseId = 0;
                if (int.TryParse(categorieCourse, out categorieCourseId))
                {
                    switch ((Enums.IntervalleTemps)intervalleTempsId)
                    {
                        case Enums.IntervalleTemps.WeekEndProchain:
                            return ((EvenementDal)Dal).GetByVilleIdAndCategorieCourseIdAndIntervalle(villeId, categorieCourseId, DateTools.GetNextWeekday(DateTime.Now, DayOfWeek.Saturday), DateTools.GetNextWeekday(DateTime.Now, DayOfWeek.Monday));
                        case Enums.IntervalleTemps.TrenteProchainsJours:
                            return ((EvenementDal)Dal).GetByVilleIdAndCategorieCourseIdAndIntervalle(villeId, categorieCourseId, DateTime.Now, DateTime.Now.AddMonths(1));
                        case Enums.IntervalleTemps.SixProchainsMois:
                            return ((EvenementDal)Dal).GetByVilleIdAndCategorieCourseIdAndIntervalle(villeId, categorieCourseId, DateTime.Now, DateTime.Now.AddMonths(6));
                        case Enums.IntervalleTemps.DouzeProchainsMois:
                            return ((EvenementDal)Dal).GetByVilleIdAndCategorieCourseIdAndIntervalle(villeId, categorieCourseId, DateTime.Now, DateTime.Now.AddYears(1));
                    }
                }
                else
                {
                    //TODO Logs ici CATEGORIE COURSE doit pouvoir être parser en int
                }
            }
            else
            {
                //TODO Logs ici INTERVALLE TEMPS doit pouvoir être parser en int
            }
            return null;
        }
        
        /// <summary>
        /// Connaître si un type de paiement est dans l'évènement
        /// </summary>
        /// <param name="Evenement"></param>
        /// <param name="TypeDePaiement"></param>
        /// <returns></returns>
        public bool ATypeDePaiement(Evenement Evenement, TypeDePaiement TypeDePaiement)
        {
            List<int> idsTypeDePaiementEvenement = new List<int>();

            if (Evenement != null && TypeDePaiement != null)
            {
                foreach(TypeDePaiement typesPaiement in Evenement.TypesDePaiement)
                {
                    idsTypeDePaiementEvenement.Add(typesPaiement.Id);
                }
            }

            return idsTypeDePaiementEvenement.Contains(TypeDePaiement.Id);
        }

        /// <summary>
        /// Récupère la première date de l'évenement passé en paramètre
        /// </summary>
        /// <param name="evenement"></param>
        /// <returns></returns>
        public static DateTime? GetDateEvenement(Evenement evenement)
        {
            CourseMgt courseMgt = new CourseMgt();
            List<Course> courses = courseMgt.GetByEvenement(evenement);
            if (courses.Count > 0)
            {
                return (from c in courseMgt.GetByEvenement(evenement) select c.DateDepart).Min();
            }
            return null;
            
        }


        public List<Evenement> GetAllEvenementsAVenir()
        {
            return ((EvenementDal)Dal).GetAllEvenementsAVenir();
        }
            /**
        public List<Evenement> GetEvenementEnCours(List<Evenement> evenements)
        {

            var test = (from evenement in evenements
                        where evenement.Courses.Any(c => c.Statut == Statut.InscriptionEnCours)
                        select evenement).ToList();

            return test;
            /**
            return (from evenement in evenements
                    where evenement.Courses.Any(c => c.Statut == Statut.InscriptionEnCours)
                    select evenement).ToList(); 
            
        }
            **/
    }
}
