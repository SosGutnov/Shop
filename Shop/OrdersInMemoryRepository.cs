using Shop.Models;

namespace Shop
{
    public class OrdersInMemoryRepository : IOrdersRepository
    {
        private List<Order> orders = new List<Order>();

        public void Add(Order order)
        {
            orders.Add(order);
        }

        public List<Order> GetAll()
        {
            return orders;
        }

        public Order TryGetById(int id)
        {
            return orders.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateStatus(int orderId, OrderStatus newStatus)
        {
            var order = TryGetById(orderId);
            if(order != null)
            {
                order.Status = newStatus;
            }
            
        }
    }
}
