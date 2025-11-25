using System.ComponentModel.DataAnnotations;

namespace AuthDemoTwo.Models
{
    public class RegisterModel
    {
        [Required]
        [EmailAddress(ErrorMessage ="Please enter a valid email address.")]
        public string Email {get;set;}
        [DataType(DataType.Password)]
        [StringLength(100,MinimumLength =8,ErrorMessage ="Password must be at least 8 character long.")]
        [Required(ErrorMessage ="Password is required.")]
        public string Password {get;set;}
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="The password and confirmation password do not match.")]
        public string ConfirmPassword {get;set;}
    }

    public class LoginModel
    {
        [Required]
        [EmailAddress(ErrorMessage ="Please enter a valid email address.")]
        public string Email {get;set;}

        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Password is required.")]
        public string Password {get;set;}
        public bool RememberMe {get;set;}
    }
}