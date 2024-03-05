using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CourseShop.Application.User.Commands.AddCourseToUserFavorites;
using CourseShop.Application.User.Commands.DeleteCourseFormUserFavorites;
using CourseShop.Domain.Entities.Shop;

namespace CourseShop.Application.Mappings
{
    public class FavoriteCoursesMapper : Profile
    {
        public FavoriteCoursesMapper()
        {
            CreateMap<AddCourseToUserFavoritesCommand, FavoriteCourses>();
            CreateMap<DeleteCourseFromUserFavoritesCommand, FavoriteCourses>();
        }
    }
}
