using DataAccess.Repositories;
using Domain.Entities;

namespace DataAccess.RepositoryImpementation
{
    public class MenuItemRepository : Repository<MenuItem>, IMenuItemRepository
    {
        public MenuItemRepository(TastyTrailsContext context) : base(context) { }
        public Task<List<MenuItem>> GetFoodItems()
        {
            throw new NotImplementedException();
        }
    }
}
