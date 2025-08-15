using ShopDb;
using ShopDb.Models;

namespace Shop.Db
{
    public class ProductsDbRepository : IProductsRepository
    {
        private readonly DatabaseContext databaseContext;

        public ProductsDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public List<Product> GetAll()
        {
            return databaseContext.Products.ToList();
        }
        public void Add(Product product)
        {
            product.ImagePath = "/images/jinx.png";
            databaseContext.Products.Add(product);
            databaseContext.SaveChanges();
        }
        public void Delete(Guid id)
        {
            databaseContext.Products.Remove(TryGetByid(id));
            databaseContext.SaveChanges();
        }

        public Product TryGetByid(Guid id)
        {
            return databaseContext.Products.FirstOrDefault(product => product.Id == id);
        }

        public void Update(Product product)
        {
            var existingProduct = databaseContext.Products.FirstOrDefault(x=> x.Id==product.Id);
            if (existingProduct == null)
            {
                return;
            }
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Cost = product.Cost;
            databaseContext.SaveChanges();

        }
    }
}
