namespace wellbeing.Components.API.ErrorCodes
{
    using System.Collections.Generic;

    public sealed class AccountErrors : Dictionary<int, string>
    {
        public static readonly int AccountIdIsRequired = BaseValue + 1;
        public static readonly int AccountIdIsNotValid = BaseValue + 2;
        public static readonly int AccountDoesNotExist = BaseValue + 3;
        public static readonly int BusinessNameIsRequired = BaseValue + 4;
        public static readonly int AddressLine1IsRequired = BaseValue + 5;
        public static readonly int PostCodeIsRequired = BaseValue + 6;
        public static readonly int CountryIsRequired = BaseValue + 7;

        private static readonly int BaseValue = ErrorBuilder.BaseValues[typeof(AccountErrors)];

        private static AccountErrors _instance = new AccountErrors
        {
            { AccountIdIsRequired, "AccountId is required." },
            { AccountIdIsNotValid, "AccountId is not valid - {0}." },
            { AccountDoesNotExist, "Account does not exist - {0}." },
            { BusinessNameIsRequired, "Business Name is required." },
            { AddressLine1IsRequired, "Address Line 1 is required." },
            { PostCodeIsRequired, "Post Code is required." },
            { CountryIsRequired, "Country is required." },
        };

        public static AccountErrors Instance => _instance;
    }
}
