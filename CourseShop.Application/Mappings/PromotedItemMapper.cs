using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CourseShop.Application.News.Commands.DeleteNews;
using CourseShop.Application.News.Queries.GetAllNews;
using CourseShop.Application.News.Queries.GetNewsById;
using CourseShop.Application.PromotedItem.Commands.CreatePromotedItem;
using CourseShop.Application.PromotedItem.Commands.DeletePromotedItem;
using CourseShop.Application.PromotedItem.Queries.GetAllPromotedItems;
using CourseShop.Application.PromotedItem.Queries.GetPromotedItemById;

namespace CourseShop.Application.Mappings
{
    public class PromotedItemMapper : Profile
    {
        public PromotedItemMapper()
        {
            CreateMap<CreatePromotedItemCommand, Domain.Entities.CMS.PromotedItem>();
            CreateMap<Domain.Entities.CMS.PromotedItem, GetAllPromotedItemsQuery>()
                .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.Course.Name))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.MainCategoryName, opt => opt.MapFrom(src => src.MainCategory.Name));

            CreateMap<Domain.Entities.CMS.PromotedItem, GetPromotedItemByIdQuery>()
                .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.Course.Name))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.MainCategoryName, opt => opt.MapFrom(src => src.MainCategory.Name));

            CreateMap<GetPromotedItemByIdQuery, DeletePromotedItemCommand>();
            CreateMap<DeletePromotedItemCommand, Domain.Entities.CMS.PromotedItem>();
        }
    }
}
