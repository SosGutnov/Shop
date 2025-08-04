using Shop.Models;

namespace Shop
{
    public interface IProductsRepository
    {
        List<Product> GetAll();
        public void AddProduct(Product product);
        public void DeleteProduct(int id);
        Product TryGetByid(int id);
        void Update(Product product);
    }
}