namespace Domain.Entities
{
    public class OrderMenuItem
    {
        public int Id { get; set; }
        public int Ammount { get; set; }
        public int MenuItemId { get; set; }
        public virtual MenuItem? MenuItem { get; set; }

        public int OrderId { get; set; }
        public virtual Order? Order { get; set; }

    }
}
