using Domain.Entities;

namespace DataAccess.Repositories
{
    public interface IMenuItemRepository : IRepository<MenuItem>
    {
        Task<List<MenuItem>> GetFoodItems();
    }
}
