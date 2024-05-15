using BusinessLogic;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;

namespace TastyTrails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<OrderDto>> GetOrder(int orderId)
        {
            try
            {
                var orderInfo = await _orderService.GetOrderWithMenuItems(orderId);
                return Ok(orderInfo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateOrder(CreateOrderDto order)
        {
            try
            {
                var id = await _orderService.CreateOrder(order);
                return id;
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPatch("changeOrderStatus/{orderId}/{status}")]
        public async Task<ActionResult<string>> ChangeOrderStatus(int orderId, string status)
        {
            try
            {
                return await _orderService.ChangeOrderStatus(orderId, status);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getOrderStatus/{orderId}")]
        public async Task<ActionResult<string>> GetOrderStatus(int orderId)
        {
            try
            {
                return await _orderService.GetOrderStatus(orderId);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
