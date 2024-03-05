using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CourseShop.Application.User.Commands.DeleteCourseFormUserFavorites
{
    public class DeleteCourseFromUserFavoritesCommand : IRequest
    {
        public string Id { get; set; }
        public int IdCourse { get; set; }
    }
}
