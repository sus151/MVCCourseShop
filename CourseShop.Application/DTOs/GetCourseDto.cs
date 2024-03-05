using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseShop.Domain.Entities.Shop;
using Microsoft.AspNetCore.Http;

namespace CourseShop.Application.DTOs
{
    public class GetCourseDto
    {
        public int IdCourse { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public int IdCategory { get; set; }
        public string DifficultyLevel { get; set; }
        public int IdDifficultyLevel { get; set; }
        public byte[]? CoursePicture { get; set; }
        public IFormFile File { get; set; }
        public int IdMainCategory { get; set; }
        public string MainCategoryName { get; set; }
        public IEnumerable<CourseStep> CourseSteps { get; set;}
        public bool? IsFavorite { get; set; }
    }

}
