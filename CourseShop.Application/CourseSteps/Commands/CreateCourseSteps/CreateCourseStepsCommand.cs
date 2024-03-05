using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CourseShop.Application.CourseSteps.Commands.CreateCourseSteps
{
    public class CreateCourseStepsCommand : IRequest
    {
        public IEnumerable<CourseStepDto> CourseSteps { get; set; }
    }

    public class CourseStepDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int IdCourse { get; set; }
    }
}
