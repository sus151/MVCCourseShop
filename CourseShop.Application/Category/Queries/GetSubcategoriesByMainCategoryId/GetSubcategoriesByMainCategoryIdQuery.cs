using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CourseShop.Application.Category.Queries.GetSubcategoriesByMainCategoryId
{
    public class GetSubcategoriesByMainCategoryIdQuery : IRequest<IEnumerable<GetSubcategoriesByMainCategoryIdQuery>>
    {
        public int IdMainCategory { get; set; }
        public int IdCategory { get; set; }
        public string Name { get; set; }
    }
}
