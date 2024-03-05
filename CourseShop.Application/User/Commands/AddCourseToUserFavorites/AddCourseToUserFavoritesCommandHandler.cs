﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CourseShop.Application.ApplicationUser;
using CourseShop.Domain.Entities.Shop;
using CourseShop.Domain.Interfaces;
using MediatR;

namespace CourseShop.Application.User.Commands.AddCourseToUserFavorites
{
    public class AddCourseToUserFavoritesCommandHandler : IRequestHandler<AddCourseToUserFavoritesCommand>
    {
        private readonly IUserRespository _respository;
        private readonly IMapper _mapper;
        private readonly IUserContext _context;

        public AddCourseToUserFavoritesCommandHandler(IUserRespository respository, IMapper mapper, IUserContext context)
        {
            _respository = respository;
            _mapper = mapper;
            _context = context;
        }
        public async Task<Unit> Handle(AddCourseToUserFavoritesCommand request, CancellationToken cancellationToken)
        {
            if (_context.GetCurrentUser()==null)
            {
                return Unit.Value;
            }
            var favorite = _mapper.Map<FavoriteCourses>(request);
            await _respository.AddCourseToUserFavorites(favorite);
            return Unit.Value;
        }
    }
}
