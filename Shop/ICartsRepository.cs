using Shop.Models;

namespace Shop
{
    public interface ICartsRepository
    {
        void Add(Product product, string userId);
        void Clear(string userId);
        void DecreaseAmount(int productId, string userId);
        Cart TryGetById(string userId);
    }
}