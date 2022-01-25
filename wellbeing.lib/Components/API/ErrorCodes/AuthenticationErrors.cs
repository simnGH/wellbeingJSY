namespace wellbeing.Components.API.ErrorCodes
{
    using System.Collections.Generic;

    public sealed class AuthenticationErrors : Dictionary<int, string>
    {
        public static readonly int TokenIsRequired = BaseValue + 1;
        public static readonly int TokenIsInvalid = BaseValue + 2;
        public static readonly int TokenIsExpired = BaseValue + 3;
        public static readonly int IPAddressIsRequired = BaseValue + 4;
        public static readonly int PasswordIsRequired = BaseValue + 5;
        public static readonly int AccountIdIsRequired = BaseValue + 6;
        public static readonly int AccountIdIsNotValid = BaseValue + 7;
        public static readonly int AccountDoesNotExist = BaseValue + 8;
        public static readonly int AccountIsNotBeingEnrolled = BaseValue + 9;
        public static readonly int UsernameIsRequired = BaseValue + 10;
        public static readonly int AuthenticationFailed = BaseValue + 11;

        private static readonly int BaseValue = ErrorBuilder.BaseValues[typeof(AuthenticationErrors)];

        private static AuthenticationErrors _instance = new AuthenticationErrors
        {
            { TokenIsRequired, "Token is required." },
            { TokenIsInvalid, "Token is invalid." },
            { TokenIsExpired, "Token has expired." },
            { IPAddressIsRequired, "IP Address is required." },
            { PasswordIsRequired, "Password is required." },
            { AccountIdIsRequired, "AccountId is required." },
            { AccountIdIsNotValid, "AccountId is not valid - {0}." },
            { AccountDoesNotExist, "Account does not exist - {0}." },
            { AccountIsNotBeingEnrolled, "Account is not being enrolled - {0}." },
            { UsernameIsRequired, "Username is required." },
            { AuthenticationFailed, "Authentication Failed" },
        };

        public static AuthenticationErrors Instance => _instance;
    }
}
