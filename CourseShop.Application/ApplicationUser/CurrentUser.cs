using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseShop.Application.ApplicationUser
{
    public class CurrentUser
    {
        public CurrentUser(string id, IEnumerable<string> roles)
        {
            Id = id;
            Roles = roles;
        }
        public string Id { get; set; }
        public IEnumerable<string> Roles { get; set; }

        public bool IsInRole(string role) => Roles.Contains(role);
    }
}
