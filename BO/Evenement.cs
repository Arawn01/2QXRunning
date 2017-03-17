using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.ComponentModel;

namespace BO
{
    [Table("Evenement")]
    public class Evenement : Entite
    {
        #region Constantes
        public const int MinTitreLength = 5;
        public const int MaxTitreLength = 200;
        public const int MinDescriptionLength = 20;
        public const int MaxDescriptionLength = 200;
        #endregion

        public Evenement()
        {
            TypesDePaiement = new List<TypeDePaiement>();
        }

        [ForeignKey("Ville")]
        public int VilleId { get; set; }
        [ForeignKey("TypeManifestation")]
        public int TypeManifestationId { get; set; }
        [ForeignKey("Createur")]
        public string CreateurId { get; set; }
        [ForeignKey("TypesDePaiement")]
        public List<int> TypesDePaiementIds { get; set; }


        [Required]
        public string Titre { get; set; }
        public string Description { get; set; }
        [Required]
        public Ville Ville { get; set; }
        [Required]
        public TypeManifestation TypeManifestation { get; set; }
        [Required]
        public ApplicationUser Createur { get; set; }

        public List<Course> Courses { get; set; }

        [DisplayName("Types de paiement")]
        public ICollection<TypeDePaiement> TypesDePaiement { get; set; }

    }
}
