using Domain.Entities;
using Domain.Repositories;

namespace DataAccess.RepositoryImpementation
{
    public class OrderMenuItemRepository : Repository<OrderMenuItem>, IOrderMenuItemRepository
    {
        public OrderMenuItemRepository(TastyTrailsContext context) : base(context)
        {
        }
    }
}
