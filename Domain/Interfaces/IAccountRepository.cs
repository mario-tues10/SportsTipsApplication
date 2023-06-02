using Domain.Entities;
namespace Domain.Interfaces
{
    public interface IAccountRepository
    {
        void InsertIntoAccount(User user);
        void ChangePassword(User user, string newPassword);
        void DeleteIntoAccount(User user);
        User? GetAccountById(int id);
        List<User>? GetAllAccounts();
        
    }
}
