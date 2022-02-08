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

    [Authorize]
    public class HomeController : WellbeingUIController
    {
        public HomeController(IWebHostEnvironment environment, IOptions<AppSettings> appSettings, IServiceProvider serviceProvider)
            : base(environment, appSettings, serviceProvider)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Question> questions = await Question.GetRandom();
            return View(questions);
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
