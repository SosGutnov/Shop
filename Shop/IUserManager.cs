using Shop.Models;

namespace Shop
{
    public interface IUserManager
    {
        void Add(UserAccount user);
        void Delete(UserAccount user);
        List<UserAccount> GetAll();
        UserAccount TryGetByName(string name);
        void Update(UserAccount user);
    }
}