using DataManagement;
using Domain;
using Domain.DVOs;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BetExpertWeb.Pages
{
    public class ProfileModel : PageModel
    {
        public ProfileDVO? Profile { get; set; }
        private UserService userService { get; set; }
        private ViewMapper viewMapper { get; set; }
        public ProfileModel()
        {
            userService = new UserService(new UserRepository());
            viewMapper = new ViewMapper(new PredictionRepository(), new TipsterRepository(),
                new UserRepository());

        }
        public void OnGet()
        {
            Profile = viewMapper.MapProfile(Convert.ToInt32(User.FindFirst("id").Value), 
                User.FindFirst("role").Value);
        }
        public IActionResult OnPost()
        {
            try
            {
                User? profile = userService.GetMyselfById(Convert.ToInt32(User.FindFirst("id").Value));
                if (profile != null)
                {
                    userService.ChangePassword(profile, Profile.OldPassword, Profile.NewPassword);
                }
                else
                {
                    ViewData["ErrorMessage"] = "No profile!";
                    return Page();
                }
                return new RedirectToPageResult("PasswordChanged");
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return Page();
            }
        }

    }
}
