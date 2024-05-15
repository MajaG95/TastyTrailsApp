using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.RepositoryImpementation
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(TastyTrailsContext context) : base(context)
        {
        }

        public async Task<Order> GetOrderWithMenuItems(int orderId)
        {
            return await _context.Orders.Include(x => x.OrderMenuItems).ThenInclude(i => i.MenuItem).Where(a => a.Id == orderId).FirstOrDefaultAsync();
        }
    }
}
