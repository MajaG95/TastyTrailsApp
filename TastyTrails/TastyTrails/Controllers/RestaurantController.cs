using BusinessLogic;
using DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace TastyTrails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var restaurants = await _restaurantService.GetAllRestaurants();
            return Ok(restaurants);
        }
    }
}
