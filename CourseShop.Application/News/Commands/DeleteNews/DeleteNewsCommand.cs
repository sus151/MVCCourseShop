using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CourseShop.Application.News.Commands.DeleteNews
{
    public class DeleteNewsCommand : IRequest
    {
        public int IdNews { get; set; }
    }
}
