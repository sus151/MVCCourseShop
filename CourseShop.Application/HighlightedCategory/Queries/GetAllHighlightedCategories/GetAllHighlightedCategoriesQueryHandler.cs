using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CourseShop.Domain.Interfaces;
using MediatR;

namespace CourseShop.Application.HighlitedCategory.Queries.GetAllHighlitedCategories
{
    public class GetAllHighlightedCategoriesQueryHandler : IRequestHandler<GetAllHighlightedCategoriesQuery, IEnumerable<GetAllHighlightedCategoriesQuery>>
    {
        private readonly IHighlightedCategoryRespository _respository;
        private readonly IMapper _mapper;

        public GetAllHighlightedCategoriesQueryHandler(IHighlightedCategoryRespository respository, IMapper mapper)
        {
            _respository = respository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetAllHighlightedCategoriesQuery>> Handle(GetAllHighlightedCategoriesQuery request, CancellationToken cancellationToken)
        {
            var highlighted = await _respository.GetAllHighlightedCategories();
            var highlightedDto = _mapper.Map<IEnumerable<GetAllHighlightedCategoriesQuery>>(highlighted);
            return highlightedDto;
        }
    }
}
