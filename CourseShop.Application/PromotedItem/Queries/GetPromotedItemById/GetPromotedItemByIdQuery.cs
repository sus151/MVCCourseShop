using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CourseShop.Application.PromotedItem.Queries.GetPromotedItemById
{
    public class GetPromotedItemByIdQuery : IRequest<GetPromotedItemByIdQuery>
    {
        public int IdPromotedItem { get; set; }
        public byte[] Photo { get; set; }
        public string? CourseName { get; set; }
        public string? CategoryName { get; set; }
        public string? MainCategoryName { get; set; }
    }
}
