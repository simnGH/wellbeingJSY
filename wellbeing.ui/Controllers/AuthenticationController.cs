namespace wellbeing.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using wellbeing.Components;
    using wellbeing.Components.API;
    using wellbeing.Components.API.Authentication;
    using wellbeing.Components.UI;
    using wellbeing.Components.UI.Authentication;
    using wellbeing.Components.Shared.API;
    using wellbeing.Components.API.Users;
    using wellbeing.Models.UI.Page.Authentication;
    using wellbeing.Models.UI.View.Users;

    public class AuthenticationController : WellbeingUIController
    {
        public AuthenticationController(IWebHostEnvironment environment, IOptions<AppSettings> appSettings, IServiceProvider serviceProvider)
            : base(environment, appSettings, serviceProvider)
        {
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("/Login")]
        public async Task<IActionResult> Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToHomepage(await this.GetCurrentUser());
            }

            LoginPageModel model = new LoginPageModel();

            if (HttpContext.Request.Query.Any(q => q.Key.ToLower() == "returnurl"))
            {
                model.ReturnUrl = HttpContext.Request.Query.First(q => q.Key.ToLower() == "returnurl").Value;
            }

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("/Login")]
        public async Task<IActionResult> Login(LoginPageModel model)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToHomepage(await this.GetCurrentUser(), returnUrl: model.ReturnUrl);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    UserViewModel user = await AuthenticationManager.Current.SignIn(model.EmailAddress, model.Password);

                    if (user != null && user.IsAuthenticated)
                    {
                        return RedirectToHomepage(user, returnUrl: model.ReturnUrl);
                    }

                    model.ErrorMessages.Add("Email or Password incorrect.");
                }
                catch (Exception ex)
                {
                    model.ErrorMessages.Add(ex.Message);
                }
            }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("/Logout")]
        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await AuthenticationManager.Current.SignOut();
            }

            return this.Redirect("/Login");
        }

        [HttpGet]
        [Route("/Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToHomepage(await this.GetCurrentUser());
            }

            RegisterPageModel model = new RegisterPageModel();

            if (HttpContext.Request.Query.Any(q => q.Key.ToLower() == "returnurl"))
            {
                model.ReturnUrl = HttpContext.Request.Query.First(q => q.Key.ToLower() == "returnurl").Value;
            }

            return View(model);
        }

        [HttpPost]
        [Route("/Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterPageModel model)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return this.RedirectToHomepage(await this.GetCurrentUser(), returnUrl: model.ReturnUrl);
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    UserViewModel user = await AuthenticationManager.Current.Register(model.EmailAddress, model.Password);

                    if (user != null)
                    {
                        user = await AuthenticationManager.Current.SignIn(model.EmailAddress, model.Password);

                        if (user != null && user.IsAuthenticated)
                        {
                            return this.RedirectToHomepage(user, model.ReturnUrl);
                        }
                    }
                    else
                    {
                        model.ErrorMessages.Add("There was an error creating your account.");
                    }
                }
                catch (Exception ex)
                {
                    model.ErrorMessages.Add(ex.Message);
                }
            }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("/ForgottenPassword")]
        public async Task<IActionResult> StartPasswordReset()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return this.RedirectToHomepage(await this.GetCurrentUser());
            }

            StartPasswordResetPageModel model = new StartPasswordResetPageModel();
            model.CurrentUser = await GetCurrentUser();

            return this.View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("/ForgottenPassword")]
        public async Task<IActionResult> StartPasswordReset(StartPasswordResetPageModel model)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return this.RedirectToHomepage(await this.GetCurrentUser());
            }

            if (ModelState.IsValid)
            {
                wellbeing.Components.API.Users.User user = await wellbeing.Components.API.Users.User.Get(model.EmailAddress);

                if (user.UserId != 0)
                {
                    await user.StartPasswordReset();

                    model.AlertMessages.Add("We've sent you an email with instructions on how to recover your account.");
                }
            }

            return this.View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("/ResetPassword/{token}")]
        public IActionResult FinishPasswordReset(string token)
        {
            FinishPasswordResetPageModel model = new FinishPasswordResetPageModel
            {
                Token = token
            };

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("/ResetPassword/{token}")]
        public async Task<IActionResult> FinishPasswordReset(FinishPasswordResetPageModel model, string token)
        {          
            if (this.User.Identity.IsAuthenticated)
            {
                return this.RedirectToHomepage(await this.GetCurrentUser());
            }

            try
            {
                wellbeing.Components.API.Users.User user = await wellbeing.Components.API.Users.User.GetByToken(token);

                if (user != null)
                {
                    string passwordHash = PasswordManager.GenerateSaltedHash(model.Password, PasswordManager.GenerateSaltValue());
                    string newToken = Guid.NewGuid().ToString();

                    bool success = await user.FinishPasswordReset(passwordHash, token, newToken);

                    if(success)
                    {
                        model.AlertMessages.Add("Your password has been updated.");
                    }
                    else
                    {
                        model.ErrorMessages.Add("Token has expired.");
                    }
                }
                else
                {
                    model.ErrorMessages.Add("There was an error and your password has not been updated.");
                }
            }
            catch (Exception ex)
            {
                model.ErrorMessages.Add(ex.Message);
            }

            return View(model);
        }

        private IActionResult RedirectToHomepage(UserViewModel user, string returnUrl = null)
        {
            if (user != null && user.IsAuthenticated)
            {
                if (!string.IsNullOrEmpty(returnUrl))
                {
                    return this.Redirect(returnUrl);
                }

                if (this.HttpContext.Request.Query.Any(q => q.Key.ToLower() == "returnurl"))
                {
                    return this.Redirect(this.HttpContext.Request.Query.First(q => q.Key.ToLower() == "returnurl").Value);
                }

                return this.Redirect("/Home");
            }

            AuthenticationManager.Current.SignOut();

            return this.NotFound();
        }
    }
}
