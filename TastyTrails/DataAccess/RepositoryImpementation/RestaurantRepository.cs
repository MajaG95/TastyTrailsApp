using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.RepositoryImpementation
{
    public class RestaurantRepository : Repository<Restaurant>, IRestaurantRepository
    {
        public RestaurantRepository(TastyTrailsContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Restaurant>> GetAllRestaurantsInfo()
        {
            return _context.Restaurants.Include(x => x.MenuItems);
        }
    }
}
