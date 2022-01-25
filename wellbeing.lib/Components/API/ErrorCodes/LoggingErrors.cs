namespace wellbeing.Components.API.ErrorCodes
{
    using System.Collections.Generic;

    public sealed class LoggingErrors : Dictionary<int, string>
    {
        public static readonly int ComponentIsRequired = BaseValue + 1;
        public static readonly int MethodIsRequired = BaseValue + 2;
        public static readonly int DetailIsRequired = BaseValue + 3;
        public static readonly int SeverityIsRequired = BaseValue + 4;
        public static readonly int SeverityMustBeAnInt = BaseValue + 5;
        public static readonly int SeverityMustBeBetween1And100 = BaseValue + 6;

        private static readonly int BaseValue = ErrorBuilder.BaseValues[typeof(LoggingErrors)];

        private static LoggingErrors _instance = new LoggingErrors
        {
            { ComponentIsRequired, "Component is required." },
            { MethodIsRequired, "Method is required." },
            { DetailIsRequired, "Detail is required." },
            { SeverityIsRequired, "Severity is required." },
            { SeverityMustBeAnInt, "Severity must be an int - {0}." },
            { SeverityMustBeBetween1And100, "Severity must be between 1 and 100 - {0}." }
        };

        public static LoggingErrors Instance => _instance;
    }
}
