using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CourseShop.Domain.Interfaces;
using MediatR;

namespace CourseShop.Application.HighlightedCategory.Queries.GetHighlightedCategoryById
{
    public class GetHighlightedCategoryByIdQueryHandler : IRequestHandler<GetHighlightedCategoryByIdQuery, GetHighlightedCategoryByIdQuery>
    {
        private readonly IMapper _mapper;
        private readonly IHighlightedCategoryRespository _respository;

        public GetHighlightedCategoryByIdQueryHandler(IHighlightedCategoryRespository respository, IMapper mapper)
        {
            _respository = respository;
            _mapper = mapper;
        }
        public async Task<GetHighlightedCategoryByIdQuery> Handle(GetHighlightedCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var highlighted = await _respository.GetHighlightedCategoryById(request.IdHighlightedCategory);
            var highlightedDto = _mapper.Map<GetHighlightedCategoryByIdQuery>(highlighted);
            return highlightedDto;
        }
    }
}
