namespace wellbeing.Components.API.Authentication
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    public static class PasswordManager
    {
        private const int SALT_BYTES = 32;
        private const int SALT_CHARS = 43;

        public static bool ComparePasswordHash(string saltedHash, string password)
        {
            // 1. get salt from hashed value
            if (saltedHash.Length < SALT_CHARS + 1)
            {
                throw new ArgumentException("Value must be longer than SALT_LENGTH", nameof(saltedHash));
            }

            string salt = saltedHash.Substring(saltedHash.Length - SALT_CHARS - 1);

            // 2. hash + salt password
            string saltedHashedPassword = PasswordManager.GenerateSaltedHash(password, salt);

            // 3. compare
            return saltedHash == saltedHashedPassword;
        }

        public static string GenerateSaltedHash(string password, string salt)
        {
            byte[] sourceBytes = Encoding.UTF8.GetBytes(password);

            HashAlgorithm algorithm = new SHA256Managed();
            byte[] output = algorithm.ComputeHash(sourceBytes);

            string outputHex = BitConverter.ToString(output).Replace("-", string.Empty).ToLower();

            return string.Concat(Convert.ToBase64String(Encoding.UTF8.GetBytes(outputHex)), salt);
        }

        public static string GenerateSaltValue()
        {
            byte[] salt = new byte[SALT_BYTES];

            // Generate a cryptographic random number.
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(salt);

            // Return a Base64 string representation of the random number.
            return Convert.ToBase64String(salt);
        }
    }
}
