using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BetExpertWeb.Models;
using Domain;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace BetExpertWeb.Pages
{
    public class LoginModel : PageModel
    {
        private const string RememberMeCookieName = "Data";

        [BindProperty]
        public LoginViewModel Login { get; set; }
        public void OnGet()
        {
            #region retrieve info from cookie
            if (Request.Cookies.ContainsKey(RememberMeCookieName))
            {
                Login = new LoginViewModel();
                Login.Username = Request.Cookies[RememberMeCookieName];
                Login.RememberMe = true;
            }
            #endregion
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                #region handle info for user
                if (Login.RememberMe)
                {
                    CookieOptions cookieOptions = new CookieOptions();
                    cookieOptions.Expires = DateTime.Now.AddDays(4);
                    Response.Cookies.Append(RememberMeCookieName, Login.Email, cookieOptions);
                }
                else
                {
                    if (Request.Cookies.ContainsKey(RememberMeCookieName))
                    {
                        Response.Cookies.Delete(RememberMeCookieName);
                    }
                }
                #endregion

                LogHandler logHandler = new LogHandler();
                try 
                {
                    
                    if(logHandler.Login(Login.Username, Login.Email, Login.Password))
                    {
                        List<Claim> claims = new List<Claim>();
                        claims.Add(new Claim(ClaimTypes.Name, Login.Username));
                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));

                        return new RedirectToPageResult("Competitions");
                    }
                    else
                    {
                        ViewData["ErrorMessage"] = "Unable to login.";
                        return Page();
                    }

                }catch(Exception)
                {
                    ViewData["ErrorMessage"] = "Exception occured.";
                    return Page();
                }

            }
            return Page();
        }

    }
}
