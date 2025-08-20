
using Microsoft.EntityFrameworkCore;
using ShopDb;
using ShopDb.Models;

namespace ShopDb
{
    public class CartsDbRepository : ICartsRepository
    {
        private readonly DatabaseContext databaseContext;

        public CartsDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void Add(Product product, string userId)
        {
            var existingCart = TryGetById(userId);
            if (existingCart == null)
            {
                var newCart = new Cart
                {
                    UserId = userId
                };
                newCart.Items = new List<CartItem> { new CartItem { Product = product, Amount = 1, /*Cart = newCart*/ } };
                databaseContext.Carts.Add(newCart);
            }
            else
            {
                var existingCartItem = existingCart.Items.FirstOrDefault(x => x.Product.Id == product.Id);
                if (existingCartItem == null)
                {
                    
                    existingCart.Items.Add(new CartItem { Product = product, Amount = 1, /*Cart = existingCart*/ });
                }
                else
                {
                    existingCartItem.Amount += 1;
                }
            }
            databaseContext.SaveChanges();
        }

        public void Clear(string userId)
        {
            var existingCart = TryGetById(userId);
            databaseContext.Carts.Remove(existingCart);
            databaseContext.SaveChanges();
        }

        public void DecreaseAmount(Guid productId, string userId)
        {
            var existingCart = TryGetById(userId);
            var existingCartItem = existingCart?.Items?.FirstOrDefault(x => x.Product.Id == productId);
            if (existingCartItem == null)
            {
                return;
            }
            existingCartItem.Amount -= 1;
            if (existingCartItem.Amount == 0)
            {
                existingCart.Items.Remove(existingCartItem);
            }
            databaseContext.SaveChanges();

        }

        public Cart TryGetById(string userId)
        {
            return databaseContext.Carts.Include(x=>x.Items).ThenInclude(x=>x.Product).FirstOrDefault(x => x.UserId == userId);
        }

    }
}
