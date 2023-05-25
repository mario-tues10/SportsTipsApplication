using DataManagement.Interfaces;
using DataManagement.Entities;
namespace Domain
{
    public class AuthenticationHandler
    {
        private readonly IAccountRepository accountRepository;
        public AuthenticationHandler(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        private User? IsPresentAccount(string username, string email, string password)
        {
            try
            {
                foreach (User user in accountRepository.GetAllAccounts())
                {
                    if (user.Username == username && user.Email == email && BCrypt.Net.BCrypt.Verify(password, user.Password))
                    {
                        return user;
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }
        public void Register(string username, string email, string password, UserRole role)
        {
            if (IsPresentAccount(username, email, password) != null)
            {
                throw new Exception("There is already an account with that credentials!");
            }
            else
            {
                switch (role)
                {
                    case UserRole.Client:
                        string clientHash = BCrypt.Net.BCrypt.HashPassword(password);
                        User user = new User(username, email, clientHash, UserRole.Client);
                        accountRepository.InsertIntoAccount(user);
                        break;

                    case UserRole.Tipster:
                        string tipsterHash = BCrypt.Net.BCrypt.HashPassword(password);
                        Tipster tipster = new Tipster(username, email, tipsterHash, UserRole.Tipster);
                        accountRepository.InsertIntoAccount(tipster);
                        break;
                    case UserRole.Admin:
                        string adminHash = BCrypt.Net.BCrypt.HashPassword(password);
                        Admin admin = new Admin(username, email, adminHash, UserRole.Admin);
                        accountRepository.InsertIntoAccount(admin);
                        break;

                    default: throw new Exception("Error in registering data!");
                }
            }
        }
        public User? Authenticate(string username, string email, string password)
        {
            return IsPresentAccount(username, email, password);
        }

    }
}

