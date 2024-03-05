using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace CourseShop.Domain.Entities.Shop
{
    public class CourseStep
    {
        [Key]
        public int IdCourseStep { get; set; }
        [Column(TypeName = "varchar(50)")]
        [Required(ErrorMessage = "Podaj nazwe")]
        [MaxLength(500, ErrorMessage = "Nazwa powininna zawierać maksymalnie 50 znaków")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(500)")]
        [Required(ErrorMessage = "Podaj opis")]
        [MaxLength(500, ErrorMessage = "Opis powinien zawierać maksymalnie 500 znaków")]
        public string Description { get; set; }
        [ForeignKey("Course")]
        public int IdCourse { get; set; }
        public virtual Course Course { get; set; }
    }
}
