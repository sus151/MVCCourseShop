using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseShop.Domain.Entities.Shop;

namespace CourseShop.Domain.Interfaces
{
    public interface ICourseStepRespository
    {
        public Task CreateCourseSteps(IEnumerable<CourseStep> courseSteps);
        public Task DeleteCourseSteps(CourseStep courseStep);
    }
}
