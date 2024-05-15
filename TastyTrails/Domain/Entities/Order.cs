namespace Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
        public decimal TotalPrice { get; set; }

        public ICollection<OrderMenuItem>? OrderMenuItems { get; set; }
        
        public int UserInfoId { get; set; }
        public virtual UserInfo? UserInfo { get; set; }
    }
}
