using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseShop.Domain.Entities.CMS
{
    public class Reference
    {

        [Key]
        public int IdReference { get; set; }

        [Required(ErrorMessage = "Podaj tytuł referencji")]
        [MaxLength(50, ErrorMessage = "Tytuł referencji powinien zawierać maksymalnie 50 znaków.")]
        [Column(TypeName = "varchar(50)")]
        public string MainTittle { get; set; }

        [Required(ErrorMessage = "Podaj tytuł strony")]
        [MaxLength(50, ErrorMessage = "Tytuł strony powinien zawierać maksymalnie 50 znaków")]
        [Column(TypeName = "varchar(50)")]
        public string PageTittle { get; set; }
    }
}
