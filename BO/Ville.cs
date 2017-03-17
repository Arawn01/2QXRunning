using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BO
{
    [Table("Ville")]
    public class Ville : Entite
    {
        [Required]
        public Departement Departement { get; set; }
        [DisplayName("Ville")]
        [Required]
        public string Nom { get; set; }
        [Required]
        public string CodePostal { get; set; }
    }
}
