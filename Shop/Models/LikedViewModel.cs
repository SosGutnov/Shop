﻿using ShopDb.Models;

namespace Shop.Models
{
    public class LikedViewModel
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public Product Product { get; set; }
    }
}
