namespace wellbeing.Components.API.ErrorCodes
{
    using System.Collections.Generic;

    public sealed class UserErrors : Dictionary<int, string>
    {
        public static readonly int EmailAddressIsRequired = BaseValue + 1;
        public static readonly int PasswordIsRequired = BaseValue + 2;
        public static readonly int UserAlreadyExists = BaseValue + 3;
        public static readonly int UserIdIsRequired = BaseValue + 4;
        public static readonly int UserIdIsNotValid = BaseValue + 5;
        public static readonly int UserDoesNotExist = BaseValue + 6;
        public static readonly int AccountIdIsRequired = BaseValue + 7;
        public static readonly int AccountIdIsNotValid = BaseValue + 8;
        public static readonly int AccountIsNotAvailable = BaseValue + 9;
        public static readonly int PasswordsMustMatch = BaseValue + 10;
        public static readonly int TokenIsRequired = BaseValue + 11;
        public static readonly int TokenIsInvalid = BaseValue + 12;
        public static readonly int TokenIsExpired = BaseValue + 13;
        public static readonly int PasswordCantBeSameAsOld = BaseValue + 14;
        public static readonly int PasswordDoesNotMinimumCharacterLength = BaseValue + 15;

        private static readonly int BaseValue = ErrorBuilder.BaseValues[typeof(UserErrors)];

        private static UserErrors _instance = new UserErrors
        {
            { EmailAddressIsRequired, "EmailAddress is required." },
            { PasswordIsRequired, "Password is required." },
            { UserAlreadyExists, "User already exists - {0}." },
            { UserIdIsRequired, "UserId is required." },
            { UserIdIsNotValid, "UserId is not valid - {0}." },
            { UserDoesNotExist, "User does not exist - {0}." },
            { AccountIdIsRequired, "AccountId is required." },
            { AccountIdIsNotValid, "AccountId is not valid - {0}." },
            { AccountIsNotAvailable, "Account is not available to this user - {0}." },
            { PasswordsMustMatch, "Passwords must match - {0}" },
            { TokenIsRequired, "Token is required." },
            { TokenIsInvalid, "Token is invalid." },
            { TokenIsExpired, "Token has expired." },
            { PasswordCantBeSameAsOld, "Your new password can't be the same as your old one." },
            { PasswordDoesNotMinimumCharacterLength, "Your password must be at least 8 characters long." },
        };

        public static UserErrors Instance => _instance;
    }
}
