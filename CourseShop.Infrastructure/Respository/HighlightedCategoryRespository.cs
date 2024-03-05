using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseShop.Domain.Entities.CMS;
using CourseShop.Domain.Interfaces;
using CourseShop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CourseShop.Infrastructure.Respository
{
    public class HighlightedCategoryRespository : IHighlightedCategoryRespository
    {
        private readonly CourseShopDbContext _context;

        public HighlightedCategoryRespository(CourseShopDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HighlightedCategory>> GetAllHighlightedCategories()
            => await _context.HighlightedCategories.Include(h => h.Category).ToListAsync();

        public async Task CreateHighlightedCategory(HighlightedCategory highlightedCategory)
        {
            _context.Add(highlightedCategory);
            await _context.SaveChangesAsync();
        }

        public async Task<HighlightedCategory> GetHighlightedCategoryById(int id)
            => await _context.HighlightedCategories.Where(h=>h.IdHighlightedCategory==id).Include(h => h.Category).FirstOrDefaultAsync();

        public async Task DeleteHighlightedCategory(HighlightedCategory highlightedCategory)
        {
            _context.HighlightedCategories.Remove(highlightedCategory);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<HighlightedCategory>> GetAllHighlightedCategoriesWithCourses()
            => await _context.HighlightedCategories
                .Include(h => h.Category)
                .ThenInclude(c => c.Courses)
                .Take(10)
                .ToListAsync();

    }
}
