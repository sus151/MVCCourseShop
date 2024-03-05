using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CourseShop.Application.Category.Commands.CreateSubCategory
{
    public class CreateSubCategoryCommand : IRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int IdMainCategory { get; set; }
    }
}
