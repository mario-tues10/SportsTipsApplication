namespace DataManagement.Entities
{
    public class Admin : User
    {
        public Admin(string username, string email, string password, UserRole userRole) : base(username, email, password, userRole) {}
    }
}
