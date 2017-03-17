using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class TypeDePaiement : Entite
    {
        [Required]
        [DisplayName("Type de paiement")]
        public string Nom { get; set; }

        public List<Evenement> Evenements { get; set; }
    }
}
