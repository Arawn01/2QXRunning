using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace BO
{
    [Table("Participation")]
    public class Participation : Entite
    {
        public ApplicationUser ApplicationUser { get; set; }
        public Course Course { get; set; }
        public bool Valider { get; set; }
        public bool Paye { get; set; }
        public bool CertificatFourni { get; set; }
        public int NumeroDossard { get; set; }
        public int? TempsDeCourse { get; set; }

    }
}
