using Microsoft.AspNetCore.Mvc;
using Shop.Models;

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
            var orders = ordersRepository.GetAll();
            return View(orders);
        }

        public IActionResult Detail(int id)
        {
            var order = ordersRepository.TryGetById(id);
            return View(order);
        }
        [HttpPost]
        public IActionResult UpdateStatus(int id, OrderStatus status)
        {
            ordersRepository.UpdateStatus(id, status);
            return RedirectToAction(nameof(Index));
        }

    }
}
