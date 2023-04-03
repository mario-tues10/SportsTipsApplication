using Entites;
using DataManagement;
namespace Domain
{
    public class LogHandler
    {
        public  List<Admin> Admins { get; private set; }
        public LogHandler()
        {
            try
            {
                Admins = new List<Admin>(GetData.AllAdmins());
            }
            catch(ArgumentNullException) 
            { 
                Admins = new List<Admin>();
            }
        }
        public void Register(string username, string email, string password)
        {
            if (IsPresentUser(username, password))
            {
                throw new Exception("There is already an admin with that credentials!");
            }
            else
            {
                Admin admin = new Admin(username, email, password);
                InsertService.InsertIntoAdmin(admin);
            }
        }
        private bool IsPresentUser(string username, string password)
        {
            foreach (User admin in Admins)
            {
                if (admin.Username == username && admin.Password == password)
                {
                    return true;
                }
            }
            return false;
        }
        public bool Login(string username, string password)
        {
            return IsPresentUser(username, password);
        }

    }
}
