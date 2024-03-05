using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CourseShop.Application.DTOs;
using CourseShop.Domain.Interfaces;
using MediatR;

namespace CourseShop.Application.Category.Queries.GetMainCategoryWithSubcategoriesAndCoursesById
{
    public class GetMainCategoryWithSubcategoriesAndCoursesByIdQueryHandler : IRequestHandler<GetMainCategoryWithSubcategoriesAndCoursesByIdQuery, GetCategoryDto>
    {
        private readonly ICategoryRespository _categoryRespository;
        private readonly IMapper _mapper;

        public GetMainCategoryWithSubcategoriesAndCoursesByIdQueryHandler(ICategoryRespository categoryRespository, IMapper mapper)
        {
            _categoryRespository = categoryRespository;
            _mapper = mapper;
        }
        public async Task<GetCategoryDto> Handle(GetMainCategoryWithSubcategoriesAndCoursesByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRespository.GetMainCategoryById(request.IdCategory);
            if (category == null)
            {
                return null;
            }

            var categoryDto = new GetCategoryDto
            {

                IdCategory = category.IdCategory,
                Name = category.Name,
                Description = category.Description,
                SubCategories = category.SubCategories.Select(sub => new GetSubCategoryDtoWithMainCategories()
                    {
                        IdCategory = sub.IdCategory,
                        Name = sub.Name,
                        Courses = _mapper.Map<IEnumerable<GetCourseDto>>(sub.Courses)
                    })
                    .ToList()
            };
            return categoryDto;
        }
    }
}
