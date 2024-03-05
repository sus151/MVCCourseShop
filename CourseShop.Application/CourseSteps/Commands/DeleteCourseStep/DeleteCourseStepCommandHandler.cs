using AutoMapper;
using CourseShop.Domain.Entities.Shop;
using CourseShop.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseShop.Application.ApplicationUser;

namespace CourseShop.Application.CourseSteps.Commands.DeleteCourseStep
{
    public class DeleteCourseStepCommandHandler : IRequestHandler<DeleteCourseStepCommand>
    {
        private readonly ICourseStepRespository _respository;
        private readonly IMapper _mapper;
        private readonly IUserContext _context;

        public DeleteCourseStepCommandHandler(ICourseStepRespository respository, IMapper mapper, IUserContext context) {
            _respository = respository;
            _mapper = mapper;
            _context = context;
        }
        public async Task<Unit> Handle(DeleteCourseStepCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _context.GetCurrentUser();
            if (currentUser == null || !currentUser.IsInRole("Admin"))
            {
                return Unit.Value;
            }
            var step = _mapper.Map<CourseStep>(request);
            await _respository.DeleteCourseSteps(step);
            return Unit.Value;
        }
    }
}
