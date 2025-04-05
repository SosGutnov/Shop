using Microsoft.AspNetCore.Mvc;

namespace Shop.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Orders()
        {
            return View("Orders");
        }
        public IActionResult Products()
        {
            return View("Products");
        }
        public IActionResult Roles()
        {
            return View("Roles");
        }
        public IActionResult Users()
        {
            return View("Users");
        }
    }
}
