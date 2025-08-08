using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Shop.Areas.Admin.Models;
using Shop.Models;
using System.Xml.Linq;

namespace Shop
{
    public class UserManager : IUserManager
    {
        private readonly List<UserAccount> users = new List<UserAccount>()
        {
            new UserAccount() {Name = "admin", Phone="", Email = "", Password="admin", Role = new Role(){ Name = "admin"} }
        };

        public List<UserAccount> GetAll()
        {
            return users;
        }

        public UserAccount TryGetByName(string name)
        {
            return users.FirstOrDefault(x => x.Name == name);
        }

        public void Add(UserAccount user)
        {
            users.Add(user);
        }

        public void Update(UserAccount user)
        {
            var existingsUser = users.FirstOrDefault(x => x.Id == user.Id);
            if (existingsUser == null)
            {
                return;
            }
            existingsUser.Name = user.Name;
            existingsUser.Email = user.Email;
            existingsUser.Phone = user.Phone;

        }

        public void Delete(UserAccount user)
        {
            users.Remove(user);
        }

        public UserAccount TryGetById(int id)
        {
            return users.FirstOrDefault(x => x.Id == id);
        }

        public void ChangePassword(int userId, string newPassword)
        {
            var user = TryGetById(userId);
            if (user != null)
            {
                user.Password = newPassword;
            }
        }

        public void EditRights(int userId, Role role)
        {
            var user = TryGetById(userId);
            if (user != null)
            {
                user.Role = role;
            }
        }
    }
}
