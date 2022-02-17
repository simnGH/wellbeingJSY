namespace wellbeing.Models.UI.View.Users
{
    using System;

    public class UserViewModel
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public bool IsAuthenticated { get; set; }

        public bool IsEmailValidated { get; set; }

        public string PasswordResetToken { get; set; }

        public DateTime PasswordResetTokenExpiry { get; set; }

        public int BodyScore { get; set; }

        public int MindScore { get; set; }

        public int WealthScore { get; set; }
        
        public int WorkScore { get; set; }
    }    
}
