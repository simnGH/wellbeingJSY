namespace wellbeing.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using wellbeing.Components.UI;

    [Authorize]
    public class HomeController : WellbeingUIController
    {
        public HomeController(IWebHostEnvironment environment, IOptions<AppSettings> appSettings, IServiceProvider serviceProvider)
            : base(environment, appSettings, serviceProvider)
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
