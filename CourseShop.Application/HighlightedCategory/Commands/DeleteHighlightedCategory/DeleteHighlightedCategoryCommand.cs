using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CourseShop.Application.HighlightedCategory.Commands.DeleteHighlightedCategory
{
    public class DeleteHighlightedCategoryCommand : IRequest
    {
        public int IdHighlightedCategory { get; set; }
    }
}
