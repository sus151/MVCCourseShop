using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CourseShop.Domain.Interfaces;
using MediatR;

namespace CourseShop.Application.Category.Queries.GetSubcategoriesByMainCategoryId
{
    public class GetSubcategoriesByMainCategoryIdQueryHandler : IRequestHandler<GetSubcategoriesByMainCategoryIdQuery, IEnumerable<GetSubcategoriesByMainCategoryIdQuery>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRespository _categoryRespository;

        public GetSubcategoriesByMainCategoryIdQueryHandler(ICategoryRespository categoryRespository, IMapper mapper)
        {
            _categoryRespository = categoryRespository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetSubcategoriesByMainCategoryIdQuery>> Handle(GetSubcategoriesByMainCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var subCategories = await _categoryRespository.GetSubCategoriesByMainCategoryId(request.IdMainCategory);
            return _mapper.Map<IEnumerable<GetSubcategoriesByMainCategoryIdQuery>>(subCategories);
        }
    }
}
