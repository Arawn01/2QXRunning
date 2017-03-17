using Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BO
{
    [Table("Point")]
    public class Point : Entite
    {
        [Required]
        public Course Course { get; set; }
        [Required]
        public int NumeroPoint { get; set; }
        [Required]
        public float Altitude { get; set; }
        [Required]
        public float Longitude { get; set; }
        [Required]
        public CategoriePoint CategoriePoint { get; set; }
        
    }
}
