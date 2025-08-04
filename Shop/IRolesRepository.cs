using Shop.Areas.Admin.Models;

namespace Shop
{
    public interface IRolesRepository
    {
        void Add(Role role);
        List<Role> GetAll();
        Role TryGetById(string name);
        public void Remove(string name);
    }
}