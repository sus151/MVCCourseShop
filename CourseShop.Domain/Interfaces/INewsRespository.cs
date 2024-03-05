using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseShop.Domain.Entities.CMS;

namespace CourseShop.Domain.Interfaces
{
    public interface INewsRespository
    {
        public Task<IEnumerable<News>> GetAllNews();
        public Task CreateNews(News news);
        public Task<News> GetNewsById(int id);
        public Task DeleteNews(News  news);
    }
}
