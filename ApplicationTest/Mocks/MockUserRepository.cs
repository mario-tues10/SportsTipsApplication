using Domain.Entities;
using Domain.Interfaces;
namespace ApplicationTest.Mocks
{
    public class MockUserRepository : IAccountRepository
    {
        public List<User> Users { get; private set; }
        public MockUserRepository(List<User> users)
        {
            Users = users;
        }
        public void InsertIntoAccount(User user)
        {
            Users.Add(user);
        }
        public void DeleteIntoAccount(User user)
        {
            Users.Remove(user);
        }
        public void ChangePassword(User user, string newPassword)
        {
            user.SetPassword(newPassword);
        }
        public User GetAccountById(int id)
        {
            foreach(User user in Users)
            {
                if(user.GetId() == id)
                {
                    return user;
                }
            }
            return null;
        }
        public List<User> GetAllAccounts()
        {
            return Users;
        }
    }
}
