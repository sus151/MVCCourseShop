using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CourseShop.Application.DTOs;
using CourseShop.Domain.Interfaces;
using MediatR;

namespace CourseShop.Application.Course.Queries.GetCourseById
{
    public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, GetCourseDto>
    {
        private readonly ICourseRespository _courseRespository;
        private readonly IMapper _mapper;

        public GetCourseByIdQueryHandler(ICourseRespository courseRespository, IMapper mapper)
        {
            _courseRespository = courseRespository;
            _mapper = mapper;
        }
        public async Task<GetCourseDto> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            var course = await _courseRespository.GetCourseById(request.IdCourse);
            var courseDto = _mapper.Map<GetCourseDto>(course);
            return courseDto;
        }
    }
}
