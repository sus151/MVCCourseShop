using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CourseShop.Application.Course.Commands.DeleteCourse;
using CourseShop.Application.Course.Commands.EditCourse;
using CourseShop.Application.Course.Queries.GetCourseById;
using CourseShop.Application.Course.Queries.GetCoursesByPhrase;
using CourseShop.Application.Course.Queries.GetCoursesForSelect;
using CourseShop.Application.DTOs;
using CourseShop.Application.HighlightedCategory.Queries.GetAllHighlightedCategoriesWithCourses;
using CourseShop.Application.News.Commands.DeleteNews;
using CourseShop.Application.News.Queries.GetNewsById;
using CourseShop.Application.User.Queries.GetUserFavoriteCoursesWithInfo;
using CourseShop.Domain.Entities.Shop;

namespace CourseShop.Application.Mappings
{
    public class CourseMapper : Profile
    {
        public CourseMapper()
        {
            CreateMap<PostCourseDto, Domain.Entities.Shop.Course>();
            CreateMap<Domain.Entities.Shop.Course, GetCourseDto>()
                .ForMember(e => e.Category, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(e => e.DifficultyLevel, opt => opt.MapFrom(src => src.DifficultyLevel.Difficulty))
                .ForMember(dest => dest.IdMainCategory,
                    opt => opt.MapFrom(src => src.Category.MainCategory.IdCategory))
                .ForMember(dest => dest.MainCategoryName, opt => opt.MapFrom(src => src.Category.MainCategory.Name));
                

            CreateMap<GetCourseDto, EditCourseCommand>();

            CreateMap<GetCourseByIdQuery, DeleteCourseCommand>();
            CreateMap<DeleteCourseCommand, Domain.Entities.Shop.Course>();

            CreateMap<Domain.Entities.Shop.Course, GetCoursesForSelectQuery>();
            CreateMap<Domain.Entities.Shop.Course, CourseDto>()
                .ForMember(dest => dest.CourseDescription, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.IdCourse, opt => opt.MapFrom(src => src.IdCourse));

            CreateMap<Domain.Entities.Shop.Course, GetCoursesByPhraseQuery>();
            CreateMap<Domain.Entities.Shop.Course, GetUserFavoriteCoursesWithInfoQuery>();
        }
    }
}
