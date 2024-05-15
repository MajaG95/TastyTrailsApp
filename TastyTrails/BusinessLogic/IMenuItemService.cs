using BusinessLogic.Models;
using Domain.Entities;

namespace BusinessLogic
{
    public interface IMenuItemService
    {
        Task<MenuItem> GetMenuItemByName(string name);
        Task<decimal> GetTotalPrice(List<MenuItemDto> menuItems);
    }
}
