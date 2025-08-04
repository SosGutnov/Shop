using Shop.Models;

namespace Shop
{
    public class RolesInMemoryRepository : IRolesRepository
    {
        private List<Role> roles = new List<Role>();

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

        public void RemoveRole(string name)
        {
            roles.RemoveAll(x => x.Name == name);
        }
    }
}
