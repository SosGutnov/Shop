using Microsoft.AspNetCore.Mvc;
using Shop.Helpers;
using Shop.Models;
using ShopDb;
using ShopDb.Models;

namespace Shop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private IOrdersRepository ordersRepository;
        

        public OrderController(IOrdersRepository ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }

        public IActionResult Index()
        {
            var orders = ordersRepository.GetAll().Select(x=>x.ToOrderViewModel()).ToList();

            return View(orders);
        }

        public IActionResult Detail(Guid id)
        {
            var order = ordersRepository.TryGetById(id);
            return View(order.ToOrderViewModel());
        }
        [HttpPost]
        public IActionResult UpdateStatus(Guid id, OrderStatusViewModel status)
        {
            ordersRepository.UpdateStatus(id, (OrderStatus)status);
            return RedirectToAction(nameof(Index));
        }

    }
}
