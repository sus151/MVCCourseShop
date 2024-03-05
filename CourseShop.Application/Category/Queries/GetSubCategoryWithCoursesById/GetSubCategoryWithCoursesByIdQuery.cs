using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseShop.Application.DTOs;
using MediatR;

namespace CourseShop.Application.Category.Queries.GetSubCategoryWithCoursesById
{
    public class GetSubCategoryWithCoursesByIdQuery : IRequest<GetSubCategoryWithCoursesDto>
    {
        public int IdCategory { get; set; }
    }
}
