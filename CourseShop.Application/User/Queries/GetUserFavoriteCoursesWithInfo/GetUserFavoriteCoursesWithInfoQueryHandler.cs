using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CourseShop.Application.ApplicationUser;
using CourseShop.Domain.Interfaces;
using MediatR;

namespace CourseShop.Application.User.Queries.GetUserFavoriteCoursesWithInfo
{
    public class GetUserFavoriteCoursesWithInfoQueryHandler : IRequestHandler<GetUserFavoriteCoursesWithInfoQuery, IEnumerable<GetUserFavoriteCoursesWithInfoQuery>>
    {
        private readonly IUserRespository _respository;
        private readonly IMapper _mapper;
        private readonly IUserContext _context;

        public GetUserFavoriteCoursesWithInfoQueryHandler(IUserRespository respository, IMapper mapper, IUserContext context)
        {
            _respository = respository;
            _mapper = mapper;
            _context = context;
        }
        public async Task<IEnumerable<GetUserFavoriteCoursesWithInfoQuery>> Handle(GetUserFavoriteCoursesWithInfoQuery request, CancellationToken cancellationToken)
        {
            var currentUser = _context.GetCurrentUser();
            if (currentUser==null)
            {
                return null;
            }

            var userCourses = await _respository.GetUserFavoritesCoursesWithInfo(currentUser.Id);
            var userCoursesDto = _mapper.Map<IEnumerable<GetUserFavoriteCoursesWithInfoQuery>>(userCourses);
            return userCoursesDto;
        }
    }
}
