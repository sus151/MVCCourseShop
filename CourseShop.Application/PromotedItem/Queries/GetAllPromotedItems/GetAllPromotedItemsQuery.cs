using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CourseShop.Application.PromotedItem.Queries.GetAllPromotedItems
{
    public class GetAllPromotedItemsQuery : IRequest<IEnumerable<GetAllPromotedItemsQuery>>
    {
        public int IdPromotedItem { get; set; }
        public string? CourseName { get; set; }
        public string? CategoryName { get; set; }
        public int? IdCategory { get; set; }
        public int? IdMainCategory { get; set; }
        public string? MainCategoryName { get; set; }
        public int? IdCourse { get; set; }
        public byte[]? Photo { get; set; }
    }
}
