using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CourseShop.Application.Course.Queries.GetCoursesForSelect
{
    public class GetCoursesForSelectQuery : IRequest<IEnumerable<GetCoursesForSelectQuery>>
    {
        public int IdCourse { get; set; }
        public string Name { get; set; }
    }
}
