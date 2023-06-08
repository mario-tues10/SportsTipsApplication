using Domain.Entities;
using Domain.Interfaces;
namespace ApplicationTest.Mocks
{
    public class MockUserRepository : IAccountRepository
    {
        public List<User> Accounts { get; private set; }
        public MockUserRepository(List<User> users)
        {
            Accounts = users;
        }
        public void InsertIntoAccount(User user)
        {
            Accounts.Add(user);
        }
        public void DeleteIntoAccount(User user)
        {
            Accounts.Remove(user);
        }
        public void ChangePassword(User user, string newPassword)
        {
            user.SetPassword(newPassword);
        }
        public User? GetAccountById(int id)
        {
            foreach(User user in Accounts)
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
            return Accounts;
        }
    }
}
