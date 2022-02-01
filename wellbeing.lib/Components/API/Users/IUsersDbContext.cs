namespace wellbeing.Components.API.Users
{
    using System.Data;
    using System.Threading.Tasks;

    public interface IUsersDbContext
    {
        Task<DataRow> GetUser(int userId); 

        Task<DataRow> GetUser(string emailAddress);

        Task<DataTable> GetUserByToken(string PasswordResetToken);

        Task<DataTable> GetUsers(int[] userIds);

        Task<DataTable> GetUsers();

        Task UpdatePasswordAndToken(int userId, string hash, string token);

        Task UpdatePassword(string hash, string oldToken, string newToken);

        Task SetEmailValidated(string token);

        Task UpdateToken(int userId, string token);

        Task<string> GetToken(int userId);

        Task<int> CreateUser(string emailAddress, string passwordHash, string token);

        Task UpdateUser(int userId, string passwordHash, string emailAddress);
    }
}
