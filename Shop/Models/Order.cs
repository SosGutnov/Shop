namespace Shop.Models
{
    public class Order
    {
        private static int _id;

        public int Id { get; set; }
        public UserDeliveryInfo User { get; set; }
        public List<CartItem> Items { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public Order()
        {
            Id = _id;
            Status = OrderStatus.Created;
            CreatedDateTime = DateTime.Now;
            _id += 1;
        }

        public decimal Cost
        {
            get
            {
                return Items?.Sum(x => x.Cost) ?? 0;
            }
        }
    }
}
