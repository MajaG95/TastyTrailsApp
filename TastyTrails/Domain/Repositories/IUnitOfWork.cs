using DataAccess.Repositories;
using Domain.Repositories;

namespace DataAccess.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IMenuItemRepository FoodItemRepository { get; }
        IRestaurantRepository RestaurantRepository { get; }
        IUserInfoRepository UserInfoRepository { get; }
        IOrderRepository OrderRepository { get; }

        IOrderMenuItemRepository OrderMenuItemRepository { get; }
    }
}
