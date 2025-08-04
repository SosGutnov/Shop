using Microsoft.AspNetCore.Mvc;
using Shop.Areas.Admin.Models;

namespace Shop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private IRolesRepository rolesRepository;

        public RoleController(IRolesRepository rolesRepository)
        {
            this.rolesRepository = rolesRepository;
        }

        public IActionResult Index()
        {
            var roles = rolesRepository.GetAll();
            return View(roles);
        }
        public IActionResult Add()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Add(Role role)
        {
            if (rolesRepository.TryGetById(role.Name) != null)
            {
                ModelState.AddModelError("", "Такая роль уже существует");
            }
            if (ModelState.IsValid)
            {
                rolesRepository.Add(role);
                return RedirectToAction(nameof(Index));
            }
            
            return View(role);
        }
        
        public IActionResult Remove(string name)
        {
            rolesRepository.Remove(name);
            return RedirectToAction(nameof(Index));
        }
    }
}
