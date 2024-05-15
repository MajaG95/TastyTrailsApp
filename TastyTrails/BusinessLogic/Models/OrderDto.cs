namespace BusinessLogic.Models
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public decimal TotalPrice { get; set; }
        public string? UserEmail { get; set; }
        public ICollection<MenuItemDto>? MenuItems { get; set; }
    }
}
