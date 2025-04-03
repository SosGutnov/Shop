using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Shop.Controllers
{
    public class AuthorizationController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
