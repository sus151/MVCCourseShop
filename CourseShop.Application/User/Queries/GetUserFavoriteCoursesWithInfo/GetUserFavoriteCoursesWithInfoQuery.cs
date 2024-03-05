using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CourseShop.Application.User.Queries.GetUserFavoriteCoursesWithInfo
{
    public class GetUserFavoriteCoursesWithInfoQuery : IRequest<IEnumerable<GetUserFavoriteCoursesWithInfoQuery>>
    {
        public int IdCourse { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] CoursePicture { get; set; }

    }
}
