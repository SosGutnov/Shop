namespace Shop.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public UserDeliveryInfo User { get; set; }
        public List<CartItem> Items { get; set; }
        public bool IsCompleted { get; set; }

        public Order()
        {
            Id = Guid.NewGuid();
        }
    }
}
