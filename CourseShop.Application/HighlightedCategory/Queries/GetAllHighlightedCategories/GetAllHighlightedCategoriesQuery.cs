using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CourseShop.Application.HighlitedCategory.Queries.GetAllHighlitedCategories
{
    public class GetAllHighlightedCategoriesQuery : IRequest<IEnumerable<GetAllHighlightedCategoriesQuery>>
    {
        public int IdHighlightedCategory { get; set; }
        public string HighlightedCategoryName { get; set; }
    }
}
