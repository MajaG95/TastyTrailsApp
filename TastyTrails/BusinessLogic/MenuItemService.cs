using BusinessLogic.Models;
using DataAccess.UnitOfWork;
using Domain.Entities;

namespace BusinessLogic
{
    public class MenuItemService : IMenuItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MenuItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MenuItem> GetMenuItemByName(string name)
        {
            var menuItem = await _unitOfWork.FoodItemRepository.Find(x => x.Name == name);
            if(menuItem == null)
            {
                throw new Exception($"Menu item: {name} does not exist!");
            }
            return menuItem;
        }

        public async Task<decimal> GetTotalPrice(List<MenuItemDto> menuItems)
        {
            decimal totalPrice = 0;
            foreach(var ma in menuItems)
            {
                var menuItem = await _unitOfWork.FoodItemRepository.Find(x => x.Name == ma.Name);
                totalPrice += (menuItem.Price * ma.Ammount);
            }

            return totalPrice;
        }
    }
}
