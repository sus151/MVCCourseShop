using CourseShop.Domain.Interfaces;
using CourseShop.Infrastructure.Persistence;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseShop.Domain.Entities.Shop;

namespace CourseShop.Infrastructure.Respository
{
    public class CourseStepRespository : ICourseStepRespository
    {
        private readonly CourseShopDbContext _context;

        public CourseStepRespository(CourseShopDbContext context)
        {
            _context = context;
        }
        public async Task CreateCourseSteps(IEnumerable<CourseStep> courseSteps)
        {
            await _context.CourseSteps.AddRangeAsync(courseSteps);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCourseSteps(CourseStep courseStep)
        {
            _context.CourseSteps.Remove(courseStep);
            await _context.SaveChangesAsync();
        }
    }
}
