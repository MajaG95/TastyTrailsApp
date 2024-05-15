using BusinessLogic.Models;
using Domain.Entities;

namespace BusinessLogic.Mappers
{
    public static class RestauranMapper
    {
        public static RestaurantDto MapToDto(Restaurant restaurant)
        {
            return new RestaurantDto()
            {
                Address = restaurant.Address,
                City = restaurant.City,
                Country = restaurant.Country,
                Currency = restaurant.Currency,
                Description = restaurant.Description,
                Name = restaurant.Name,
                WorkingHours = restaurant.WorkingHours,
                MenuItems = restaurant.MenuItems.Select(x => new MenuItemDetailsDto()
                {
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price
                }).ToList()
            };
        }
    }
}
