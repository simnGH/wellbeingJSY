namespace wellbeing.Models.UI.Page.Authentication
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Http;

    public class RegisterPageModel : BasePageModel
    {
        [Required(ErrorMessage = "Email Address is required.")]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [Display(Name = "Password")]
        [MinLength(8, ErrorMessage = "Passwords must be at least 8 characters; including one number (0-9), one lowercase letter (a-z), one uppercase letter (A-Z) and one special character (#?!@$%^&*)..")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Passwords must be at least 8 characters; including one number (0-9), one lowercase letter (a-z), one uppercase letter (A-Z) and one special character (#?!@$%^&*).")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm your password.")]
        [Display(Name = "Confirm Password")]
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }

        public string ReturnUrl { get; set; }
    }
}
