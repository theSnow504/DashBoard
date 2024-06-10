using Dashboard.DataDto.User;
using Dashboard.Service.Api.Users;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DashBoard.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUsersApiServices _userService;
        public HomeController(IUsersApiServices userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            var userDataJson = HttpContext.Session.GetString("User");
            if (userDataJson != null)
            {
                var userData = JsonConvert.DeserializeObject<UserLoginDto>(userDataJson);
                return View(userData);
            }
            return View();
        }

        public IActionResult LoadFacebookPartial(int iduser)
        {
            var accounts = _userService.GetAccountFbEverLogin(iduser);
            return PartialView("_AccountFacebook", accounts.Data);
        }

        public IActionResult LoadTiktokPartial()
        {
            return PartialView("_AccountTiktok");
        }

        public IActionResult LoadYoutubePartial()
        {
            return PartialView("_AccountYoutube");
        }
        public IActionResult LoadClientPartial(int iduser)
        {
            var accounts = _userService.GetAccountEverLogin(iduser);
            return PartialView("_AccountClient");
        }
    }
}