using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shop.Areas.Admin.Models;
using Shop.Helpers;
using Shop.Models;
using ShopDb;
using ShopDb.Models;
using System.Threading.Tasks;

namespace Shop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var users = userManager.Users.Select(x=>x.ToUserViewModel()).ToList();
            return View(users);
        }

        public async Task<IActionResult> Detail(string id)
        {
            var user = userManager.FindByIdAsync(id).Result.ToUserViewModel();
            return View(user);
        }
        public IActionResult Delete(string id)
        {
            var user = userManager.FindByIdAsync(id).Result;
            userManager.DeleteAsync(user).Wait();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(UserViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            var newUser = new User { Email = user.Email, UserName = user.Name, PhoneNumber = user.Phone};
            var result = userManager.CreateAsync(newUser, user.Password).Result;
            if (result.Succeeded)
            {
                userManager.AddToRoleAsync(newUser, Constants.UserRoleName).Wait();
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(string id)
        {
            var user = userManager.FindByIdAsync(id).Result.ToUserViewModel();
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(UserViewModel user)
        {
            var existingUser = userManager.FindByIdAsync(user.Id).Result;
            existingUser.UserName = user.Name;
            existingUser.PhoneNumber = user.Phone;
            existingUser.Email = user.Email;
            userManager.UpdateAsync(existingUser).Wait();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult ChangePassword(string id)
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
                var user = userManager.FindByIdAsync(changePassword.UserId).Result;
                var newHashPassword = userManager.PasswordHasher.HashPassword(user, changePassword.Password);
                user.PasswordHash = newHashPassword;
                userManager.UpdateAsync(user).Wait();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public IActionResult EditRights(string id)
        {
            var roles = roleManager.Roles.ToList();
            var model = new EditRightsViewModel
            {
                RolesSelectList = new List<SelectListItem>(),
                UserId = id
            };
            foreach (var role in roles)
            {
                model.RolesSelectList.Add(new SelectListItem { Text = role.Name, Value = role.Name });
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult EditRights(string id, EditRightsViewModel model)
        {
            var user = userManager.FindByIdAsync(id).Result;
            var oldRole = userManager.GetRolesAsync(user).Result;

            userManager.RemoveFromRoleAsync(user, oldRole[0]).Wait();
            userManager.AddToRoleAsync(user, model.SelectedRoleName).Wait();

            return RedirectToAction(nameof(Index));
        }
    }
}
