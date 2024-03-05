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
    public class CourseRespository : ICourseRespository
    {
        private readonly CourseShopDbContext _context;

        public CourseRespository(CourseShopDbContext context)
        {
            _context = context;
        }

        public async Task CreateCourse(Course course)
        {

            _context.Add(course);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Course>> GetAllCourses()
            => await _context.Courses.Include(x => x.DifficultyLevel).Include(x => x.Category)
                .ThenInclude(c => c.MainCategory).ToListAsync();


        public async Task<Course> GetCourseById(int id)
            => await _context.Courses
                .Where(x => x.IdCourse == id)
                .Include(x => x.DifficultyLevel)
                .Include(x => x.Category)
                .ThenInclude(c => c.MainCategory)
                .Include(c => c.CourseSteps)
                .FirstOrDefaultAsync();


        public async Task DeleteCourse(Course course)
        {
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
        }


        public async Task Commit()
            => await _context.SaveChangesAsync();

        public async Task<IEnumerable<Course>> GetCoursesByPhrase(string phrase, int number)
            => await _context.Courses.Where(c => c.Name
                    .ToLower()
                    .Contains(phrase.ToLower()))
                    .Take(number)
                    .AsNoTracking()
                    .ToListAsync();
    }
}
 