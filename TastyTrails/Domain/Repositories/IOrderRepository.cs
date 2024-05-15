using DataAccess.Repositories;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        public Task<Order> GetOrderWithMenuItems(int orderId);
    }
}
