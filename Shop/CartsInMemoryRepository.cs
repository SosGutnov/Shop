using Shop.Models;

namespace Shop
{
    public class CartsInMemoryRepository : ICartsRepository
    {
        private List<Cart> carts = new List<Cart>();

        public void Add(Product product, string userId)
        {
            var existingCart = TryGetById(userId);
            if (existingCart == null)
            {
                var newCart = new Cart
                (
                    Guid.NewGuid(),
                    userId,
                    new List<CartItem>
                    {
                        new CartItem
                        (
                            Guid.NewGuid(),
                            product,
                            1
                        )
                    }
                );
                carts.Add(newCart);
            }
            else
            {
                var existingCartItem = existingCart.Items.FirstOrDefault(x => x.Product.Id == product.Id);
                if (existingCartItem == null)
                {
                    existingCart.Items.Add(new CartItem
                        (
                            Guid.NewGuid(),
                            product,
                            1
                        ));
                }
                else
                {
                    existingCartItem.Amount += 1;
                }
            }
        }

        public void Clear(string userId)
        {
            var existingCart = TryGetById(userId);
            carts.Remove(existingCart);
        }

        public void DecreaseAmount(int productId, string userId)
        {
            var existingCart = TryGetById(userId);
            var existingCartItem = existingCart?.Items?.FirstOrDefault(x => x.Product.Id == productId);
            if (existingCartItem == null)
            {
                return;
            }
            existingCartItem.Amount -= 1;
            if(existingCartItem.Amount == 0)
            {
                existingCart.Items.Remove(existingCartItem);
            }


        }

        public Cart TryGetById(string userId)
        {
            return carts.FirstOrDefault(x => x.UserId == userId);
        }

    }
}
