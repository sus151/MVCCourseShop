using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CourseShop.Application.PromotedItem.Commands.DeletePromotedItem
{
    public class DeletePromotedItemCommand : IRequest
    {
        public int IdPromotedItem { get; set; }
    }
}
