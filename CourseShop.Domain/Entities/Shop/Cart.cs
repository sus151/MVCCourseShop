using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseShop.Domain.Entities.Shop
{
    public class Cart
    {
        [ForeignKey("User")]
        public string Id { get; set; }

        [ForeignKey("Course")]
        public int IdCourse { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Course Course { get; set; }
    }
}
