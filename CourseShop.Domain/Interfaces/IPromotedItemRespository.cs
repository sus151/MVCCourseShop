using CourseShop.Domain.Entities.CMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseShop.Domain.Interfaces
{
    public interface IPromotedItemRespository
    {
        public Task<IEnumerable<PromotedItem>> GetAllPromotedItems();
        public Task CreatePromotedItem(PromotedItem promotedItem);
        public Task<PromotedItem> GetPromotedItemById(int id);
        public Task DeletePromotedItem(PromotedItem promotedItem);
    }
}
