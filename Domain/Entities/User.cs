namespace Domain.Entities
{
    public class User
    {
        private int Id; 
        public string Username { get; set; }
        public string Email { get;  set; }
        public string Password { get; set; }
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
        public 

    }
}
