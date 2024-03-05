using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CourseShop.Application.ApplicationUser;
using CourseShop.Application.DTOs;
using CourseShop.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authentication;

namespace CourseShop.Application.Course.Commands.CreateCourse
{
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand>
    {
        private readonly ICourseRespository _courseRespository;
        private readonly IMapper _mapper;
        private readonly IUserContext _context;

        public CreateCourseCommandHandler(ICourseRespository courseRespository, IMapper mapper, IUserContext context)
        {
            _courseRespository = courseRespository;
            _mapper = mapper;
            _context = context;
        }
        public async Task<Unit> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _context.GetCurrentUser();
            if (currentUser == null || !currentUser.IsInRole("Admin"))
            {
                return Unit.Value;
            }
            var course = _mapper.Map<Domain.Entities.Shop.Course>(request);
            await _courseRespository.CreateCourse(course);

            return Unit.Value;
        }

    }
}
