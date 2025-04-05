namespace Shop.Models
{
    public class Cart
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public List<CartItem> Items { get; set; }

        public Cart(Guid id, string userId, List<CartItem> items)
        {
            Id = id;
            UserId = userId;
            Items = items;
        }

        public decimal Cost
        {
            get
            {
                return Items?.Sum(x => x.Cost) ?? 0;
            }
        }

        public decimal Amount
        {
            get
            {
                return Items?.Sum(x => x.Amount) ?? 0;
            }
        }
    }
}
