using Microsoft.AspNetCore.Mvc;

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
            var cart = cartsRepository.TryGetById(Constants.UserId);
            var productCount = cart?.Amount;
            return View("Cart", productCount);
        }
    }
}
