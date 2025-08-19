using Shop.Models;
using ShopDb.Models;

namespace Shop.Helpers
{
    public static class Mapping
    {
        public static ProductViewModel ToProductViewModel(Product product)
        {
            if (product == null)
            {
                return null;
            }
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
                ImagePath = product.ImagePath,
            };
        }
        public static ProductViewModel ToProduct(ProductViewModel product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Cost = product.Cost,
                Description = product.Description,
                ImagePath = product.ImagePath,
            };
        }

        public static List<ProductViewModel> ToProductsViewModels(List<Product> products)
        {
            return products.Select(x => ToProductViewModel(x)).ToList();
        }

        public static CartViewModel ToCartViewModel(Cart cart)
        {
            if (cart == null)
                return null;
            return new CartViewModel
            {
                Id = cart.Id,
                UserId = cart.UserId,
                Items = cart.Items.Select(x => ToCartItemViewModel(x)).ToList()
            };
        }

        public static CartItemViewModel ToCartItemViewModel(CartItem cartItem)
        {
            return new CartItemViewModel
            {
                
                Id = cartItem.Id,
                Amount = cartItem.Amount,
                Product = ToProductViewModel(cartItem.Product)
            };
        }
    }
}
