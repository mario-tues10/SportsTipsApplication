using System.ComponentModel.DataAnnotations;

namespace Entites
{
    public class User
    {
        private int Id; 
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public User(string username, string email, string password)
        {
            Username = username;
            Email = email;
            Password = password;
        }
        public int GetId()
        {
            return Id;
        }
        public void SetId(int id)
        {
            Id = id;
        }

    }
}
