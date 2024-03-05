using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseShop.Domain.Entities.CMS;
using CourseShop.Domain.Entities.Shop;
using CourseShop.Domain.Interfaces;
using CourseShop.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CourseShop.Infrastructure.Respository
{
    public class NewsRespository : INewsRespository
    {
        private readonly CourseShopDbContext _context;

        public NewsRespository(CourseShopDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<News>> GetAllNews()
            => await _context.News.Include(n => n.Category).Include(n => n.Course).Include(n=>n.MainCategory).ToListAsync();

        public async Task CreateNews(News news)
        {
            _context.Add(news);
            await _context.SaveChangesAsync();
        }

        public async Task<News> GetNewsById(int id)
            => await _context.News.Where(n => n.IdNews == id).Include(c=>c.Category).Include(c=>c.Course).Include(c=>c.MainCategory).FirstOrDefaultAsync();

        public async Task DeleteNews(News news)
        {
            _context.News.Remove(news);
            await _context.SaveChangesAsync();
        }
    }
}
