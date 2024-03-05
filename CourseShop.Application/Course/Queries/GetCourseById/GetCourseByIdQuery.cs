using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseShop.Application.DTOs;
using MediatR;

namespace CourseShop.Application.Course.Queries.GetCourseById
{
    public class GetCourseByIdQuery : IRequest<GetCourseDto>
    {
        public int IdCourse { get; set; }

    }
}
