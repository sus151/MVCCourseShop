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
    public class CategoryRespository : ICategoryRespository
    {
        private readonly CourseShopDbContext _context;

        public CategoryRespository(CourseShopDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesWithSubCategoriesAndCourses()
        {
            var categories = await _context.Categories
                .Where(x => x.MainCategory == null)
                .Include(x=>x.SubCategories)
                .ThenInclude(subcategory=>subcategory.Courses)
                .ToListAsync();
            
            return categories;
        }

        public async Task<Category> GetSubCategoryWithCoursesById(int id)
        {
            var category = await _context.Categories
                .Where(x => x.IdCategory == id && x.MainCategory!=null)
                .Include(x=>x.MainCategory)
                .Include(x=>x.Courses)
                .ThenInclude(course=>course.DifficultyLevel)
                .FirstOrDefaultAsync();

            return category;
        }

        public async Task<Category> GetMainCategoryById(int id)
        => await _context.Categories
                .Where(x => x.IdCategory == id && x.MainCategory == null)
                .Include(x => x.SubCategories)
                .ThenInclude(subcategory => subcategory.Courses)
                .FirstOrDefaultAsync();
      
           
     

        public async Task CreateCategory(Category category)
        {
            _context.Add(category);
            await _context.SaveChangesAsync();
        }


        public async Task<IEnumerable<Category>> GetAllMainCategories()
        => await _context.Categories.Where(c=> c.MainCategory==null).ToListAsync();

        public async Task<IEnumerable<Category>> GetSubCategoriesByMainCategoryId(int id)
        => await _context.Categories.Where(c=>c.IdMainCategory==id).ToListAsync();

        public async Task<IEnumerable<Category>> GetAllSubCategories()
            => await _context.Categories.Where(c=>c.IdMainCategory!=null).ToListAsync();

        public async Task DeleteCategory(int id)
        {
            var category = await GetCategoryById(id);

            if (category != null)
            {
                var subCategories = await _context.Categories.Where(c => c.IdMainCategory == id).ToListAsync();
                foreach (var subCategory in subCategories)
                {
                    subCategory.IdMainCategory = null;
                    _context.Categories.Remove(subCategory);
                }

                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }


        public async Task<Category> GetCategoryById(int id)
            => await _context.Categories.Where(c => c.IdCategory == id).FirstOrDefaultAsync();
    }
}
