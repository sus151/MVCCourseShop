using AutoMapper;
using CourseShop.Application.DTOs;
using CourseShop.Domain.Interfaces;
using MediatR;

namespace CourseShop.Application.Course.Queries.GetAllCourses
{
    public class GetAllCoursesQueryHandler : IRequestHandler<GetAllCoursesQuery, IEnumerable<GetCourseDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICourseRespository _courseRespository;

        public GetAllCoursesQueryHandler(ICourseRespository courseRespository, IMapper mapper)
        {
            _courseRespository = courseRespository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetCourseDto>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
        {
            var courses = await _courseRespository.GetAllCourses();
            var coursesDto = _mapper.Map<IEnumerable<GetCourseDto>>(courses);
            return coursesDto;
        }
    }
}
