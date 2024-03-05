using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseShop.Application.DTOs
{
    public class GetSubCategoryWithCoursesDto
    {
        public int IdCategory { get; set; }
        public int? IdMainCategory { get; set; }
        public string MainCategoryName { get; set; }
        public string MainCategoryDesription { get; set; }
        public string Name { get; set; }
        public IEnumerable<GetCourseDto> Courses { get; set; }
    }
}
