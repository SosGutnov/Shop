using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Shop.Controllers;
using Shop.Models;

namespace Shop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserManager userManager;

        public UserController(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var users = userManager.GetAll();
            return View(users);
        }

        public IActionResult Detail(int id)
        {
            var user = userManager.TryGetById(id);
            return View(user);
        }
        public IActionResult Delete(int id)
        {
            var user = userManager.TryGetById(id);
            userManager.Delete(user);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(UserAccount user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            userManager.Add(user);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            return View(userManager.TryGetById(id));
        }

        [HttpPost]
        public IActionResult Edit(UserAccount user)
        {
            userManager.Update(user);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ChangePassword(int id)
        {
            var changePassword = new ChangePassword()
            {
                UserId = id
            };

            return View(changePassword);
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePassword changePassword)
        {
            if (ModelState.IsValid)
            {
                userManager.ChangePassword(changePassword.UserId, changePassword.Password);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
