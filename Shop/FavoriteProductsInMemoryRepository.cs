using Shop.Models;

namespace Shop
{
    public class FavoriteProductsInMemoryRepository : IFavoriteProductsRepository
    {
        private List<Product> favoriteProducts = new List<Product>();

        public List<Product> GetAll()
        {
            return favoriteProducts;
        }
        public void Moved(Product product)
        {
            if (!favoriteProducts.Contains(product))
            {
                product.InFollow = "currentColor";
                favoriteProducts.Add(product);
            }
            else
            {
                product.InFollow = "none";
                favoriteProducts.Remove(product);
            }

        }

        public Product TryGetByid(int id)
        {
            return favoriteProducts.FirstOrDefault(product => product.Id == id);
        }
    }
}
