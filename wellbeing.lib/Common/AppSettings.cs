namespace wellbeing
{
    using System;

    public class AppSettings
    {
        public AppSettings()
        {
        }

        public static AppSettings Current { get; set; }

        public string SitePrefix { get; set; }

        public string APIUrl { get; set; }

        public string RedisConnectionString { get; set; }

        public string RedisKey { get; set; }

        public string JWTKey { get; set; }

        public string JWTIssuer { get; set; }
    }
}
