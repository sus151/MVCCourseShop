using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CourseShop.Domain.Interfaces;
using MediatR;

namespace CourseShop.Application.Course.Queries.GetCoursesForSelect
{
    public class GetCoursesForSelectQueryHandler : IRequestHandler<GetCoursesForSelectQuery, IEnumerable<GetCoursesForSelectQuery>>
    {
        private readonly ICourseRespository _courseRespository;
        private readonly IMapper _mapper;

        public GetCoursesForSelectQueryHandler(ICourseRespository courseRespository, IMapper mapper)
        {
            _courseRespository = courseRespository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetCoursesForSelectQuery>> Handle(GetCoursesForSelectQuery request, CancellationToken cancellationToken)
        {
            var course = await _courseRespository.GetAllCourses();
            var courseDto = _mapper.Map<IEnumerable<GetCoursesForSelectQuery>>(course);
            return courseDto;
        }
    }
}
