using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CourseShop.Application.ApplicationUser;
using CourseShop.Domain.Entities.Shop;
using CourseShop.Domain.Interfaces;
using MediatR;

namespace CourseShop.Application.CourseSteps.Commands.CreateCourseSteps
{
    public class CreateCourseStepsCommandHandler : IRequestHandler<CreateCourseStepsCommand>
    {
        private readonly ICourseStepRespository _respository;
        private readonly IMapper _mapper;
        private readonly IUserContext _context;

        public CreateCourseStepsCommandHandler(ICourseStepRespository respository, IMapper mapper, IUserContext context)
        {
            _respository = respository;
            _mapper = mapper;
            _context = context;


        }
        public async Task<Unit> Handle(CreateCourseStepsCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _context.GetCurrentUser();
            if (currentUser == null || !currentUser.IsInRole("Admin"))
            {
                return Unit.Value;
            }
            var steps = _mapper.Map<IEnumerable<CourseStep>>(request.CourseSteps);
            await _respository.CreateCourseSteps(steps);
            return Unit.Value;
        }
    }
}
