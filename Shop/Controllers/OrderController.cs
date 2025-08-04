using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICartsRepository cartsRepository;
        private readonly IOrdersRepository ordersRepository;

        public OrderController(ICartsRepository cartsRepository, IOrdersRepository ordersRepository)
        {
            this.cartsRepository = cartsRepository;
            this.ordersRepository = ordersRepository;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Buy(UserDeliveryInfo user)
        {
            var existingsCart = cartsRepository.TryGetById(Constants.UserId);

            var order = new Order
            {
                User = user,
                Items = existingsCart.Items
            };
            ordersRepository.Add(order);

            cartsRepository.Clear(Constants.UserId);
            return View();
        }
    }
}
