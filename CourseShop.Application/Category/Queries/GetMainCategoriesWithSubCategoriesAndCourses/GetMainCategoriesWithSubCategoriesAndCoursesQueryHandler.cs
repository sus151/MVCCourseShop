using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CourseShop.Application.DTOs;
using CourseShop.Domain.Interfaces;
using MediatR;

namespace CourseShop.Application.Category.Queries.GetMainCategoriesWithSubCategoriesAndCourses
{
    public class GetMainCategoriesWithSubCategoriesAndCoursesQueryHandler : IRequestHandler<GetMainCategoriesWithSubCategoriesAndCoursesQuery, IEnumerable<GetCategoryDto>>
    {
        private readonly ICategoryRespository _categoryRespository;
        private readonly IMapper _mapper;

        public GetMainCategoriesWithSubCategoriesAndCoursesQueryHandler(ICategoryRespository categoryRespository, IMapper mapper)
        {
            _categoryRespository = categoryRespository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetCategoryDto>> Handle(GetMainCategoriesWithSubCategoriesAndCoursesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRespository.GetAllCategoriesWithSubCategoriesAndCourses();
            var categoriesDto = categories
                .Select(c => new GetCategoryDto
                {
                    IdCategory = c.IdCategory,
                    Name = c.Name,
                    SubCategories = c.SubCategories.Select(sub => new GetSubCategoryDtoWithMainCategories()
                        {
                            IdCategory = sub.IdCategory,
                            Name = sub.Name,
                            Courses = _mapper.Map<IEnumerable<GetCourseDto>>(sub.Courses)
                        })
                        .ToList()

                }).ToList();
            return categoriesDto;
        }
    }
}
