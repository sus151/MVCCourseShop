using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseShop.Domain.Entities.Shop;

namespace CourseShop.Domain.Interfaces
{
    public interface IUserRespository
    {
        public Task<IEnumerable<int>> GetUserFavoritesCourses(string userId);
        public Task<IEnumerable<Course>> GetUserFavoritesCoursesWithInfo(string userId);
        public Task AddCourseToUserFavorites(FavoriteCourses favorite);
        public Task<bool> CheckIfUserAlreadyHaveThisCourseInFavorites(string idUser, int idCourse);
        public Task DeleteCourseFromUserFavorites(FavoriteCourses favorite);
    }
}
