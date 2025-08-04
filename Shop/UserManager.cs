using Shop.Models;

namespace Shop
{
    public class UserManager : IUserManager
    {
        private readonly List<UserAccount> users = new List<UserAccount>();

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
            return;
        }

        public void Delete(UserAccount user)
        {
            users.Remove(user);
        }
    }
}
