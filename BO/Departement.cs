using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BO
{
    [Table("Departement")]
    public class Departement : Entite
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public string Nom { get; set; }
    }
}
