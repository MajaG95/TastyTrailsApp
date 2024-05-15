namespace BusinessLogic.Models
{
    public class CreateOrderDto
    {
        public string? UserEmail { get; set; }
        public List<MenuItemDto>? MenuItems { get; set; }
    }
}
