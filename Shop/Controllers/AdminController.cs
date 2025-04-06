using Microsoft.AspNetCore.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductsRepository productsRepository;

        public AdminController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public IActionResult Orders()
        {
            return View();
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
    }
}
