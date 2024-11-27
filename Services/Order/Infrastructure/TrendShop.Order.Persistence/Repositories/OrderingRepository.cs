using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendShop.Order.Application.Interfaces;
using TrendShop.Order.Domain.Entities;
using TrendShop.Order.Persistence.Context;

namespace TrendShop.Order.Persistence.Repositories
{
    public class OrderingRepository : IOrderingRepository
    {
        private readonly OrderContext _context;
        public OrderingRepository(OrderContext context)
        {
            _context = context;
        }

        public List<Ordering> GetOrderingsByUserId(string id)
        {
            var values = _context.Orderings.Where(x => x.UserID == id).ToList();
            return values;
        }
    }
}
