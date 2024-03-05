using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace CourseShop.Application.Course.Queries.GetCoursesByPhrase
{
    public class GetCoursesByPhraseQuery : IRequest<IEnumerable<GetCoursesByPhraseQuery>>
    {
        public int IdCourse { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public byte[] CoursePicture { get; set; }
        public string? PictureString { get; set; }

        public string Phrase { get; set; }
        public int ResultsNumber { get; set; } 
    }
}
