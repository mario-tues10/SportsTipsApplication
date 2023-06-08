using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BetExpertWeb.Models;
using Domain.Entities;
using Domain.Logic;
using DataManagement;
namespace BetExpertWeb.Pages
{
    public class RegistrationModel : PageModel
    {
        [BindProperty]
        public RegisterViewModel Register { get; set; }
        private AuthenticationHandler authenticationHandler;
        public RegistrationModel()
        {
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
                    if (Register.RegistrationType.Equals("Client"))
                    {
                        authenticationHandler = new AuthenticationHandler(new UserRepository());
                        authenticationHandler.Register(Register.Username, Register.Email,
                            Register.Password, UserRole.Client);
                    }
                    if (Register.RegistrationType.Equals("Tipster")) 
                    {
                        authenticationHandler = new AuthenticationHandler(new TipsterRepository());
                        authenticationHandler.Register(Register.Username, Register.Email,
                            Register.Password, UserRole.Tipster);
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
