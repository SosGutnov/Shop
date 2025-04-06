using Shop.Models;

namespace Shop
{
    public interface IProductsRepository
    {
        List<Product> GetAll();
        public void AddProduct(Product product);
        Product TryGetByid(int id);
    }
}