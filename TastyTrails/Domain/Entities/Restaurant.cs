namespace Domain.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
        public string? Currency { get; set; }
        public string? WorkingHours { get; set; }
        public virtual ICollection<MenuItem>? MenuItems { get; set; }
    }
}