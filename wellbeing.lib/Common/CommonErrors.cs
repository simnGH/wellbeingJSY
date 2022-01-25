namespace wellbeing
{
    using System.Collections.Generic;

    public sealed class CommonErrors : Dictionary<int, string>
    {
        public const string UnexpectedExceptionFriendlyMessage = "Oops! Something has gone wrong!";
        public const string AuthenticationTokenHasExpiredMessage = "Your session has expired. Please log in again";

        public const int MissingRequestModel = 100;
        public const int LogComponentIsRequired = 101;
        public const int LogMethodIsRequired = 102;
        public const int LogSeverityMustBeOneOrGreaterIfSpecified = 103;
        public const int LogAccountIdMustBeOneOrGreaterIfSpecified = 104;
        public const int JSONIsRequired = 105;
        public const int UnexpectedException = 199;

        private static CommonErrors _instance = new CommonErrors
        {
            { MissingRequestModel, "Missing request model - {0}." },
            { UnexpectedException, "Unexpected Exception - {0}." },
            { LogComponentIsRequired, "Log Component is required." },
            { LogMethodIsRequired, "Log Method is required." },
            { LogSeverityMustBeOneOrGreaterIfSpecified, "Log Severity must be 1 or greater if specified - {0}." },
            { LogAccountIdMustBeOneOrGreaterIfSpecified, "Log AccountId must be 1 or greater if specified - {0}." },
            { JSONIsRequired, "JSON is required." },
        };

        public static CommonErrors Instance => _instance;
    }
}
