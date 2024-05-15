using DataAccess.Repositories;
using DataAccess.UnitOfWork;
using Domain.Repositories;

namespace DataAccess.RepositoryImpementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TastyTrailsContext _context;
        public UnitOfWork(TastyTrailsContext context) 
        { 
            _context = context;
            FoodItemRepository = new MenuItemRepository(context);
            RestaurantRepository = new RestaurantRepository(context);
            UserInfoRepository = new UserInfoRepository(context);
            OrderRepository = new OrderRepository(context);
            OrderMenuItemRepository = new OrderMenuItemRepository(context);
        }

        //private set;
        public IMenuItemRepository FoodItemRepository { get; set; }

        public IRestaurantRepository RestaurantRepository { get; set; }

        public IUserInfoRepository UserInfoRepository { get; set; }

        public IOrderRepository OrderRepository { get; set; }

        public IOrderMenuItemRepository OrderMenuItemRepository { get; set; }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
