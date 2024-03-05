using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace CourseShop.Application.News.Commands.CreateNews
{
    public class CreateNewsCommand : IRequest
    {
        public byte[]? Photo { get; set; }
        public IFormFile PhotoFile { get; set; }
        public byte[]? PhotoSmall { get; set; }
        public IFormFile PhotoSmallFile { get; set; }

        public int? IdCourse { get; set; }
        public string? CourseName { get; set; }
        public int? IdCategory { get; set; }
        public string? CategoryName { get; set; }
        public int? IdMainCategory { get; set; }
        public string? MainCategoryName { get; set; }
    }
}
