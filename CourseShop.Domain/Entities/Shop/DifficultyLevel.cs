using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CourseShop.Domain.Entities.Shop;

public class DifficultyLevel
{
    [Key]
    public int IdDifficultyLevel { get; set; }
    [Required(ErrorMessage = "Podaj poziom trudności")]
    [MaxLength(30, ErrorMessage = "Poziom trudności może zawierać maksymalnie 30 znaków")]
    [Column(TypeName = "varchar(30)")]
    public string Difficulty { get; set; }
    public virtual ICollection<Course> Courses { get; set; }
}