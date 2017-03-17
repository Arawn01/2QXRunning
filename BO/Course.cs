using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace BO
{
    [Table("Course")]
    public class Course : Entite
    {
        #region Constantes
        public const int MinTitreLength = 5;
        public const int MaxTitreLength = 200;
        public const int MinDescriptionLength = 20;
        public const int MaxDescriptionLength = 200;
        #endregion

        public Evenement Evenement { get; set; }
        public string Titre { get; set; }
        public string Description { get; set; }
        public float Distance { get; set; }
        public DateTime DateDepart { get; set; }
        public Statut Statut { get; set; }
        public double Tarif { get; set; }
        public CategorieCourse Categorie { get; set; }
    }

    public enum Statut
    {
        InscriptionEnCours,
        EnCours,
        Terminé
    }
}
