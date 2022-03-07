namespace wellbeing.Components.UI
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;
    using wellbeing.Components.UI.Authentication;
    using wellbeing.Models.UI.Page;
    using wellbeing.Models.UI.View;
    using wellbeing.Models.UI.View.Users;
    using wellbeing.Components.API.Users;
    using wellbeing.Components.API.Survey;
    using wellbeing.Components.API.Content;


    public class WellbeingUIController : Controller
    {
        private UserViewModel _user;

        public WellbeingUIController(IWebHostEnvironment environment, IOptions<AppSettings> appSettings, IServiceProvider serviceProvider)
        {
            if (environment == null)
            {
                throw new ArgumentNullException(nameof(environment));
            }

            if (appSettings == null)
            {
                throw new ArgumentNullException(nameof(appSettings));
            }

            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            // store references
            AppSettings.Current = appSettings.Value;
            this.ServiceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            this.Environment = environment.EnvironmentName;

            if (environment != null)
            {
                this.HostingEnvironment = environment;
            }

            // set up common contexts
            AuthenticationManager.Current = ServiceProvider.GetService<IAuthenticationManager>();

            if (UsersDbContext.Current == null)
            {
                UsersDbContext.Current = ServiceProvider.GetService<IUsersDbContext>();
            }
            
            if (SurveyDbContext.Current == null)
            {
                SurveyDbContext.Current = ServiceProvider.GetService<ISurveyDbContext>();
            }

            if (ContentDbContext.Current == null)
            {
                ContentDbContext.Current = ServiceProvider.GetService<IContentDbContext>();
            }
        }

        public string Environment { get; set; }

        public string Component => this.ControllerContext.RouteData.Values["area"] != null ? $"{this.ControllerContext.RouteData.Values["area"]}/{this.ControllerContext.RouteData.Values["controller"]}" : Convert.ToString(this.ControllerContext.RouteData.Values["controller"]);

        public string Method
        {
            get
            {
                return Convert.ToString(this.ControllerContext.RouteData.Values["action"]);
            }
        }


        protected IServiceProvider ServiceProvider { get; set; }

        protected IWebHostEnvironment HostingEnvironment { get; set; }

        protected async Task<UserViewModel> GetCurrentUser()
        {
            if (_user == null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    AuthenticationManager mgr = (AuthenticationManager)ServiceProvider.GetService<IAuthenticationManager>();
                    _user = await mgr.GetCurrentUser();
                }
            }

            return _user;
        }
    }
}
