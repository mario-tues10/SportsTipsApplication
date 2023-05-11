using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BetExpertWeb.Models;
using Domain;
using DataManagement;
using DataManagement.Entities;
namespace BetExpertWeb.Pages
{
    public class RegistrationModel : PageModel
    {
        [BindProperty]
        public RegisterViewModel Register { get; set; }
        private AuthenticationHandler registerHandler { get; set; }
        public RegistrationModel()
        {
            registerHandler = new AuthenticationHandler();
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
                        registerHandler.Register(Register.Username, Register.Email, Register.Password, 
                            UserRole.Client, null, new UserRepository(new SqlService()));
                    }
                    else
                    {
                        registerHandler.Register(Register.Username, Register.Email, Register.Password, 
                            UserRole.Tipster, Register.TipsterSpecialty, new TipsterRepository(new SqlService()));
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
