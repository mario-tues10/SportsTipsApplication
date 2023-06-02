namespace Domain.Entities
{
    public class User
    {
        private int Id; 
        public string Username { get; private set; }
        public string Email { get; private set; }
        private string Password;
        public UserRole UserRole { get; set; }
        public User(string username, string email, string password, UserRole userRole)
        {
            Username = username;
            Email = email;
            Password = password;
            UserRole = userRole;
        }
        public int GetId()
        {
            return Id;
        }
        public void SetId(int id)
        {
            Id = id;
        }
        public string GetPassword()
        {
            return Password;
        }
        public void SetPassword(string password)
        {
            Password = password;
        }

    }
}
