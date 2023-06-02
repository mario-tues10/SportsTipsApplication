using Domain.Entities;

namespace Domain.DVOs
{
    public class ProfileDVO
    {
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string? OldPassword { get; private set; }
        public string? NewPassword { get; private set; }
        public string Role { get; private set; }
        public decimal? SuccessRate { get; private set; }
        public ProfileDVO(string username, string email, string userRole, decimal? successRate)
        {
            Username = username;
            Email = email;
            Role = userRole;
            SuccessRate = successRate;
        }
    }
}
