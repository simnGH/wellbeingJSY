namespace wellbeing.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using Newtonsoft.Json;
    using wellbeing.Components;
    using wellbeing.Components.Shared.API;
    using wellbeing.Components.UI.Authentication;
    using wellbeing.Mappers;
    using wellbeing.Components.UI;
    using wellbeing.Models.UI.Page.Authentication;
    using wellbeing.Models.UI.Page.Users;
    using wellbeing.Models.UI.View.Users;

    [Authorize]
    public class UsersController : WellbeingUIController
    {
        public UsersController(IWebHostEnvironment environment, IOptions<AppSettings> appSettings, IServiceProvider serviceProvider)
            : base(environment, appSettings, serviceProvider)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            UsersProfilePageModel model = new UsersProfilePageModel();
            model.CurrentUser = await GetCurrentUser();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Profile(UsersProfilePageModel model)
        {
            string id = (await GetCurrentUser()).UserId.ToString();

            return View(model);
        }
    }
}
