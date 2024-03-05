using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CourseShop.Application.HighlightedCategory.Commands.CreateHighlightedCategory
{
    public class CreateHighlightedCategoryCommand : IRequest
    {
        public int IdCategory { get; set; }
        public string CategoryName { get; set; }
    }
}
