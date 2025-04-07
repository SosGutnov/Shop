using Microsoft.AspNetCore.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    public class AdminController : Controller
    {
        private IProductsRepository productsRepository;
        private IOrdersRepository ordersRepository;

        public AdminController(IProductsRepository productsRepository, IOrdersRepository ordersRepository)
        {
            this.productsRepository = productsRepository;
            this.ordersRepository = ordersRepository;
        }

        public IActionResult Orders()
        {
            var orders = ordersRepository.GetAll();
            return View(orders);
        }
        public IActionResult Products()
        {
            var products = productsRepository.GetAll();
            return View(products);
        }
        public IActionResult Roles()
        {
            return View();
        }
        public IActionResult Users()
        {
            return View();
        }
        public IActionResult AddProduct()
        {
            var product = new Product("Футболка", 4100, "asf", "/images/jinx.png");
            productsRepository.AddProduct(product);
            return View("Products", productsRepository.GetAll());
        }

        public IActionResult DeleteProduct(int id)
        {
            productsRepository.DeleteProduct(id);
            return View("Products", productsRepository.GetAll());
        }
    }
}
