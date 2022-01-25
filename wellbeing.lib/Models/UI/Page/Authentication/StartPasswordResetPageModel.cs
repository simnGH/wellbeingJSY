namespace wellbeing.Models.UI.Page.Authentication
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Http;

    public class StartPasswordResetPageModel : BasePageModel
    {
        [Required(ErrorMessage = "Email Address is required.")]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
    }
}
