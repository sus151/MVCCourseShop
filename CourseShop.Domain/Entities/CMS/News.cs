using CourseShop.Domain.Entities.Shop;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseShop.Domain.Entities.CMS
{
    public class News
    {
        [Key]
        public int IdNews { get; set; }

        [Required(ErrorMessage = "Dodaj zdjęcie")]
        public byte[] Photo { get; set; }
        [Required(ErrorMessage = "Dodaj zdjęcie")]
        public byte[] PhotoSmall { get; set; }

        [ForeignKey("Course")]
        public int? IdCourse { get; set; }
        [ForeignKey("MainCategory")]
        public int? IdMainCategory { get; set; }


        [ForeignKey("Category")]
        public int? IdCategory { get; set; }

        public virtual Category Category { get; set; }
        public virtual Category MainCategory { get; set; }

        public virtual Course Course { get; set; }


    }
}
