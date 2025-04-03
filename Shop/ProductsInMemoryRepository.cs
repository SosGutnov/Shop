using Shop.Models;

namespace Shop
{
    public class ProductsInMemoryRepository : IProductsRepository
    {
        private List<Product> products = new List<Product>()
        {
            new Product("Футболка Джинкс", 4100, "Состав: 100% Хлопок, Футболка Джинкс из \"Аркейн\", наивысшее качество", "/images/jinx.png"),
            new Product("Худи Гарри Поттер", 6200, "Состав: 100% Хлопок, наивысшее качество", "/images/harrypotter.png"),
            new Product("Футболка Канеки Кен", 6200, "Состав: 100% Хлопок, наивысшее качество", "/images/kaneki.png"),
            new Product("Футболка Принцесса Мононоке", 3500, "Состав: 100% Хлопок, Футболка Принцесса Мононоке из аниме \"Принцесса Мононоке\", наивысшее качество", "/images/mononoke.png"),
            new Product("Футболка Гию Томиока", 5000, "Состав: 100% Хлопок, Футболка Гию Томиока из аниме \"КРД\", наивысшее качество", "/images/tomiyoka.png")
        };

        public List<Product> GetAll()
        {
            return products;
        }

        public Product TryGetByid(int id)
        {
            return products.FirstOrDefault(product => product.Id == id);
        }
    }
}
