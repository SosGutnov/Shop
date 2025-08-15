using Microsoft.AspNetCore.Mvc;
using Shop.Db;
using Shop.Helpers;
using Shop.Models;

namespace Shop.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly ICartsRepository cartsRepository;

        public CartController(IProductsRepository productsRepository, ICartsRepository cartsRepository)
        {
            this.productsRepository = productsRepository;
            this.cartsRepository = cartsRepository;
        }

        public IActionResult Index()
        {
            var cart = cartsRepository.TryGetById(Constants.UserId);
            return View(Mapping.ToCartViewModel(cart));
        }

        public IActionResult Add(Guid productId)
        {
            var productDb = productsRepository.TryGetByid(productId);
            cartsRepository.Add(productDb, Constants.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult DecreaseAmount(Guid productId)
        {
            cartsRepository.DecreaseAmount(productId, Constants.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult Clear(int productId)
        {
            cartsRepository.Clear(Constants.UserId);
            return RedirectToAction("Index");
        }
    }
}
