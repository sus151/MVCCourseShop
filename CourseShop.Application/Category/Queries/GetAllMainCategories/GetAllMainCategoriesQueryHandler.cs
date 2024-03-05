using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CourseShop.Domain.Interfaces;
using MediatR;

namespace CourseShop.Application.Category.Queries.GetAllMainCategories
{
    public class GetAllMainCategoriesQueryHandler : IRequestHandler<GetAllMainCategoriesQuery, IEnumerable<GetAllMainCategoriesQuery>>
    {
        private ICategoryRespository _categoryRespository;
        private IMapper _mapper;

        public GetAllMainCategoriesQueryHandler(ICategoryRespository categoryRespository, IMapper mapper)
        {
            _categoryRespository = categoryRespository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetAllMainCategoriesQuery>> Handle(GetAllMainCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRespository.GetAllMainCategories();

            return _mapper.Map<IEnumerable<GetAllMainCategoriesQuery>>(categories);
        }
    }
}
