using Microsoft.AspNetCore.Mvc;

namespace Shop.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
