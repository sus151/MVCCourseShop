using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseShop.Domain.Entities.CMS;

namespace CourseShop.Domain.Entities.Shop
{
    public class Course
    {
        [Key]
        public int IdCourse { get; set; }
        [Required(ErrorMessage = "Podaj kategorię")]
        [ForeignKey("Category")]
        public int IdCategory { get; set; }
        [Required(ErrorMessage = "Podaj poziom trudności")]
        [ForeignKey("DifficultyLevel")]
        public int IdDifficultyLevel { get; set; }
        [Required(ErrorMessage = "Podaj nazwę")]
        [MaxLength(50, ErrorMessage = "Nazwa powinna zawierać maksymalnie 50 znaków")]
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(1000)")]
        [Required(ErrorMessage = "Podaj opis")]
        [MaxLength(500, ErrorMessage = "Opis powinien zawierać maksymalnie 1000 znaków")]
        public string Description { get; set; }
        [Column(TypeName = "decimal(6,2)")]
        [Required(ErrorMessage = "Podaj cenę")]
        public decimal Price { get; set; }
        [Column(TypeName = "Date")]
        public DateTime AddedDate { get; set; } = DateTime.UtcNow;
        [Required(ErrorMessage = "Dodaj zdjęcie")]
        public byte[] CoursePicture { get; set; }

        public virtual Category Category { get; set; }
        public virtual DifficultyLevel DifficultyLevel { get; set; }
        public virtual ICollection<CourseStep> CourseSteps { get; set; }

        public virtual ICollection<FavoriteCourses> UserFavorites { get; set; }
        public virtual ICollection<Cart>  UserCart { get; set; }

    }
}
