using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using CourseShop.Domain.Entities.Shop;

namespace CourseShop.Domain.Interfaces
{
    public interface ICategoryRespository
    {
        public Task<IEnumerable<Category>> GetAllMainCategories();
        public Task<IEnumerable<Category>> GetAllCategoriesWithSubCategoriesAndCourses();
        public Task<Category> GetSubCategoryWithCoursesById(int id);
        public Task<Category> GetMainCategoryById(int id);


        public Task CreateCategory(Category category);
        public Task<IEnumerable<Category>> GetSubCategoriesByMainCategoryId(int id);

        public Task<IEnumerable<Category>> GetAllSubCategories();
        public Task DeleteCategory(int id);
        public Task<Category> GetCategoryById(int id);
    }
}
