namespace wellbeing.Mappers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using wellbeing.Components.API.Users;
    using wellbeing.Models.UI.View.Users;

    public class UsersMapper
    {
        public static UserViewModel MapUserToUserViewModel(User user)
        {
            return new UserViewModel
            {
                UserId = Convert.ToInt32(user.UserId),
                EmailAddress = user.EmailAddress,
                PasswordResetToken = user.PasswordResetToken,
                PasswordResetTokenExpiry = Convert.ToDateTime(user.PasswordResetTokenExpiry),
                IsAuthenticated = Convert.ToBoolean(user.IsAuthenticated),
                IsEmailValidated = Convert.ToBoolean(user.IsEmailValidated)
            };
        }
    }
}
