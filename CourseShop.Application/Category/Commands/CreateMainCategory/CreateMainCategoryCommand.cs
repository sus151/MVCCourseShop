using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CourseShop.Application.Category.Commands.CreateMainCategory
{
    public class CreateMainCategoryCommand : IRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
