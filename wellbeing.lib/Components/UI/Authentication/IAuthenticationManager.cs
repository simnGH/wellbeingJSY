namespace wellbeing.Components.UI.Authentication
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using wellbeing.Models.UI.View.Users;
    using wellbeing.Components.API.Users;

    public interface IAuthenticationManager
    {
        IHttpContextAccessor Context { get; }

        Task<UserViewModel> GetCurrentUser();

        Task<UserViewModel> Register(string username, string password);

        Task<UserViewModel> SignIn(string username, string password);

        Task SignOut();
    }
}
