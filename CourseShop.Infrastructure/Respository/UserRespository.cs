using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseShop.Domain.Entities.Shop;
using CourseShop.Domain.Interfaces;
using CourseShop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CourseShop.Infrastructure.Respository
{
    public class UserRespository : IUserRespository
    {
        private readonly CourseShopDbContext _context;

        public UserRespository(CourseShopDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<int>> GetUserFavoritesCourses(string userId)
            => await _context.FavoriteCourses.Where(f => f.Id == userId).Select(f => f.IdCourse).ToListAsync();

        public async Task<IEnumerable<Course>> GetUserFavoritesCoursesWithInfo(string userId)
            => await _context.FavoriteCourses.Where(f => f.Id == userId).Select(f => f.Course).ToListAsync();

        public async Task AddCourseToUserFavorites(FavoriteCourses favorite)
        {
            _context.FavoriteCourses.Add(favorite);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> CheckIfUserAlreadyHaveThisCourseInFavorites(string idUser, int idCourse)
        {
            var exists = _context.FavoriteCourses.Count(f => f.Id == idUser && f.IdCourse == idCourse);
            if (exists == 0)
            {
                return false;
            }
            return true;
        }

        public async Task DeleteCourseFromUserFavorites(FavoriteCourses favorite)
        {
            _context.FavoriteCourses.Remove(favorite);
            await _context.SaveChangesAsync();
        }
    }
}
