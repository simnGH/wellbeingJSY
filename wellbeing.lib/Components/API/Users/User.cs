namespace wellbeing.Components.API.Users
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.IdentityModel.Tokens;
    using wellbeing;
    using wellbeing.Components.API.Authentication;

    public class User
    {
        private const string COMPONENT = "User";

        public User()
        {
            this.IsAuthenticated = false;
        }

        public int UserId  { get; set; }

        public string EmailAddress { get; set; }

        public string PasswordHash { get; set; }

        public string PasswordResetToken { get; set; }

        public DateTime PasswordResetTokenExpiry { get; set; }

        public DateTime? EmailValidatedAt  { get; set; }

        public bool IsAuthenticated  { get; set; }

        public bool IsEmailValidated => EmailValidatedAt != null;

        public string SecurityToken  { get; set; }

        public DateTime SecurityTokenExpiry  { get; set; }

        public int BodyScore { get; set; }

        public int MindScore { get; set; }

        public int WealthScore { get; set; }
        
        public int WorkScore { get; set; }

        public static User FromDataRow(DataRow userData)
        {
            return new User
            {
                UserId = Convert.ToInt32(userData["UserId"]),
                IsAuthenticated = true,
                PasswordHash = Convert.ToString(userData["PasswordHash"]),
                EmailAddress = Convert.ToString(userData["EmailAddress"]),
                PasswordResetToken = Convert.ToString(userData["PasswordResetToken"]),
                PasswordResetTokenExpiry = userData["PasswordResetTokenExpiry"] == DBNull.Value ? DateTime.Now.AddDays(-1) : Convert.ToDateTime(userData["PasswordResetTokenExpiry"]),
                EmailValidatedAt = userData["EmailValidatedAt"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(userData["EmailValidatedAt"]),

                // SecurityToken = Convert.ToString(userData["PasswordResetToken"]),
                // SecurityTokenExpiry = userData["PasswordResetTokenExpiry"] == DBNull.Value ? DateTime.Now.AddDays(-1) : Convert.ToDateTime(userData["PasswordResetTokenExpiry"])
            };
        }

        public static List<User> FromDataTable(DataTable userData)
        {
            List<User> users = new List<User>();

            foreach (DataRow r in userData.Rows)
            {
                users.Add(FromDataRow(r));
            }

            return users;
        }

        public static async Task<User> Authenticate(string emailAddress, string password)
        {
            User user = null;

            DataRow data = await UsersDbContext.Current.GetUser(emailAddress);

            if (data!= null)
            {
                user = User.FromDataRow(data);
                user.IsAuthenticated = PasswordManager.ComparePasswordHash(Convert.ToString(data["PasswordHash"]), password);

                if (user.IsAuthenticated)
                {
                    user.GenerateSecurityToken();
                }
            }

            return user;
        }

        public static async Task<User> Get(string emailAddress)
        {
            User user = null;

            DataRow userData = await UsersDbContext.Current.GetUser(emailAddress);

            if (userData != null)
            {
                user = FromDataRow(userData);
            }

            return user;
        }

        public static async Task<User> Get(int userId)
        {
            User user = null;

            if (userId > 0)
            {
                // get the user
                DataRow userData = await UsersDbContext.Current.GetUser(userId);

                if (userData != null)
                {
                    user = FromDataRow(userData);
                }
            }

            return user;
        }

        public static async Task<User> GetByToken(string passwordResetToken)
        {
            User user = null;

            DataTable userData = await UsersDbContext.Current.GetUserByToken(passwordResetToken);

            if (userData.Rows.Count == 1)
            {
                user = User.FromDataRow(userData.Rows[0]);
            }

            return user;
        }

        public static async Task<List<User>> GetAll()
        {
            DataTable userData = await UsersDbContext.Current.GetUsers();

            return User.FromDataTable(userData);
        }

        public static async Task FinishEmailValidation(string token)
        {
            await UsersDbContext.Current.SetEmailValidated(token);
        }

        public void GenerateSecurityToken(bool invalidatingToken = false)
        {
            if (this.IsAuthenticated)
            {
                DateTime tokenExpiry = DateTime.Now.AddMinutes(60);

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, this.EmailAddress),
                    new Claim(JwtRegisteredClaimNames.Jti, this.UserId.ToString()),
                    new Claim(ClaimTypes.Expiration, tokenExpiry.ToBinary().ToString()),
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppSettings.Current.JWTKey));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                JwtSecurityToken token = new JwtSecurityToken(issuer: AppSettings.Current.JWTIssuer, audience: AppSettings.Current.JWTIssuer, claims: claims, expires: tokenExpiry, signingCredentials: creds);

                this.SecurityToken = new JwtSecurityTokenHandler().WriteToken(token);
                this.SecurityTokenExpiry = invalidatingToken ? DateTime.Now.AddMinutes(-1) : tokenExpiry;
            }
        }

        public async Task<bool> StartPasswordReset()
        {
            // 1. reset the token of this workspace to secure it
            this.PasswordResetToken = Guid.NewGuid().ToString();
            await UsersDbContext.Current.UpdatePasswordAndToken(this.UserId, this.PasswordHash, this.PasswordResetToken);

            // 2. generate and send reset link
            // await EmailContext.Current.SendStartPasswordResetLink(this);

            return true;
        }

        public async Task<bool> FinishPasswordReset(string passwordHash, string oldToken, string newToken)
        {
            if (!string.IsNullOrEmpty(passwordHash) && !string.IsNullOrEmpty(oldToken) && !string.IsNullOrEmpty(newToken))
            {
                if (this.PasswordResetTokenExpiry < DateTime.Now)
                {
                    return false;
                }

                await UsersDbContext.Current.UpdatePassword(passwordHash, oldToken, newToken);
                // await EmailContext.Current.SendPasswordChangedNotification(this);
                return true;
            }

            return false;
        }

        public async Task StartEmailValidation()
        {
            // 1. reset the token of this workspace to secure it
            string token = Guid.NewGuid().ToString();
            await UsersDbContext.Current.UpdatePasswordAndToken(this.UserId, this.PasswordHash, token);

            // 2. generate and send validation link
            // await EmailContext.Current.SendEmailValidationLink(this);
        }

        public async Task<string> GetPasswordResetToken(bool regenerate = true)
        {
            string token = string.Empty;

            if (regenerate)
            {
                token = Guid.NewGuid().ToString();
                await UsersDbContext.Current.UpdateToken(this.UserId, token);
            }
            else
            {
                token = await UsersDbContext.Current.GetToken(this.UserId);
            }

            return token;
        }

        public async Task FinishPasswordReset(string newPassword)
        {
            await Task.Delay(0);
            this.PasswordHash = PasswordManager.GenerateSaltedHash(newPassword, PasswordManager.GenerateSaltValue());
        }

        public async Task Save()
        {
            if (this.UserId == 0)
            {
                this.UserId = await UsersDbContext.Current.CreateUser(this.EmailAddress, this.PasswordHash, Guid.NewGuid().ToString());

                await this.StartEmailValidation();
            }
            else
            {
                await UsersDbContext.Current.UpdateUser(this.UserId, this.EmailAddress, this.PasswordHash);
            }
        }
    }
}
