using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BetExpertWeb.Models;
using Domain;
namespace BetExpertWeb.Pages
{
    public class RegistrationModel : PageModel
    {
        [BindProperty]
        public RegisterViewModel Register { get; set; }
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    LogHandler logHandler = new LogHandler();
                    if (Register.isTipster)
                    {
                        logHandler.Register(Register.Username, Register.Email, Register.Password, "tipster", "football");
                    }
                    else
                    {
                        logHandler.Register(Register.Username, Register.Email, Register.Password, "user", null);
                    }
                }
                catch (Exception ex)
                {
                    ViewData["Error message"] = ex.Message;
                    return Page();
                }
                return RedirectToPage("Login");
            }
            else
            {
                return Page();
            }
        }
            
    }

}
