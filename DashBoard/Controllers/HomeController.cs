using Dashboard.DataDto.User;
using Dashboard.Service.Api.Users;
using Microsoft.AspNetCore.Mvc;

namespace DashBoard.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUsersApiServices _userService;
        public HomeController(IUsersApiServices userService)
        {
            _userService = userService;
        }

        public IActionResult Index(UserLoginDto user)
        {
            return View(user);
        }

        public IActionResult LoadFacebookPartial(int iduser)
        {
            var accounts = _userService.GetAccountFbEverLogin(iduser);
            return PartialView("_AccountFacebook", accounts);
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