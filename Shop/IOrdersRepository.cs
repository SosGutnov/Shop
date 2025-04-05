using Shop.Models;

namespace Shop
{
    public interface IOrdersRepository
    {
        void Add(Order order);
    }
}