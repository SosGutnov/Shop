
using ShopDb.Models;

namespace Shop.Db
{
    public interface IProductsRepository
    {
        List<Product> GetAll();
        public void Add(Product product);
        public void Delete(Guid id);
        Product TryGetByid(Guid id);
        void Update(Product product);
    }
}