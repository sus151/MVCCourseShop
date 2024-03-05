using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CourseShop.Application.ApplicationUser
{
    public interface IUserContext
    {
        CurrentUser? GetCurrentUser();
    }
    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public CurrentUser? GetCurrentUser()
        {
            var user = _httpContextAccessor.HttpContext?.User;
            if (user?.Identity?.IsAuthenticated != true)
            {
                throw new InvalidOperationException("User is not authenticated");
            }

            if (user.Identity == null || !user.Identity.IsAuthenticated)
            {
                return null;
            }

            var id = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var roles = user.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);

            return new CurrentUser(id, roles);
        }

    }
}
