using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseShop.Application.DTOs;
using MediatR;

namespace CourseShop.Application.Course.Commands.DeleteCourse
{
    public class DeleteCourseCommand : IRequest
    {
        public int IdCourse { get; set; }
       
    }
}
