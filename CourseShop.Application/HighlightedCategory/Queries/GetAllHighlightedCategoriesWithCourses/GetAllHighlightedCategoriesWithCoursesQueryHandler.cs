using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CourseShop.Domain.Interfaces;
using MediatR;

namespace CourseShop.Application.HighlightedCategory.Queries.GetAllHighlightedCategoriesWithCourses
{
    public class GetAllHighlightedCategoriesWithCoursesQueryHandler : IRequestHandler<GetAllHighlightedCategoriesWithCoursesQuery, IEnumerable<GetAllHighlightedCategoriesWithCoursesQuery>>
    {
        private readonly IMapper _mapper;
        private readonly IHighlightedCategoryRespository _respository;

        public GetAllHighlightedCategoriesWithCoursesQueryHandler(IHighlightedCategoryRespository respository, IMapper mapper)
        {
            _respository = respository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetAllHighlightedCategoriesWithCoursesQuery>> Handle(GetAllHighlightedCategoriesWithCoursesQuery request, CancellationToken cancellationToken)
        {
            var highlighted = await _respository.GetAllHighlightedCategoriesWithCourses();
            var highlightedDto = _mapper.Map<IEnumerable<GetAllHighlightedCategoriesWithCoursesQuery>>(highlighted);
            return highlightedDto;
        }
    }
}
