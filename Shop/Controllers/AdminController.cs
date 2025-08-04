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
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            product.ImagePath = "/images/jinx.png";
            productsRepository.AddProduct(product);
            return RedirectToAction("Products");
        }

        public IActionResult DeleteProduct(int id)
        {
            productsRepository.DeleteProduct(id);
            return RedirectToAction("Products");
        }

        public IActionResult EditProduct(int id)
        {
            return View(productsRepository.TryGetByid(id));
        }

        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            productsRepository.Update(product);
            return RedirectToAction("Products");
        }
    }
}
