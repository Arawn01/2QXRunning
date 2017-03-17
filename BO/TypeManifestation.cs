using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    [Table("TypeManifestation")]
    public class TypeManifestation : Entite
    {
        public string Libelle { get; set; }
    }
}
