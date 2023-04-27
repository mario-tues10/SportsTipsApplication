using Entites;
using DataManagement;
namespace Domain
{
    public class LogHandler
    {
        public List<User> Users { get; private set; }
        public LogHandler()
        {
            try
            {
                Users = new List<User>(GetData.AllUsers());
            }
            catch (ArgumentNullException)
            {
                Users = new List<User>();
            }
        }
        public void Register(string username, string email, string password, UserRole userRole, string? specialty)
        {
            if (IsPresentUser(username, email, password) != null)
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
                            InsertService.InsertIntoUser(user);
                            break;
                        }
                    case UserRole.Tipster:
                        {
                            Tipster tipster = new Tipster(username, email, password, userRole, Enum.Parse<Sport>(specialty));
                            InsertService.InsertIntoTipster(tipster);
                            break;
                        }
                    case UserRole.Admin:
                        {
                            Admin admin = new Admin(username, email, password, userRole);
                            InsertService.InsertIntoAdmin(admin);
                            break;
                        }
                    default: throw new Exception("An error occurred in inserting!");
                   
                }

            }
        }
        private User? IsPresentUser(string username, string email, string password)
        {
            foreach (User user in Users)
            {
                if (user.Username == username && user.Email == email && user.Password == password)
                {
                    return user;
                }
            }
            return null;
        }
        public User? Login(string username, string email, string password)
        {
            return IsPresentUser(username, email, password);
        }

    }
}
