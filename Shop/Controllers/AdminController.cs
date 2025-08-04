using Microsoft.AspNetCore.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    public class AdminController : Controller
    {
        private IProductsRepository productsRepository;
        private IOrdersRepository ordersRepository;
        private IRolesRepository rolesRepository;

        public AdminController(IProductsRepository productsRepository, IOrdersRepository ordersRepository, IRolesRepository rolesRepository)
        {
            this.productsRepository = productsRepository;
            this.ordersRepository = ordersRepository;
            this.rolesRepository = rolesRepository;
        }

        public IActionResult Orders()
        {
            var orders = ordersRepository.GetAll();
            return View(orders);
        }

        public IActionResult OrderDetails(int orderId)
        {
            var order = ordersRepository.TryGetById(orderId);
            return View(order);
        }
        public IActionResult UpdateOrderStatus(int orderId, OrderStatus status)
        {
            ordersRepository.UpdateStatus(orderId, status);
            return RedirectToAction("Orders");
        }

        public IActionResult Products()
        {
            var products = productsRepository.GetAll();
            return View(products);
        }
        public IActionResult Roles()
        {
            var roles = rolesRepository.GetAll();
            return View(roles);
        }
        public IActionResult AddRole()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult AddRole(Role role)
        {
            if (rolesRepository.TryGetById(role.Name) != null)
            {
                ModelState.AddModelError("", "Такая роль уже существует");
            }
            if (ModelState.IsValid)
            {
                rolesRepository.Add(role);
                return RedirectToAction("Roles");
            }
            
            return View(role);
        }
        
        public IActionResult RemoveRole(string roleName)
        {
            rolesRepository.RemoveRole(roleName);
            return RedirectToAction("Roles");
        }

        public IActionResult Users()
        {
            return View();
        }
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            product.ImagePath = "/images/jinx.png";
            productsRepository.AddProduct(product);
            return RedirectToAction("Products");
        }

        public IActionResult DeleteProduct(int id)
        {
            productsRepository.DeleteProduct(id);
            return RedirectToAction("Products");
        }

        public IActionResult EditProduct(int id)
        {
            return View(productsRepository.TryGetByid(id));
        }

        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            productsRepository.Update(product);
            return RedirectToAction("Products");
        }
    }
}
