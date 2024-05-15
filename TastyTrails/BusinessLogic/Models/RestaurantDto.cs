namespace BusinessLogic.Models
{
    public class RestaurantDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
        public string? Currency { get; set; }
        public string? WorkingHours { get; set; }
        public virtual ICollection<MenuItemDetailsDto>? MenuItems { get; set; }
    }
}
