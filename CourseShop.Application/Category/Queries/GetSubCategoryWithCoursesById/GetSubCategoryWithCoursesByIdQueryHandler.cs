using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseShop.Application.DTOs;
using CourseShop.Domain.Interfaces;
using MediatR;

namespace CourseShop.Application.Category.Queries.GetSubCategoryWithCoursesById
{
    public class GetSubCategoryWithCoursesByIdQueryHandler : IRequestHandler<GetSubCategoryWithCoursesByIdQuery, GetSubCategoryWithCoursesDto>
    {
        private readonly ICategoryRespository _respository;

        public GetSubCategoryWithCoursesByIdQueryHandler(ICategoryRespository respository)
        {
            _respository = respository;
        }
        public async Task<GetSubCategoryWithCoursesDto> Handle(GetSubCategoryWithCoursesByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _respository.GetSubCategoryWithCoursesById(request.IdCategory);
            if (category == null)
            {
                return null;
            }
            var subCategoryDto = new GetSubCategoryWithCoursesDto
            {
                IdCategory = category.IdCategory,
                Name = category.Name,
                IdMainCategory = category.IdMainCategory,
                MainCategoryName = category.MainCategory.Name,
                MainCategoryDesription = category.MainCategory.Description,
                Courses = category.Courses.Select(x => new GetCourseDto
                    {
                        IdCourse = x.IdCourse,
                        Name = x.Name,
                        Description = x.Description,
                        Price = x.Price,
                        Category = category.Name,
                        DifficultyLevel = x.DifficultyLevel.Difficulty,
                        CoursePicture = x.CoursePicture
                    }
                )


            };
            return subCategoryDto;
        }
    }
}
