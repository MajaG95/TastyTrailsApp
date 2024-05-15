﻿namespace Domain.Entities
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int RestaurantId { get; set; }
        public virtual Restaurant? Restaurant { get; set; }
        public virtual ICollection<OrderMenuItem>? OrderMenuItems { get; set; }


    }
}
