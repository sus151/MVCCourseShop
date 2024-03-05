using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CourseShop.Application.User.Queries.CheckIfCourseIsAlreadyFavorite
{
    public class CheckIfCourseIsAlreadyFavoriteQuery : IRequest<bool>
    {
        public string Id { get; set; }
        public int IdCourse { get; set; }
    }
}
