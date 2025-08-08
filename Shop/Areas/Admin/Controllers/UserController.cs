using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shop.Areas.Admin.Models;
using Shop.Models;

namespace Shop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserManager userManager;
        private readonly IRolesRepository rolesRepository;

        public UserController(IUserManager userManager, IRolesRepository rolesRepository)
        {
            this.userManager = userManager;
            this.rolesRepository = rolesRepository;
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
        public IActionResult EditRights(int id)
        {
            var roles = rolesRepository.GetAll();
            var model = new EditRightsViewModel();
            model.RolesSelectList = new List<SelectListItem>();
            model.UserId = id;
            foreach (var role in roles)
            {
                model.RolesSelectList.Add(new SelectListItem { Text = role.Name, Value = role.Name });
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult EditRights(EditRightsViewModel model)
        {
            userManager.EditRights(model.UserId, new Role { Name = model.SelectedRoleName });
            return RedirectToAction(nameof(Index));
        }
    }
}
