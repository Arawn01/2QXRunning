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
    [Table("CategoriePoint")]
    public class CategoriePoint : Entite
    {
        [Required]
        public string Libelle { get; set; }
    }
}
