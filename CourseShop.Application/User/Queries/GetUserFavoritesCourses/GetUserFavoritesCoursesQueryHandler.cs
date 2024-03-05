using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseShop.Application.ApplicationUser;
using CourseShop.Domain.Interfaces;
using MediatR;

namespace CourseShop.Application.User.Queries.GetUserFavoritesCourses
{
    public class GetUserFavoritesCoursesQueryHandler : IRequestHandler<GetUserFavoritesCoursesQuery, IEnumerable<int>>
    {
        private readonly IUserRespository _respository;
        private readonly IUserContext _context;

        public GetUserFavoritesCoursesQueryHandler(IUserContext userContext, IUserRespository respository, IUserContext context)
        {
            _respository = respository;
            _context = context;
        }
        public async Task<IEnumerable<int>> Handle(GetUserFavoritesCoursesQuery request, CancellationToken cancellationToken)
        {
            if (_context.GetCurrentUser() == null)
            {
                return null;
            }
            var courses = await _respository.GetUserFavoritesCourses(request.Id);
            return courses;
        }
    }
}
