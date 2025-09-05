using Shop.Models;
using ShopDb.Models;

namespace Shop.Helpers
{
    public static class Mapping
    {
        public static ProductViewModel ToProductViewModel(this Product product)
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
        public static Product ToProduct(this ProductViewModel product)
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

        public static List<ProductViewModel> ToProductsViewModels(this List<Product> products)
        {
            return products.Select(x=>x.ToProductViewModel()).ToList();
        }

        public static CartViewModel ToCartViewModel(this Cart cart)
        {
            if (cart == null)
                return null;
            return new CartViewModel
            {
                Id = cart.Id,
                UserId = cart.UserId,
                Items = cart.Items.Select(x => x.ToCartItemViewModel()).ToList()
            };
        }

        public static CartItemViewModel ToCartItemViewModel(this CartItem cartItem)
        {
            return new CartItemViewModel
            {
                
                Id = cartItem.Id,
                Amount = cartItem.Amount,
                Product = cartItem.Product.ToProductViewModel()
            };
        }
        public static Order ToOrder(this OrderViewModel order)
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
                Items = order.Items.Select(x => x.ToCartItem()).ToList()

            };
        }

        public static CartItem ToCartItem(this CartItemViewModel cartItem)
        {
            return new CartItem
            {

                Id = cartItem.Id,
                Amount = cartItem.Amount,
                Product = cartItem.Product.ToProduct()
            };
        }

        public static OrderViewModel ToOrderViewModel(this Order order)
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
                Items = order.Items.Select(x=>x.ToCartItemViewModel()).ToList(),
            };
        }

        public static UserViewModel ToUserViewModel(this User user)
        {
            if(user != null)
            {
                return new UserViewModel
                {
                    Id = user.Id,
                    Name = user.UserName,
                    Email = user.Email,
                    Password = user.PasswordHash,
                    Phone = user.PhoneNumber,
                };
            }
            return null;
        }

        public static User ToUserViewModel(this UserViewModel user)
        {
            if (user != null)
            {
                return new User
                {
                    Id = user.Id,
                    UserName = user.Name,
                    Email = user.Email,
                    PasswordHash = user.Password,
                    PhoneNumber = user.Phone,
                };
            }
            return null;
        }
    }
}
