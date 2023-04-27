using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BetExpertWeb.Models;
using Domain;
using Entites;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
namespace BetExpertWeb.Pages
{
    public class LoginModel : PageModel
    {
        private const string RememberMeCookieName = "Data";

        [BindProperty]
        public LoginViewModel Login { get; set; }
        private LogHandler LogHandler;

        public LoginModel()
        {
            LogHandler = new LogHandler();
        }
        public void OnGet()
        {
            if (Request.Cookies.ContainsKey(RememberMeCookieName))
            {
                Login.RememberMe = true;
                RedirectToPage("Competitions");
            }
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Login.RememberMe)
                {
                    CookieOptions cookieOptions = new CookieOptions();
                    cookieOptions.Expires = DateTime.Now.AddDays(4);
                    Response.Cookies.Append(RememberMeCookieName, Login.Username, cookieOptions);
                }
                else
                {
                    if (Request.Cookies.ContainsKey(RememberMeCookieName))
                    {
                        Response.Cookies.Delete(RememberMeCookieName);
                    }
                }
                try 
                {
                    LogHandler LogHandler = new LogHandler();
                    User? LoggedIn = LogHandler.Login(Login.Username, Login.Email, Login.Password);
                    if (LoggedIn != null)
                    {
                        List<Claim> claims = new List<Claim>
                        {
                            new Claim("id", LoggedIn.GetId().ToString(), ClaimValueTypes.Integer32),
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
