using CourseShop.Domain.Entities.Shop;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CourseShop.Application.DTOs
{
    public class PostCourseDto{
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? IdDifficultyLevel { get; set; }
        public int? IdCategory { get; set; }
        public IFormFile? File { get; set; }
        public byte[]? CoursePicture { get; set; }
    }
}
