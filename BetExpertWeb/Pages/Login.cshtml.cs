using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BetExpertWeb.Models;
using Domain;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using DataManagement.Entities;
using DataManagement;

namespace BetExpertWeb.Pages
{
    public class LoginModel : PageModel
    {
        private const string RememberMeCookieName = "Data";
        [BindProperty]
        public LoginViewModel Login { get; set; }
        private AuthenticationHandler logHandler;
        private WebViewHandler viewHandler;

        public LoginModel()
        {
            logHandler = new AuthenticationHandler();
            viewHandler = new WebViewHandler();
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
                    User? LoggedIn = logHandler.Login(Login.Username, Login.Email, 
                        Login.Password, new UserRepository(new SqlService()));
                    if() { }
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
