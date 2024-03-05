using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CourseShop.Application.HighlightedCategory.Queries.GetHighlightedCategoryById
{
    public class GetHighlightedCategoryByIdQuery : IRequest<GetHighlightedCategoryByIdQuery>
    {
        public int IdHighlightedCategory { get; set; }
        public string CategoryName { get; set; }
    }
}
