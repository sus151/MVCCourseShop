using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CourseShop.Application.Category.Commands.CreateMainCategory;
using CourseShop.Application.Category.Commands.CreateSubCategory;
using CourseShop.Application.Category.Commands.DeleteCategory;
using CourseShop.Application.Category.Queries.GetAllCategoriesForSelect;
using CourseShop.Application.Category.Queries.GetAllMainCategories;
using CourseShop.Application.Category.Queries.GetSubcategoriesByMainCategoryId;
using CourseShop.Application.DTOs;
using CourseShop.Domain.Entities.Shop;

namespace CourseShop.Application.Mappings
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper()
        {
            CreateMap<CreateMainCategoryCommand, Domain.Entities.Shop.Category>();
            CreateMap<Domain.Entities.Shop.Category, GetAllMainCategoriesQuery>();
            CreateMap<CreateSubCategoryCommand, Domain.Entities.Shop.Category>();
            CreateMap<Domain.Entities.Shop.Category, GetSubcategoriesByMainCategoryIdQuery>();
            CreateMap<Domain.Entities.Shop.Category, GetAllSubCategoriesQuery>();
            CreateMap<DeleteCategoryCommand, Domain.Entities.Shop.Category>();
        }
    }
}
