namespace wellbeing.Components.UI.Authentication
{
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Options;
    using Newtonsoft.Json;
    using wellbeing;
    using wellbeing.Components.API.Authentication;
    using wellbeing.Components.API.Users;
    using wellbeing.Mappers;
    using wellbeing.Models.UI.View.Users;

    public class AuthenticationManager : IAuthenticationManager
    {
        public AuthenticationManager(IOptions<AppSettings> settings, UserManager<UserViewModel> userManager, SignInManager<UserViewModel> signInManager, IHttpContextAccessor httpContext)
        {
            ////IServiceProvider serviceProvider
            AppSettings.Current = settings.Value;
            this.UserManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            this.SignInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            this.Context = httpContext ?? throw new ArgumentNullException(nameof(httpContext));
        }

        public static IAuthenticationManager Current { get; set; }

        public IServiceProvider ServiceProvider { get; set; }

        public UserManager<UserViewModel> UserManager { get; set; }

        public SignInManager<UserViewModel> SignInManager { get; private set; }

        public IHttpContextAccessor Context { get; private set; }

        public async Task<UserViewModel> GetCurrentUser()
        {
            UserViewModel user = null;
            System.Security.Principal.IIdentity identity = this.Context.HttpContext.User.Identity;

            if (identity.IsAuthenticated)
            {
                user = await this.UserManager.FindByIdAsync(identity.Name);

                if (user == null)
                {
                    await this.SignInManager.SignOutAsync();
                }
            }

            return user;
        }

        public async Task<UserViewModel> Register(string username, string password)
        {
            UserViewModel user = new UserViewModel();

            string passwordHash = PasswordManager.GenerateSaltedHash(password, PasswordManager.GenerateSaltValue());

            user.PasswordResetToken = Guid.NewGuid().ToString();
            user.UserId = await UsersDbContext.Current.CreateUser(username, passwordHash, user.PasswordResetToken);

            return user;
        }

        public async Task<UserViewModel> SignIn(string username, string password)
        {
            UserViewModel model = null;

            username = string.IsNullOrEmpty(username) ? string.Empty : username.Trim();

            User user = await User.Authenticate(username, password);

            if (user != null && user.IsAuthenticated)
            {
                model = UsersMapper.MapUserToUserViewModel(user);

                // Now sign them in with their claims
                await this.SignInManager.SignInAsync(model, false);
            }

            return model;
        }

        public async Task SignOut()
        {
            await this.SignInManager.SignOutAsync();
        }
    }
}
