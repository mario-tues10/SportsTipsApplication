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
        public void Register(string username, string email, string password, string role, string? specialty)
        {
            if (IsPresentUser(username, email, password))
            {
                throw new Exception("There is already an user with that credentials!");
            }
            else
            {
                switch (role)
                {
                    case "user":
                        {
                            User user = new User(username, email, password);
                            InsertService.InsertIntoUser(user);
                            break;
                        }
                    case "tipster":
                        {
                            Tipster tipster = new Tipster(username, email, password, Enum.Parse<Sport>(specialty));
                            InsertService.InsertIntoTipster(tipster);
                            break;
                        }
                    case "admin":
                        {
                            Admin admin = new Admin(username, email, password);
                            InsertService.InsertIntoAdmin(admin);
                            break;
                        }
                    default: break;
                }

            }
        }
        private bool IsPresentUser(string username, string email, string password)
        {
            foreach (User user in Users)
            {
                if (user.Username == username && user.Email == email && user.Password == password)
                {
                    return true;
                }
            }
            return false;
        }
        public bool Login(string username, string email, string password)
        {
            return IsPresentUser(username, email, password);
        }

    }
}
