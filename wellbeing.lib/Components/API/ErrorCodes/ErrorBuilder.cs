namespace wellbeing.Components.API.ErrorCodes
{
    using System;
    using System.Collections.Generic;

    public static class ErrorBuilder
    {
        public static readonly Dictionary<Type, int> BaseValues = new
            Dictionary<Type, int>()
            {
                { typeof(AuthenticationErrors), 100 },
                { typeof(UserErrors), 200 },
                { typeof(LoggingErrors), 300 },
                { typeof(AccountErrors), 400 }
            };

        public static string ExceptionDiagnosticString(Exception ex)
        {
            string outerException = ExceptionMessage(ex);
            string innerException = "null";

            if (ex.InnerException != null)
            {
                innerException = ExceptionMessage(ex.InnerException);
            }

            return $"Outer Exception: {outerException}, Inner Exception: {innerException}";
        }

        private static string ExceptionMessage(Exception ex)
        {
            return $"Message: {ex.Message}, Type: {ex.GetType().ToString()}, Stack Trace: {ex.StackTrace}";
        }
    }
}
