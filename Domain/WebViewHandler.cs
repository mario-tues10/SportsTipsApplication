using DataManagement.Entities;
using DataManagement.Interfaces;
namespace Domain
{
    public class WebViewHandler
    {
        public bool RoleDetermine(User user, IUserRepository userRepository)
        {
            return userRepository.GetAllAccounts().Any();
        }
    }
}
