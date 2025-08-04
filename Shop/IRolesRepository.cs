using Shop.Models;

namespace Shop
{
    public interface IRolesRepository
    {
        void Add(Role role);
        List<Role> GetAll();
        Role TryGetById(string name);
        public void RemoveRole(string name);
    }
}