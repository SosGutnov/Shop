
using ShopDb.Models;

namespace Shop.Db
{
    public interface ICartsRepository
    {
        void Add(Product product, string userId);
        void Clear(string userId);
        void DecreaseAmount(Guid productId, string userId);
        Cart TryGetById(string userId);
    }
}