using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shop.Models;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly IFavoriteProductsRepository favoriteProductsRepository;

        public HomeController(IProductsRepository productsRepository, IFavoriteProductsRepository favoriteProductsRepository)
        {
            this.productsRepository = productsRepository;
            this.favoriteProductsRepository = favoriteProductsRepository;
        }

        public IActionResult Index()
        {
            var products = productsRepository.GetAll();
            return View("index", products);
        }

        public IActionResult Favorites()
        {
            var products = favoriteProductsRepository.GetAll();
            return View("favorites", products);
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

        public IActionResult Liked(int id, string pageName)
        {
            var product = productsRepository.TryGetByid(id);
            favoriteProductsRepository.Moved(product);
            if (pageName == "index")
                return Index();
            else 
                return Favorites();
            
        }
    }
}
