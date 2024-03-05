using AutoMapper;
using CourseShop.Application.News.Commands.CreateNews;
using CourseShop.Application.News.Queries.GetAllNews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseShop.Application.News.Commands.DeleteNews;
using CourseShop.Application.News.Queries.GetNewsById;

namespace CourseShop.Application.Mappings
{
    public class NewsMappers : Profile
    {
        public NewsMappers()
        {
            CreateMap<CreateNewsCommand, Domain.Entities.CMS.News>();
            CreateMap<Domain.Entities.CMS.News, GetAllNewsQuery>()
                .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.Course.Name))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.MainCategoryName, opt => opt.MapFrom(src => src.MainCategory.Name));

            CreateMap<Domain.Entities.CMS.News, GetNewsByIdQuery>()
                .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.Course.Name))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.MainCategoryName, opt => opt.MapFrom(src => src.MainCategory.Name));
                

            CreateMap<GetNewsByIdQuery, DeleteNewsCommand>();
            CreateMap<DeleteNewsCommand, Domain.Entities.CMS.News>();
        }
    }
}
