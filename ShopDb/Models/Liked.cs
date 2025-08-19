using ShopDb.Models;
using System.ComponentModel.DataAnnotations;

namespace ShopDb.Models
{
    public class Liked
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public Product Product { get; set; }
    }
}
