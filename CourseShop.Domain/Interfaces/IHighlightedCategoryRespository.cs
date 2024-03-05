using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseShop.Domain.Entities.CMS;

namespace CourseShop.Domain.Interfaces
{
    public interface IHighlightedCategoryRespository
    {
        public Task<IEnumerable<HighlightedCategory>> GetAllHighlightedCategories();
        public Task CreateHighlightedCategory(HighlightedCategory highlightedCategory);
        public Task<HighlightedCategory> GetHighlightedCategoryById(int id);
        public Task DeleteHighlightedCategory(HighlightedCategory highlightedCategory);
        public Task<IEnumerable<HighlightedCategory>> GetAllHighlightedCategoriesWithCourses();
    }
}
