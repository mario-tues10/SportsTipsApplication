using DataManagement.Entities;
namespace DataManagement.Interfaces
{
    public interface IUserRepository
    {
        void InsertIntoAccount(User user);

        /*
         Method for changing password
        void ChangeUserPassword(User user);
         */
        void DeleteIntoAccount(User user);
        User? GetAccountById(int id);
        List<User>? GetAllAccounts();
        
    }
}
