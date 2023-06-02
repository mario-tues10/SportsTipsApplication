using System.ComponentModel.DataAnnotations;
namespace BetExpertWeb.Models
{
    public class ProfileViewModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string? OldPassword { get; set; }
        public string? NewPassword { get; set; }
        public string Role { get; set; }
        public decimal? SuccessRate { get; set; }
        public ProfileViewModel() { }
        public ProfileViewModel(string username, string email, string role, decimal? successRate)
        {
            Username = username;
            Email = email;
            Role = role;
            SuccessRate = successRate;
        }   
    }
}
