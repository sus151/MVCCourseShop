using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseShop.Domain.Entities.Shop;

namespace CourseShop.Domain.Interfaces
{
    public interface IDifficultyLevelRespository
    {
        public Task<IEnumerable<DifficultyLevel>> GetAllDifficultyLevels();
    }
}
