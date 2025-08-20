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
        public static Product ToProduct(ProductViewModel product)
        {
            return new Product
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
        public static Order ToOrder(OrderViewModel order)
        {
            if (order == null)
            {
                return null;
            }
            return new Order
            {
                Id = order.Id,
                User = new UserDeliveryInfo
                {
                    Id = order.User.Id,
                    Addres = order.User.Addres,
                    Name = order.User.Name,
                    Phone = order.User.Phone,
                },
                CreatedDateTime = order.CreatedDateTime,
                Status = (OrderStatus)order.Status,
                Items = order.Items.Select(x => ToCartItem(x)).ToList()

            };
        }

        public static CartItem ToCartItem(CartItemViewModel cartItem)
        {
            return new CartItem
            {

                Id = cartItem.Id,
                Amount = cartItem.Amount,
                Product = ToProduct(cartItem.Product)
            };
        }

        public static OrderViewModel ToOrderViewModel(Order order)
        {
            if (order == null)
            {
                return null;
            }
            return new OrderViewModel
            {
                Id = order.Id,
                User = new UserDeliveryInfoViewModel
                {
                    Id = order.User.Id,
                    Addres = order.User.Addres,
                    Name = order.User.Name,
                    Phone = order.User.Phone,
                },
                CreatedDateTime = order.CreatedDateTime,
                Status = (OrderStatusViewModel)(int)order.Status,
                Items = order.Items.Select(x=>ToCartItemViewModel(x)).ToList(),
            };
        }
    }
}
