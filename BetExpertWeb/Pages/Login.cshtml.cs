using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BetExpertWeb.Models;
using Domain;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using DataManagement;
using DataManagement.Entities;
namespace BetExpertWeb.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public LoginViewModel Login { get; set; }
        private AuthenticationHandler logHandler;
        public LoginModel()
        {
            logHandler = new AuthenticationHandler(new UserRepository());
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
                    User? LoggedIn = logHandler.Authenticate(Login.Username, Login.Email, Login.Password);
                    if (LoggedIn != null)
                    {
                        List<Claim> claims = new List<Claim>
                        {
                            new Claim("id", LoggedIn.GetId().ToString()),
                            new Claim(ClaimTypes.Role, LoggedIn.UserRole.ToString())
                        };
                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));
                        return new RedirectToPageResult("Competitions");
                    }
                    else
                    {
                        ViewData["ErrorMessage"] = "Unable to login!";
                    }

                }catch(Exception ex)
                {
                    ViewData["ErrorMessage"] = ex.Message;
                }
            }
            return Page();
        }

    }
}
