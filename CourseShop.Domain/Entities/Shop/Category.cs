using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseShop.Domain.Entities.CMS;

namespace CourseShop.Domain.Entities.Shop
{
    public class Category
    {
        [Key]
        public int IdCategory { get; set; }

        [ForeignKey("MainCategory")]
        public int? IdMainCategory { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(500)")]
        [Required(ErrorMessage = "Podaj opis")]
        [MaxLength(500, ErrorMessage = "Opis powinien zawierać maksymalnie 500 znaków")]
        public string Description { get; set; }

        public virtual ICollection<Course> Courses { get; set; } 
        [InverseProperty("MainCategory")]
        
        public virtual ICollection<Category> SubCategories { get; set; } 
        public virtual Category MainCategory { get; set; }

    }
}
