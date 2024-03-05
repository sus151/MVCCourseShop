using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseShop.Domain.Entities.Shop;

namespace CourseShop.Domain.Interfaces
{
    public interface ICourseRespository
    {
        public Task CreateCourse(Course  course);
        public Task<IEnumerable<Course>> GetAllCourses();
        public Task<Course> GetCourseById(int id);
        public Task DeleteCourse(Course course);
        public Task Commit();
        public Task<IEnumerable<Course>> GetCoursesByPhrase(string phrase, int number);




    }
}
