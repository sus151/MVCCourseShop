using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CourseShop.Application.Category.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest
    {
        public int IdCategory { get; set; }
    }
}
