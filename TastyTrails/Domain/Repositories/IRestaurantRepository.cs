using DataAccess.Repositories;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IRestaurantRepository : IRepository<Restaurant>
    {
        public Task<IEnumerable<Restaurant>> GetAllRestaurantsInfo();
    }
}
