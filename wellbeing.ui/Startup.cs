namespace wellbeing.ui
{
    using wellbeing;
    using wellbeing.Components.API.Users;
    using wellbeing.Components.API.Survey;
    using wellbeing.Components.Shared;
    using wellbeing.Components.UI.Authentication;
    using wellbeing.Models.UI.View.Users;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.DataProtection;
    using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.HttpOverrides;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Net.Http.Headers;
    using Newtonsoft.Json.Serialization;
    using StackExchange.Redis;

    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: false)
            .AddJsonFile($"secrets/appsettings.{env.EnvironmentName}.json", true, false)
            .AddEnvironmentVariables();

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<AppSettings>();
            }

            this.Configuration = builder.Build();
            this.Environment = env;
        }

        public IConfiguration Configuration { get; }

        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
       public void ConfigureServices(IServiceCollection services)
        {
            AppSettings.Current = Configuration.GetSection("AppSettings").Get<AppSettings>();
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddOptions();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

            services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();

            // services.AddCors(c =>
            // {
            //     c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            // });

            services.AddAuthorization(options =>
            {
                options.AddPolicy(
                    "IsLoggedIn",
                    policy =>
                    {
                        policy.RequireAuthenticatedUser();
                    });
            });

            // services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpContextAccessor();

            services.AddMvc().AddNewtonsoftJson(options =>
            {
                // Use the default property (Pascal) casing
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                options.SerializerSettings.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto;
            });

            services.AddWebOptimizer(pipeline =>
                {
                    pipeline.AddCssBundle("/css/core.min.css", "assets/css/core.css").UseContentRoot();
                    pipeline.AddJavaScriptBundle("/js/core.min.js", "assets/js/core.js").UseContentRoot();
                    pipeline.AddJavaScriptBundle("/js/survey_response.min.js", "assets/js/survey_response.js").UseContentRoot();
                }
            );

            // Identity Services
            services.AddTransient<UserManager<UserViewModel>>();
            services.AddSingleton<IUserStore<UserViewModel>, UserStore>();
            services.AddTransient<IAuthenticationManager, AuthenticationManager>();
            services.AddSingleton<IRoleStore<RoleViewModel>, UserRoleStore>();
            services.AddScoped<IUserClaimsPrincipalFactory<UserViewModel>, WellbeingClaimsPrincipalFactory>();

            services.AddIdentity<UserViewModel, RoleViewModel>(options =>
            {
            })
            .AddDefaultTokenProviders()
            .AddClaimsPrincipalFactory<WellbeingClaimsPrincipalFactory>();

            // If you want to tweak Identity cookies, they're no longer part of IdentityOptions.
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Login";
                options.LogoutPath = "/Logout";
                options.ExpireTimeSpan = System.TimeSpan.FromMinutes(30);
                options.SlidingExpiration = true;
            });

            AuthenticatedEncryptorConfiguration configuration = new AuthenticatedEncryptorConfiguration()
            {
                EncryptionAlgorithm = Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.EncryptionAlgorithm.AES_256_CBC,
                ValidationAlgorithm = Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ValidationAlgorithm.HMACSHA512
            };

            services.AddDataProtection()
                .PersistKeysToStackExchangeRedis(ConnectionMultiplexer.Connect(AppSettings.Current.RedisConnectionString), AppSettings.Current.RedisKey)
                .UseCryptographicAlgorithms(configuration: configuration);

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = AppSettings.Current.RedisConnectionString;
            });

            services.AddTransient<IUsersDbContext, UsersDbContext>();
            services.AddTransient<ISurveyDbContext, SurveyDbContext>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                {
                    const int durationInSeconds = 60 * 60 * 24;
                    ctx.Context.Response.Headers[HeaderNames.CacheControl] =
                        "public,max-age=" + durationInSeconds;
                }
            });


            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseWebOptimizer();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
