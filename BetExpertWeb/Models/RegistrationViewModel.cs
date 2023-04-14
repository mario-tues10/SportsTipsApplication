using System.ComponentModel.DataAnnotations;
namespace BetExpertWeb.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please enter your username.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter your e-mail address.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Pleasem enter password.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [Display(Name = "Confirm the password")]
        public string ConfirmPassword { get; set; }
        public bool isTipster { get; set; }
    }
}