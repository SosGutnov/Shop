using Microsoft.AspNetCore.Identity;
using Shop.Areas.Admin.Models;

namespace Shop
{
    public class RolesInMemoryRepository : IRolesRepository
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public void Add(IdentityRole role)
        {
            roleManager.CreateAsync(role);
        }

        public List<IdentityRole> GetAll()
        {
            return roleManager.Roles.ToList();
        }

        public IdentityRole TryGetById(string name)
        {
            return roleManager.Roles.FirstOrDefault(x => x.Name == name);
        }

        public void Remove(string name)
        {
            roleManager.DeleteAsync(TryGetById(name));
        }
    }
}
