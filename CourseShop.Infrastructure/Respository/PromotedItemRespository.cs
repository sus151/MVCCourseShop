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
    public class PromotedItemRespository : IPromotedItemRespository
    {
        private readonly CourseShopDbContext _context;

        public PromotedItemRespository(CourseShopDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PromotedItem>> GetAllPromotedItems()
            => await _context.PromotedItems.Include(n => n.Category).Include(n => n.Course).Include(n => n.MainCategory).ToListAsync();

        public async Task CreatePromotedItem(PromotedItem promotedItem)
        {
            _context.Add(promotedItem);
            await _context.SaveChangesAsync();
        }

        public async Task<PromotedItem> GetPromotedItemById(int id)
        => await _context.PromotedItems.Where(p=>p.IdPromotedItem==id).Include(c => c.Category).Include(c => c.Course).Include(c => c.MainCategory).FirstOrDefaultAsync();

        public async Task DeletePromotedItem(PromotedItem promotedItem)
        {
            _context.PromotedItems.Remove(promotedItem);
            await _context.SaveChangesAsync();
        }
    }
}
