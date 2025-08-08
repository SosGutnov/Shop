using Shop.Areas.Admin.Models;
using Shop.Models;

namespace Shop
{
    public interface IUserManager
    {
        void Add(UserAccount user);
        void ChangePassword(int userId, string newPassword);
        void Delete(UserAccount user);
        void EditRights(int userId, Role role);
        List<UserAccount> GetAll();
        UserAccount TryGetById(int id);
        UserAccount TryGetByName(string name);
        void Update(UserAccount user);
    }
}