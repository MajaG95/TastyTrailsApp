using BusinessLogic.Mappers;
using BusinessLogic.Models;
using DataAccess.UnitOfWork;

namespace BusinessLogic
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RestaurantService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<RestaurantDto>> GetAllRestaurants()
        {
            var restaurants = await _unitOfWork.RestaurantRepository.GetAllRestaurantsInfo();
            var restaurantDtos = new List<RestaurantDto>();
            foreach(var restaurant in restaurants)
            {
                restaurantDtos.Add(RestauranMapper.MapToDto(restaurant));
            };

            return restaurantDtos;
        }
    }
}
