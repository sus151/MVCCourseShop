using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CourseShop.Application.CourseSteps.Commands.DeleteCourseStep
{
    public class DeleteCourseStepCommand : IRequest
    {
        public int IdCourseStep { get; set; }
    }
}
