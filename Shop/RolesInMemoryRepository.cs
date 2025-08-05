using Shop.Areas.Admin.Models;

namespace Shop
{
    public class RolesInMemoryRepository : IRolesRepository
    {
        private List<Role> roles = new List<Role>()
        {
            new Role() {Name = "admin"},
            new Role() {Name = "user"}
        };

        public void Add(Role role)
        {
            roles.Add(role);
        }

        public List<Role> GetAll()
        {
            return roles;
        }

        public Role TryGetById(string name)
        {
            return roles.FirstOrDefault(x => x.Name == name);
        }

        public void Remove(string name)
        {
            roles.RemoveAll(x => x.Name == name);
        }
    }
}
