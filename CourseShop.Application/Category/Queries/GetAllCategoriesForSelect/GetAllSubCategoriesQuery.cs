using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CourseShop.Application.Category.Queries.GetAllCategoriesForSelect
{
    public class GetAllSubCategoriesQuery : IRequest<IEnumerable<GetAllSubCategoriesQuery>>
    {
        public int IdCategory { get; set; }
        public string Name { get; set; }
    }
}
