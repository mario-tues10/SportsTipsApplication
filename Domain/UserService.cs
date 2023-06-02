using Domain.Entities;
using Domain.Interfaces;
namespace Domain
{
    public class UserService
    {
        private readonly IAccountRepository userRepository;
        public UserService(IAccountRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public User? GetMyselfById(int id)
        {
            return userRepository.GetAccountById(id);
        }
        public List<User>? GetUsers()
        {
            return userRepository.GetAllAccounts();
        }
        public void ChangePassword(User user, string oldPassword, string newPassword)
        {
            if (BCrypt.Net.BCrypt.Verify(oldPassword, user.Password))
            {
                string hashedNewPassword = BCrypt.Net.BCrypt.HashPassword(newPassword);
                userRepository.ChangePassword(user, hashedNewPassword);
            }
            else
            {
                throw new Exception("Passwords don't match!");
            }
        }
        public void DeleteAccount(User user)
        {
            userRepository.DeleteIntoAccount(user);
        }
    }
}
