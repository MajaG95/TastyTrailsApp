using BusinessLogic.Models;

namespace BusinessLogic
{
    public interface IOrderService
    {
        public Task<OrderDto> GetOrderWithMenuItems(int orderId);
        public Task<int> CreateOrder(CreateOrderDto order);
        public Task<string> ChangeOrderStatus(int orderId, string status);
        public Task<string> GetOrderStatus(int orderId);
    }
}
