using DataManagement.Entities;
using DataManagement.Interfaces;
namespace Domain
{
    public class AuthenticationHandler
    {
        public void Register(string username, string email, string password, 
            UserRole userRole, string? specialty, IUserRepository userRepository)
        {
            if (IsPresentUser(username, email, password, userRepository) != null)
            {
                throw new Exception("There is already an user with that credentials!");
            }
            else
            {
                switch (userRole)
                {
                    case UserRole.Client:
                        {
                            User user = new User(username, email, password, userRole);
                            userRepository.InsertIntoAccount(user);
                            break;
                        }
                    case UserRole.Tipster:
                        {
                            Tipster tipster = new Tipster(username, email, password, userRole, Enum.Parse<Sport>(specialty));
                            userRepository.InsertIntoAccount(tipster);
                            break;
                        }
                    case UserRole.Admin:
                        {
                            Admin admin = new Admin(username, email, password, userRole);
                            userRepository.InsertIntoAccount(admin);
                            break;
                        }
                    default: throw new Exception("An error occurred in inserting!");

                }
            }
        }
        
        private User? IsPresentUser(string username, string email, string password, IUserRepository userRepository)
        {
            try
            {
                foreach (User user in userRepository.GetAllAccounts())
                {
                    if (user.Username == username && user.Email == email && user.Password == password)
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
        public User? Login(string username, string email, string password, IUserRepository userRepository)
        {
            return IsPresentUser(username, email, password, userRepository);
        }
    }
}
