using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CourseShop.Domain.Entities.Shop
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<FavoriteCourses> FavoriteCourses { get; set; }
        public virtual ICollection<Cart> UserCart { get; set; }
    }
}
