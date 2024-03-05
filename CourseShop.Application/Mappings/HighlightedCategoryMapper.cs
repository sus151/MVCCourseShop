using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CourseShop.Application.HighlightedCategory.Commands.CreateHighlightedCategory;
using CourseShop.Application.HighlightedCategory.Commands.DeleteHighlightedCategory;
using CourseShop.Application.HighlightedCategory.Queries.GetAllHighlightedCategoriesWithCourses;
using CourseShop.Application.HighlightedCategory.Queries.GetHighlightedCategoryById;
using CourseShop.Application.HighlitedCategory.Queries.GetAllHighlitedCategories;
using CourseShop.Application.News.Commands.DeleteNews;
using CourseShop.Application.News.Queries.GetNewsById;
using CourseShop.Application.PromotedItem.Commands.CreatePromotedItem;

namespace CourseShop.Application.Mappings
{
    public class HighlightedCategoryMapper : Profile
    {
        public HighlightedCategoryMapper()
        {
            CreateMap<Domain.Entities.CMS.HighlightedCategory, GetAllHighlightedCategoriesQuery>()
                .ForMember(dest => dest.HighlightedCategoryName, opt => opt.MapFrom(src => src.Category.Name));
            CreateMap<CreateHighlightedCategoryCommand, Domain.Entities.CMS.HighlightedCategory>();
            CreateMap<Domain.Entities.CMS.HighlightedCategory, GetHighlightedCategoryByIdQuery>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
            CreateMap<GetHighlightedCategoryByIdQuery, DeleteHighlightedCategoryCommand>();
            CreateMap<DeleteHighlightedCategoryCommand, Domain.Entities.CMS.HighlightedCategory>();

            CreateMap<Domain.Entities.CMS.HighlightedCategory, GetAllHighlightedCategoriesWithCoursesQuery>()
                .ForMember(dest => dest.Courses, opt => opt.MapFrom(src => src.Category.Courses))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));




        }
    }
}
