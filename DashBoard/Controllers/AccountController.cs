using AspNetCoreHero.ToastNotification.Abstractions;
using Dashboard.Service.Api.Users;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DashBoard.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsersApiServices _userService;
        private readonly INotyfService _notyf;
        public AccountController(IUsersApiServices userService, INotyfService notyf)
        {
            _notyf=notyf;
            _userService = userService;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _userService.GetUser(username, password);
            if (user.Data != null)
            {
                HttpContext.Session.SetString("User", JsonConvert.SerializeObject(user.Data));
                return RedirectToAction("Index", "Home");
            }
            else
            {
                _notyf.Error("Sai tài khoản hoặc mật khẩu");
                return View();
            }
                
        }

        public IActionResult Logout()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(string username, string license)
        {
            return RedirectToAction("ResetPassword", "Account");
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }

        public ActionResult ResetPassword()
        {
            return View();
        }
    }
}