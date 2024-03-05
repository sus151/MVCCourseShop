using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CourseShop.Domain.Interfaces;
using MediatR;

namespace CourseShop.Application.Category.Queries.GetAllCategoriesForSelect
{
    public class GetAllSubCategoriesQueryHandler : IRequestHandler<GetAllSubCategoriesQuery, IEnumerable<GetAllSubCategoriesQuery>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRespository _categoryRespository;

        public GetAllSubCategoriesQueryHandler(ICategoryRespository categoryRespository, IMapper mapper)
        {
            _categoryRespository = categoryRespository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetAllSubCategoriesQuery>> Handle(GetAllSubCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRespository.GetAllSubCategories();
            var categoriesDto = _mapper.Map<IEnumerable<GetAllSubCategoriesQuery>>(categories);
            return categoriesDto;
        }
    }
}
