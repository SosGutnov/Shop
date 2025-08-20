using Microsoft.AspNetCore.Mvc;
using ShopDb;
using Shop.Helpers;

namespace Shop.Views.Shared.Components.Cart
{

    public class CartViewComponent:ViewComponent
    {
        private readonly ICartsRepository cartsRepository;

        public CartViewComponent(ICartsRepository cartsRepository)
        {
            this.cartsRepository = cartsRepository;
        }

        public IViewComponentResult Invoke()
        {
            var cart = Mapping.ToCartViewModel(cartsRepository.TryGetById(Constants.UserId));
            var productCount = cart?.Amount ?? 0;
            return View("Cart", productCount);
        }
    }
}
