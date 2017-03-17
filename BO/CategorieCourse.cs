using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace BO
{
    [Table("CategorieCourse")]
    public class CategorieCourse : Entite 
    {
        #region Constantes
        public const int MinLibelleLength = 5;
        public const int MaxLibelleLength = 200;
        #endregion

        public string Libelle { get; set; }

        public override string ToString()
        {
            return Libelle;
        }
    }

    
}
