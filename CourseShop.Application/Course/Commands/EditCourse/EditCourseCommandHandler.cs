using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseShop.Application.ApplicationUser;
using CourseShop.Domain.Interfaces;
using MediatR;

namespace CourseShop.Application.Course.Commands.EditCourse
{
    public class EditCourseCommandHandler : IRequestHandler<EditCourseCommand>
    {
        private readonly ICourseRespository _courseRespository;
        private readonly IUserContext _context;

        public EditCourseCommandHandler(ICourseRespository courseRespository, IUserContext context)
        {
            _courseRespository = courseRespository;
            _context = context;
        }
        public async Task<Unit> Handle(EditCourseCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _context.GetCurrentUser();
            if (currentUser == null || !currentUser.IsInRole("Admin"))
            {
                return Unit.Value;
            }
            var course = await _courseRespository.GetCourseById(request.IdCourse!);

            course.IdCategory = request.IdCategory;
            course.IdDifficultyLevel = request.IdDifficultyLevel;
            course.Name = request.Name;
            course.Description = request.Description;
            course.Price = request.Price;
            if (request.CoursePicture != null)
            {
                course.CoursePicture = request.CoursePicture;
            }


            await _courseRespository.Commit();

            return Unit.Value;

        }
    }
}
