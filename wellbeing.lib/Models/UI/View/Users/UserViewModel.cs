namespace wellbeing.Models.UI.View.Users
{
    using System;

    public class UserViewModel
    {
        public int UserId { get; set; }

        public string EmailAddress { get; set; }        
        
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public bool IsAuthenticated { get; set; }

        public bool IsEmailValidated { get; set; }

        public string PasswordResetToken  {get; set; }

        public DateTime PasswordResetTokenExpiry { get; set; }
    }
}
