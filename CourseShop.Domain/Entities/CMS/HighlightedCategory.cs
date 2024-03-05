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
    public class HighlightedCategory
    {
        [Key]
        public int IdHighlightedCategory { get; set; }

        [Required(ErrorMessage = "Podaj kategorię")]
        [ForeignKey("Category")]
        public int IdCategory { get; set; }


        public virtual Category Category { get; set; }
    }
}
