using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shop.Db;
using Shop.Helpers;
using Shop.Models;
using ShopDb.Models;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly ILikedRepository likedRepository;

        public HomeController(IProductsRepository productsRepository, ILikedRepository likedRepository)
        {
            this.productsRepository = productsRepository;
            this.likedRepository = likedRepository;
        }

        public IActionResult Index()
        {
            var products = productsRepository.GetAll();
            return View(Mapping.ToProductsViewModels(products));
        }

        public IActionResult Favorites()
        {
            var products = likedRepository.TryGetAllByUserId(Constants.UserId).Select(x => Mapping.ToProductViewModel(x.Product)).ToList();
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Liked(Guid id, string pageName)
        {
            var product = productsRepository.TryGetByid(id);
            likedRepository.AddOrDelete(new Liked{ Product = product, UserId = Constants.UserId });
            if (pageName == "index")
                return RedirectToAction(nameof(Index));
            else
                return RedirectToAction(nameof(Favorites));

        }
    }
}
