using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Db;
using Shop.Helpers;
using Shop.Models;
using System.Data;

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
            var existingsCartViewModel = Mapping.ToCartViewModel(existingsCart);
            var order = new Order
            {
                User = user,
                Items = existingsCartViewModel.Items,
            };
            ordersRepository.Add(order);

            cartsRepository.Clear(Constants.UserId);
            return View();
        }
    }
}
