using AspNetCoreHero.ToastNotification.Abstractions;
using Dashboard.DataDto.Chart;
using Dashboard.Service.Api.Actions;
using Dashboard.Service.Api.Users;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DashBoard.Controllers
{
    public class HomeController : Controller
    {
        private readonly INotyfService _notyf;
        private readonly IUsersApiServices _userService;
        private readonly IActionServices _actionService;

        public HomeController(IUsersApiServices userService, INotyfService notyf, IActionServices actionService)
        {
            _userService = userService;
            _notyf = notyf;
            _actionService = actionService;
        }

        [ResponseCache(NoStore = true, Duration = 0, VaryByHeader = "none")]
        public IActionResult Index()
        {
            var id = HttpContext.Session.GetInt32("IdUser");
            var user = _userService.GetUserById(id);

            if (user.Data != null)
            {
                return View(user.Data);
            }
            else return RedirectToAction("Login", "Account"); 
        }

        public IActionResult LoadDashboardPartial()
        {
            return PartialView("_Dashboard");
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
            return PartialView("_AccountClient", accounts.Data);
        }
        public IActionResult LoadActionPartial(int iduser)
        {
            var actions = _actionService.GetActionHistory(iduser);
            return PartialView("_ActionHistory", actions.Data);

        }

        public ActionResult GetChartData(int iduser)
        {
            ChartDto chart = new ChartDto()
            {
                Lables = new[] {"123"} ,
                DataLable = "Test",
                Datas = new[] {1,2,3}
            };

            return Json(chart);
        }
    }
}