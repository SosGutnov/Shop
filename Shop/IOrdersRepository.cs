using Shop.Models;

namespace Shop
{
    public interface IOrdersRepository
    {
        void Add(Order order);
        List<Order> GetAll();
        Order TryGetById(int id);
        void UpdateStatus(int orderId, OrderStatus newsStatus);
    }
}