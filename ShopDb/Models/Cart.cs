﻿

namespace ShopDb.Models
{
    public class Cart
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public List<CartItem> Items { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public Cart()
        {
            Items = new List<CartItem>();
            CreatedDateTime = DateTime.Now;
        }
    }
}
