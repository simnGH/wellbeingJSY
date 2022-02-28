namespace wellbeing.Components.API.Users
{
    using System;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;
    using Codentia.Common.Data;

    public class UsersDbContext : DatabaseContext, IUsersDbContext
    {
        private const string COLS_USER = "u.UserId, EmailAddress, EmailValidatedAt, PasswordHash, PasswordResetToken, PasswordResetTokenExpiry, BodyScore, MindScore, WorkScore, WealthScore, Age";
        private const string UpdatePasswordAndTokenQuery = "UPDATE user SET Passwordhash = @PasswordHash, PasswordResetToken = @Token, PasswordResetTokenExpiry = NOW() + INTERVAL 1 HOUR WHERE UserId = @UserId;";
        private const string UpdatePasswordQuery = "UPDATE user SET PasswordHash = @PasswordHash, PasswordResetToken = @NewToken, PasswordResetTokenExpiry = NULL WHERE PasswordResetToken = @OldToken;";
        private const string SetEmailValidatedQuery = "UPDATE user SET EmailValidatedAt = NOW(), PasswordResetToken = NULL, PasswordResetTokenExpiry = NULL WHERE PasswordResetToken = @Token;";
        private const string UpdateTokenQuery = "UPDATE user SET PasswordResetToken = @Token, PasswordResetTokenExpiry = NOW() + INTERVAL 1 HOUR WHERE UserId = @UserId;";
        private const string GetTokenQuery = "SELECT PasswordResetToken FROM user WHERE UserId = @UserId";
        private const string CreateUserQuery = "INSERT INTO user (EmailAddress, PasswordHash, PasswordResetToken, PasswordResetTokenExpiry) VALUES (@EmailAddress, @PasswordHash, @Token, NOW() + INTERVAL 1 HOUR); SELECT LAST_INSERT_ID();";
        private const string UpdateUserQuery = "UPDATE user SET EmailAddress = @EmailAddress, PasswordHash = @PasswordHash, PasswordHash = @PasswordHash WHERE UserId = @UserId;";
        private static readonly string GetUserQuery = $"SELECT {COLS_USER} FROM user u WHERE ";
        private static readonly string GetUserByTokenQuery = $"SELECT {COLS_USER} FROM user u WHERE PasswordResetToken = @Token;";

        public static IUsersDbContext Current { get; set; }

        public async Task<DataRow> GetUser(int userId)
        {
            DbParameter[] parameters =
            {
                new DbParameter("@UserId", DbType.Int32, userId),
            };

            string query = $"{GetUserQuery} UserId = @UserId;";

            DataTable result = await this.Execute<DataTable>(query, parameters);
            return result.AsEnumerable().FirstOrDefault();
        }

        public async Task<DataRow> GetUser(string emailAddress)
        {
            DbParameter[] parameters =
            {
                new DbParameter("@EmailAddress", DbType.String, 150, emailAddress),
            };

            string query = $"{GetUserQuery} EmailAddress = @EmailAddress;";

            DataTable result = await this.Execute<DataTable>(query, parameters);
            return result.AsEnumerable().FirstOrDefault();
        }

        public async Task<DataTable> GetUserByToken(string PasswordResetToken)
        {
            DbParameter[] parameters =
            {
                new DbParameter("@Token", DbType.String, 36, PasswordResetToken)
            };

            return await this.Execute<DataTable>(GetUserByTokenQuery, parameters);
        }

        public async Task<DataTable> GetUsers(int[] userIds)
        {
            string query = $"{GetUserQuery} UserId IN ({string.Join(",", userIds)})";
            return await this.Execute<DataTable>(query, null);
        }

        public async Task<DataTable> GetUsers()
        {
            string query = $"{GetUserQuery} UserId != 0";
            return await this.Execute<DataTable>(query, null);
        }

        public async Task UpdatePasswordAndToken(int userId, string hash, string token)
        {
            DbParameter[] parameters =
            {
                new DbParameter("@PasswordHash", DbType.String, 512, hash),
                new DbParameter("@Token", DbType.String, 36, token),
                new DbParameter("@UserId", DbType.Int32, userId)
            };

            await this.Execute<DBNull>(UpdatePasswordAndTokenQuery, parameters);
        }

        public async Task UpdatePassword(string hash, string oldToken, string newToken)
        {
            DbParameter[] parameters =
            {
                new DbParameter("@PasswordHash", DbType.String, 512, hash),
                new DbParameter("@OldToken", DbType.String, 36, oldToken),
                new DbParameter("@NewToken", DbType.String, 36, newToken),
            };

            await this.Execute<DBNull>(UpdatePasswordQuery, parameters);
        }

        public async Task SetEmailValidated(string token)
        {
            DbParameter[] parameters =
            {
                new DbParameter("@Token", DbType.String, 36, token),
            };

            await this.Execute<DBNull>(SetEmailValidatedQuery, parameters);
        }

        public async Task UpdateToken(int userId, string token)
        {
            DbParameter[] parameters =
            {
                new DbParameter("@UserId", DbType.Int32, userId),
                new DbParameter("@Token", DbType.String, 36, token),
            };

            await this.Execute<DBNull>(UpdateTokenQuery, parameters);
        }

        public async Task<string> GetToken(int userId)
        {
            DbParameter[] parameters =
            {
                new DbParameter("@UserId", DbType.Int32, userId),
            };

            return await this.Execute<string>(GetTokenQuery, parameters);
        }

        public async Task<int> CreateUser(string emailAddress, string passwordHash, string token)
        {
            DbParameter[] parameters =
            {
                new DbParameter("@EmailAddress", DbType.String, 150, emailAddress),
                new DbParameter("@PasswordHash", DbType.String, 512, passwordHash),
                new DbParameter("@Token", DbType.String, 36, token),
            };

            return await this.Execute<int>(CreateUserQuery, parameters);
        }

        public async Task UpdateUser(int userId, string emailAddress, string passwordHash)
        {
            DbParameter[] parameters =
            {
                new DbParameter("@UserId", DbType.Int32, userId),
                new DbParameter("@EmailAddress", DbType.String, 150, emailAddress),
                new DbParameter("@PasswordHash", DbType.String, 512, passwordHash),
            };

            await this.Execute<DBNull>(UpdateUserQuery, parameters);
        }
    }
}
