using DashBoard.Models;
using Microsoft.AspNetCore.Mvc;
using Dashboard.DataDto.ViewModels;

namespace DashBoard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        TestContext _testContext = new TestContext();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LoadFacebookPartial()
        {
            return PartialView("_AccountFacebook");
        }

        public IActionResult LoadTiktokPartial()
        {
            return PartialView("_AccountTiktok");
        }

        public IActionResult LoadYoutubePartial()
        {
            return PartialView("_AccountYoutube");
        }

        public IActionResult LoadClientPartial()
        {
            var userClients = "";
            return PartialView("_AccountClient", userClients);
        }
    }
}
