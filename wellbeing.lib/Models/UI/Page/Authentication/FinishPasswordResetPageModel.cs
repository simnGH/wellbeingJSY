namespace wellbeing.Models.UI.Page.Authentication
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Http;

    public class FinishPasswordResetPageModel : BasePageModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        [MinLength(8, ErrorMessage = "Passwords must be at least 8 characters; including one number (0-9), one lowercase letter (a-z), one uppercase letter (A-Z) and one special character (#?!@$%^&*)..")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{12,}$", ErrorMessage = "Passwords must be at least 8 characters; including one number (0-9), one lowercase letter (a-z), one uppercase letter (A-Z) and one special character (#?!@$%^&*).")]

        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Token { get; set; }

        public bool ResetFinished { get; set; }
    }
}
