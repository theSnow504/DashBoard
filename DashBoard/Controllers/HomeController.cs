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
            //var session = HttpContext.Session.GetInt32("User");
            //var getFbUser = from a in _testContext.Users
            //                join b in _testContext.UsersAccountFbs on a.Id equals b.IdUser
            //                join c in _testContext.AccountFbs on b.IdAccountFb equals c.Id
            //                where a.Id == session
            //                select new AccountFbViewModel
            //                {
            //                    Id = c.Id,
            //                    FbUser = c.FbUser,
            //                    FbPassword = c.FbPassword,
            //                };
            //return PartialView("_AccountFacebook", getFbUser.ToList());
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
            var session = HttpContext.Session.GetInt32("User");
            var userClient = _testContext.UserClients.Where(x => x.IdUser.Equals(session)).Select(x => new ClienAccountsViewModel
            {
                UserName = x.Token.ToString(),
            });
            return PartialView("_AccountClient", userClient);
        }
    }
}
