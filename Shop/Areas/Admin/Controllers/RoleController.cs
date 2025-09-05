using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.Areas.Admin.Models;

namespace Shop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var roles = roleManager.Roles.ToList();
            return View(roles);
        }
        public IActionResult Add()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Add(IdentityRole role)
        {
            if (roleManager.Roles.FirstOrDefault(x => x.Id == role.Id) != null)
            {
                ModelState.AddModelError("", "Такая роль уже существует");
            }
            if (ModelState.IsValid)
            {
                roleManager.CreateAsync(role).Wait();
                return RedirectToAction(nameof(Index));
            }
            
            return View(role);
        }
        
        public IActionResult Remove(string name)
        {
            roleManager.DeleteAsync(roleManager.Roles.FirstOrDefault(x=>x.Name == name)).Wait();
            return RedirectToAction(nameof(Index));
        }
    }
}
