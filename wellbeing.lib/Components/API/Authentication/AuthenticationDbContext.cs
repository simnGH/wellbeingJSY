namespace wellbeing.Components.API.Authentication
{
    using System;

    public class AuthenticationDbContext
    {
        public AuthenticationDbContext()
        {
        }

        public static IAuthenticationDbContext Current { get; set; }
    }
}
