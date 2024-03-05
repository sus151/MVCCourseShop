using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CourseShop.Application.News.Queries.GetNewsById
{
    public class GetNewsByIdQuery : IRequest<GetNewsByIdQuery>
    {
        public int IdNews { get; set; }
        public byte[] Photo { get; set; }
        public byte[] PhotoSmall { get; set; }
        public string? CourseName { get; set; }
        public string? CategoryName { get; set; }
        public string? MainCategoryName { get; set; }
    }
}
