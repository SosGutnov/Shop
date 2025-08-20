using Microsoft.AspNetCore.Mvc;
using ShopDb;
using Shop.Helpers;

namespace Shop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsRepository productsRepository;

        public ProductController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public IActionResult Index(Guid id)
        {
            var product = productsRepository.TryGetByid(id);
            //if (product == null)
                //return new Exception("Вам хана");
            return View(Mapping.ToProductViewModel(product));
        }
    }
}
