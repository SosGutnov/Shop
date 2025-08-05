using Shop.Models;

namespace Shop
{
    public interface IUserManager
    {
        void Add(UserAccount user);
        void ChangePassword(int userId, string newPassword);
        void Delete(UserAccount user);
        List<UserAccount> GetAll();
        UserAccount TryGetById(int id);
        UserAccount TryGetByName(string name);
        void Update(UserAccount user);
    }
}