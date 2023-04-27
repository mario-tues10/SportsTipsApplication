using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BetExpertWeb.Models;
using Domain;
using Entites;

namespace BetExpertWeb.Pages
{
    public class RegistrationModel : PageModel
    {
        [BindProperty]
        public RegisterViewModel Register { get; set; }
        private LogHandler LogHandler { get; set; }
        public RegistrationModel()
        {
            LogHandler = new LogHandler();
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (Register.TipsterSpecialty.Equals("User"))
                    { 
                        LogHandler.Register(Register.Username, Register.Email, Register.Password, UserRole.Client, null);
                    }
                    else
                    {
                        LogHandler.Register(Register.Username, Register.Email, Register.Password, UserRole.Tipster, Register.TipsterSpecialty);
                    }
                }
                catch (Exception ex)
                {
                    ViewData["Error message"] = ex.Message;
                    return Page();
                }
                return new RedirectToPageResult("Login");
            }
            else
            {
                return Page();
            }
        }
            
    }

}
