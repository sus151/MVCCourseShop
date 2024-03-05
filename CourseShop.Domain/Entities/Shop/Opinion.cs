using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseShop.Domain.Entities.Shop
{
    public class Opinion
    {
        [Key]
        public int IdOpinion { get; set; }

        [Required(ErrorMessage = "Podaj treść")]
        [MaxLength(500, ErrorMessage = "Treść może zawierać maksymalnie 500 znaków")]
        [Column(TypeName = "varchar(500)")]
        public string Content { get; set; }

        [Column(TypeName = "Date")]
        public DateTime Date { get; set; } = DateTime.UtcNow;

        [Required(ErrorMessage = "Podaj ocenę")]
        [Column(TypeName = "decimal(2,1)")]
        public decimal Rate { get; set; }

        [ForeignKey("Course")]
        public int? IdCourse { get; set; }

        public virtual Course Course { get; set; }
    }
}
