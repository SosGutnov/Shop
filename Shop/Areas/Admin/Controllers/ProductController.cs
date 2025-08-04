using Microsoft.AspNetCore.Mvc;
using Shop.Models;

namespace Shop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private IProductsRepository productsRepository;

        public ProductController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        
        public IActionResult Index()
        {
            var products = productsRepository.GetAll();
            return View(products);
        }
        
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            
            productsRepository.AddProduct(product);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            productsRepository.DeleteProduct(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            return View(productsRepository.TryGetByid(id));
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            productsRepository.Update(product);
            return RedirectToAction(nameof(Index));
        }
    }
}
