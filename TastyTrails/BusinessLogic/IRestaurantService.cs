using BusinessLogic.Models;

namespace BusinessLogic
{
    public interface IRestaurantService
    {
        public Task<List<RestaurantDto>> GetAllRestaurants();
    }
}
