using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CourseShop.Application.PromotedItem.Commands.CreatePromotedItem
{
    public class CreatePromotedItemCommand : IRequest
    {
        public byte[]? Photo { get; set; }
        public IFormFile PhotoFile { get; set; }
        public int? IdCourse { get; set; }
        public string? CourseName { get; set; }
        public int? IdCategory { get; set; }
        public string? CategoryName { get; set; }
        public int? IdMainCategory { get; set; }
        public string? MainCategoryName { get; set; }
    }
}
