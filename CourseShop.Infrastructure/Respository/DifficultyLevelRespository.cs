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
    public class DifficultyLevelRespository : IDifficultyLevelRespository
    {
        private readonly CourseShopDbContext _context;

        public DifficultyLevelRespository(CourseShopDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DifficultyLevel>> GetAllDifficultyLevels()
            => await _context.DifficultyLevels.ToListAsync();
    }
}
