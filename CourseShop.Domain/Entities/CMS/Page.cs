using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseShop.Domain.Entities.CMS
{
    public class Page
    {
        [Key]
        public int IdPage { get; set; }

        [Required(ErrorMessage="Nagłówek jest wymagany")]
        [MaxLength(50, ErrorMessage = "Nagłówek powinien zawierać maksymalnie 50 znaków")]
        [Column(TypeName = "varchar(50)")]
        public string Header { get; set; }

        [Required(ErrorMessage ="Treść jest wymagana")]
        [MaxLength(2000, ErrorMessage ="Treść powinna zawierać maksymalnie 2000 znaków")]
        [Column(TypeName = "varchar(2000)")]
        public string Content { get; set; }

        [Required(ErrorMessage ="Podaj referencje")]
        [ForeignKey("Reference")]
        public int IdReference { get; set; }

        public virtual Reference Reference { get; set; }
    }
}
