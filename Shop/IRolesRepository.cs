using Microsoft.AspNetCore.Identity;
using Shop.Areas.Admin.Models;

namespace Shop
{
    public interface IRolesRepository
    {
        void Add(IdentityRole role);
        List<IdentityRole> GetAll();
        IdentityRole TryGetById(string name);
        public void Remove(string name);
    }
}