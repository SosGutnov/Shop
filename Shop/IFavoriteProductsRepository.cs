using Shop.Models;

namespace Shop
{
    public interface IFavoriteProductsRepository
    {
        void Moved(Product product);
        List<Product> GetAll();
        Product TryGetByid(int id);
    }
}