using CourseShop.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseShop.Application.ApplicationUser;

namespace CourseShop.Application.User.Queries.CheckIfCourseIsAlreadyFavorite
{
    public class CheckIfCourseIsAlreadyFavoriteQueryHandler : IRequestHandler<CheckIfCourseIsAlreadyFavoriteQuery, bool>
    {
        private readonly IUserRespository _respository;
        private readonly IUserContext _context;


        public CheckIfCourseIsAlreadyFavoriteQueryHandler(IUserRespository respository, IUserContext context)
        {
            _respository = respository;
            _context = context;
        }

        public async Task<bool> Handle(CheckIfCourseIsAlreadyFavoriteQuery request, CancellationToken cancellationToken)
        {
            if (_context.GetCurrentUser() == null)
            {
                return false;
            }
            var exists = await _respository.CheckIfUserAlreadyHaveThisCourseInFavorites(request.Id, request.IdCourse);
            return exists;
        }
    }
}
