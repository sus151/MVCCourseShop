using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CourseShop.Application.HighlightedCategory.Queries.GetAllHighlightedCategoriesWithCourses
{
    public class GetAllHighlightedCategoriesWithCoursesQuery : IRequest<IEnumerable<GetAllHighlightedCategoriesWithCoursesQuery>>
    {
        public int IdCategory { get; set; }
        public string CategoryName { get; set; }
        public IEnumerable<CourseDto> Courses { get; set; }
    }

    public class CourseDto
    {
        public int IdCourse { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public byte[] CoursePicture { get; set; }
    }
}
