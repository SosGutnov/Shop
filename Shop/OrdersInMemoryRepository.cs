using Shop.Models;

namespace Shop
{
    public class OrdersInMemoryRepository : IOrdersRepository
    {
        private List<Cart> orders = new List<Cart>();

        public void Add(Cart order)
        {
            orders.Add(order);
        }
    }
}
