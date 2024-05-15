using BusinessLogic.Emails;
using BusinessLogic.Mappers;
using BusinessLogic.Models;
using DataAccess.UnitOfWork;
using Domain.Entities;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;

namespace BusinessLogic
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserInfoService _userInfoService;
        private readonly IMenuItemService _menuItemService;
        private readonly IEmailDeliveryService _emailDeliveryService;
        private readonly IConfiguration _configuration;
        private readonly IHubContext<NotificationHub> _hubContext;

        public OrderService(IUnitOfWork unitOfWork, IUserInfoService userInfo, IMenuItemService menuItemService, IEmailDeliveryService emailDeliveryService,
                            IConfiguration configuration, IHubContext<NotificationHub> hubContext)
        {
            _unitOfWork = unitOfWork;
            _userInfoService = userInfo;
            _menuItemService = menuItemService;
            _emailDeliveryService = emailDeliveryService;
            _configuration = configuration;
            _hubContext = hubContext;
        }

        public async Task<int> CreateOrder(CreateOrderDto order)
        {
            if(!await DoesAllMenuItemBelongToSameRestaurant(order))
            {
                throw new Exception("You can order food from one restaurant!");
            }

            var userInfo = await _userInfoService.GetUserInfoByEmailAddress(order.UserEmail);
            if (userInfo == null)
            {
                throw new NullReferenceException($"User with email: {order.UserEmail} does not exist!");
            }

            var totalPrice = await _menuItemService.GetTotalPrice(order.MenuItems);
            var orderInfo = new Order()
            {
                Status = OrderStatus.Pending,
                UserInfoId = userInfo.Id,
                TotalPrice = totalPrice
            };

            var createdOrder = await _unitOfWork.OrderRepository.Add(orderInfo);

            foreach(var item in order.MenuItems)
            {
                var menuItem = await _menuItemService.GetMenuItemByName(item.Name);
                if (menuItem == null)
                {
                    throw new NullReferenceException($"Menu Item with Name: {item.Name} does not exist!");
                }

                var orderMenuItem = new OrderMenuItem()
                {
                    Ammount = item.Ammount,
                    MenuItemId = menuItem.Id,
                    OrderId = createdOrder.Id
                };

                await _unitOfWork.OrderMenuItemRepository.Add(orderMenuItem);
            }

            return createdOrder.Id;
        }

        public async Task<OrderDto> GetOrderWithMenuItems(int orderId)
        {
            var orderInfo =  await _unitOfWork.OrderRepository.GetOrderWithMenuItems(orderId);
            if(orderInfo == null)
            {
                throw new NullReferenceException($"Order with ID: {orderId} does not exist!");
            }
            var userInfo = await _userInfoService.GetUserInfoById(orderInfo.UserInfoId);
            if (userInfo == null)
            {
                throw new NullReferenceException($"User with ID: {orderInfo.Id} does not exist!");
            }

            var orderDto = OrderMapper.ToDto(orderInfo);
            orderDto.UserEmail = userInfo.Email;
            return orderDto;
        }

        public async Task<string> ChangeOrderStatus(int orderId, string status)
        {
            var order = await _unitOfWork.OrderRepository.GetById(orderId);
            if (order == null)
            {
                throw new NullReferenceException($"Order with ID: {orderId} does not exist!");
            }
            var userInfo = await _userInfoService.GetUserInfoById(order.UserInfoId);
            if (userInfo == null)
            {
                throw new NullReferenceException($"User with ID: {order.Id} does not exist!");
            }

            if (order.Status == OrderStatus.Denied || order.Status == OrderStatus.Delivered)
            {
                throw new Exception("Status cannot be changed!");
            }

            var newStatus = (OrderStatus)Enum.Parse(typeof(OrderStatus), status, true);
        
            await UpdateOrderStatus(order, newStatus, userInfo.Email);

            return order.Status.ToString();
        }

        public async Task<string> GetOrderStatus(int orderId)
        {
            var order = await _unitOfWork.OrderRepository.GetById(orderId);
            if(order != null)
            {
                return order.Status.ToString();
            }
            else
            {
                throw new Exception($"Order with ID: {orderId} does not exist!");
            }
        }

        private async Task<bool> DoesAllMenuItemBelongToSameRestaurant(CreateOrderDto orderDto)
        {
            var menuItems = new List<MenuItem>();
            foreach(var mi in orderDto.MenuItems)
            {
                var menuItem = await _menuItemService.GetMenuItemByName(mi.Name);
                menuItems.Add(menuItem);
            }

            var numberOfMenuItemsBelogsToSameRestaurant = menuItems.Select(x => x.RestaurantId).Distinct().ToList().Count();

            return orderDto.MenuItems.Count() == numberOfMenuItemsBelogsToSameRestaurant;
        }
        private async Task UpdateOrderStatus(Order order, OrderStatus newStatus, string userEmail)
        {
            switch (order.Status)
            {
                case OrderStatus.Pending:
                    if (StatusesFromPending().Any(x => x == newStatus))
                    {
                        await UdateOrderStatusAndSendEmail(order, newStatus, userEmail);
                    }
                    else
                    {
                        throw new Exception("Status from this state can be changed to: InProgress or Denied!");
                    }
                    break;
                case OrderStatus.InProgress:
                    if (StatusesFromInProgress().Any(x => x == newStatus))
                    {
                        await UdateOrderStatusAndSendEmail(order, newStatus, userEmail);
                    }
                    else
                    {
                        throw new Exception("Status from this state can be changed to: Ready State!");
                    }
                    break;
                case OrderStatus.Ready:
                    if (newStatus == OrderStatus.Delivered)
                    {
                        await UdateOrderStatusAndSendEmail(order, newStatus, userEmail);
                    }
                    else
                    {
                        throw new Exception("Status from this state can be changed to: Delivered State!");
                    }
                    break;
                default:
                    break;
            }
        }
        
        private async Task UdateOrderStatusAndSendEmail(Order order, OrderStatus newStatus, string userEmail)
        {
            await _hubContext.Clients.All.SendAsync("StatusChanges", $"New status is {newStatus}");
            order.Status = newStatus;
            await _unitOfWork.OrderRepository.Update(order);
            SendEmailForStatusChange(order.Id, newStatus.ToString(), userEmail);
        }
        
        private void SendEmailForStatusChange(int orderId, string newStatus, string userEmail)
        {
            var from = _configuration.GetSection("Email_From").Exists() ? _configuration.GetSection("Email_From").Value : String.Empty;  
            var subject = "Status Change";
            var body = $"Your order {orderId} now is in state: {newStatus}";
            MailMessage mailMessage = new MailMessage(from, userEmail, subject, body);

            _emailDeliveryService.SendEmail(mailMessage);
        }
        
        private List<OrderStatus> StatusesFromPending() => new List<OrderStatus>() { OrderStatus.InProgress, OrderStatus.Denied };
        
        private List<OrderStatus> StatusesFromInProgress() => new List<OrderStatus>() { OrderStatus.Ready };

    }
}
