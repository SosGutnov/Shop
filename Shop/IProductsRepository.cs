using Shop.Models;

namespace Shop
{
    public interface IProductsRepository
    {
        List<Product> GetAll();

        Product TryGetByid(int id);
    }
}