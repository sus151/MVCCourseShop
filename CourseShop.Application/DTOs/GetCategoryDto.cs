using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseShop.Application.DTOs
{
    public class GetCategoryDto
    {
        public int IdCategory { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<GetSubCategoryDtoWithMainCategories> SubCategories { get; set; } 

    }
    public class GetSubCategoryDtoWithMainCategories
    {
        public int IdCategory { get; set; }
        public string Name { get; set; }
        public IEnumerable<GetCourseDto> Courses { get; set; }
    }
}
