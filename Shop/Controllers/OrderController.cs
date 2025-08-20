using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Helpers;
using Shop.Models;
using ShopDb;
using ShopDb.Models;
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
        public ActionResult Buy(UserDeliveryInfoViewModel user)
        {
            var existingsCart = cartsRepository.TryGetById(Constants.UserId);
            var existingsCartViewModel = Mapping.ToCartViewModel(existingsCart);

            var order = new Order
            {
                User = new UserDeliveryInfo
                {
                    Name = user.Name,
                    Addres = user.Addres,
                    Phone = user.Phone,
                },
                Items = existingsCart.Items
            };
            ordersRepository.Add(order);

            cartsRepository.Clear(Constants.UserId);
            return View();
        }
    }
}
