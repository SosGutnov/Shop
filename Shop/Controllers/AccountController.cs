using Microsoft.AspNetCore.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserManager userManager;

        public AccountController(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            if (!ModelState.IsValid)
                return View();
            var user = userManager.TryGetByName(login.UserName);
            if (user == null)
            {
                ModelState.AddModelError("", "Пользователя с таким логином не существует");
                return View();
            }
            if (user.Password != login.Password)
            {
                ModelState.AddModelError("", "Неправильный пароль");
                return View();
            }
            return RedirectToAction(nameof(Index), "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Register register)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.TryGetByName(register.UserName);
                if (user == null)
                {
                    userManager.Add(new UserAccount {

                        Name = register.UserName,
                        Email= register.UserEmail,
                        Phone = register.UserPhone,
                        Password = register.Password
                    });
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
                if (user != null)
                {
                    ModelState.AddModelError("", "Логин занят");
                    return View();
                }
            }

            return View();
        }
    }
}
