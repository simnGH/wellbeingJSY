namespace wellbeing.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using wellbeing.Components.UI;
    using wellbeing.Components.API.Survey;
    using wellbeing.Models.UI.View.Users;

    [Authorize]
    public class HomeController : WellbeingUIController
    {
        public HomeController(IWebHostEnvironment environment, IOptions<AppSettings> appSettings, IServiceProvider serviceProvider)
            : base(environment, appSettings, serviceProvider)
        {
        }

        /*

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Question> questions = await Question.GetRandom();
            return View(questions);
        }

        */

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            UserViewModel user = await this.GetCurrentUser();
            return View(user);
        }



        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost("/questions/submit")]
        public async Task<IActionResult> SubmitAnswer([FromBody] Answer answer)
        {
            UserViewModel currentUser = await this.GetCurrentUser();

            answer.UserId = currentUser.UserId;

            await answer.Save();

            return View(answer);
        }
    }
}
