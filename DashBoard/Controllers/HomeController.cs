using Microsoft.AspNetCore.Mvc;

namespace DashBoard.Controllers
{
    public class HomeController : Controller
    {
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
            return PartialView("_AccountClient");
        }
    }
}
