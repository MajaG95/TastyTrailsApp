using BusinessLogic.Models;
using Domain.Entities;

namespace BusinessLogic.Mappers
{
    public static class OrderMapper
    {
        public static OrderDto ToDto(Order order)
        {
            return new OrderDto()
            {
                Id = order.Id,
                Status = GetStatusValue(order.Status),
                TotalPrice = order.TotalPrice,
                MenuItems = order?.OrderMenuItems?.Select(x => new MenuItemDto()
                {
                    Name = x.MenuItem.Name,
                    Ammount = x.Ammount
                }).ToList()
            };
        }

        private static string GetStatusValue(OrderStatus status)
        {
            switch (status) 
            {
                case OrderStatus.Pending:
                    return "Pending";
                case OrderStatus.InProgress:
                    return "InProgress";
                case OrderStatus.Delivered:
                    return "Delivered";
                case OrderStatus.Ready:
                    return "Ready";
                case OrderStatus.Denied:
                    return "Denied";
                default:
                    return "";
            }
        }
    }
}
