using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CourseShop.Application.User.Queries.GetUserFavoritesCourses
{
    public class GetUserFavoritesCoursesQuery : IRequest<IEnumerable<int>>
    {
        public string Id { get; set; }
    }
}
