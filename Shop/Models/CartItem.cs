namespace Shop.Models
{
    public class CartItem
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public int Amount { get; set; }

        public CartItem(Guid id, Product product, int amount)
        {
            Id = id;
            Product = product;
            Amount = amount;
        }

        public decimal Cost
        {
            get
            {
                return Product.Cost * Amount;
            }
        }

    }
}
