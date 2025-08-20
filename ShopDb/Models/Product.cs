

namespace ShopDb.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Cost { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public List<CartItem> CartItems { get; set; }

        public Product()
        {
            CartItems = new List<CartItem>();
        }

        public Product(string id, string name, decimal cost, string description, string imagePath) : base()
        {
            Id = new Guid(id);
            Name = name;
            Cost = cost;
            Description = description;
            ImagePath = imagePath;
        }
    }
}
