using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CourseShop.Application.ApplicationUser;
using CourseShop.Domain.Interfaces;
using MediatR;

namespace CourseShop.Application.Course.Commands.DeleteCourse
{
    public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand>
    {
        private readonly IMapper _mapper;
        private readonly ICourseRespository _courseRespository;
        private readonly IUserContext _context;

        public DeleteCourseCommandHandler(ICourseRespository courseRespository, IMapper mapper, IUserContext context)
        {
            _courseRespository = courseRespository;
            _mapper = mapper;
            _context = context;
        }
        public async Task<Unit> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _context.GetCurrentUser();
            if (currentUser == null || !currentUser.IsInRole("Admin"))
            {
                return Unit.Value;
            }
            var course = _mapper.Map<Domain.Entities.Shop.Course>(request);
            await _courseRespository.DeleteCourse(course);
            return Unit.Value;
        }
    }
}
