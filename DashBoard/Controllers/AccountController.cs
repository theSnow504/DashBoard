using AspNetCoreHero.ToastNotification.Abstractions;
using Dashboard.Common.Enums;
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
            _notyf = notyf;
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
            CookieOptions options = new CookieOptions()
            {
                Expires = DateTime.UtcNow.AddHours(1)
            };
            string? Count = Request.Cookies["count"];
            int count = Count == null ? 0 : int.Parse(Count);
            if (user.Data != null)
            {
                if (count == 5)
                {
                    _notyf.Error("Bạn tạm thời không đăng nhập được vì bạn đã đăng nhập sai quá số lần quy định");
                    return View();
                }
                Response.Cookies.Append("count", "0");
                HttpContext.Session.SetString("User", JsonConvert.SerializeObject(user.Data));
                return RedirectToAction("Index", "Home");
            }

            if (user.Code == (int) StatusLogin.UserNotExisting)
            {
                _notyf.Error("Sai tài khoản");
                return View();
            }
            if (user.Code == (int)StatusLogin.PasswordWrong)
            {
                count++;
                if (count >= 5)
                {
                    if (count == 5)
                    {
                        Response.Cookies.Append("count", count.ToString(), options);
                    }
                    _notyf.Error("Bạn đã nhập sai quá số lần quy định. Vui lòng quay lại sau");
                    return View();
                }
                Response.Cookies.Append("count", count.ToString(), options);
                _notyf.Error("Mật khẩu không chính xác, bạn còn " + (5 - count) + " lần thử");
                return View();
            }
            _notyf.Error(user.Message);
            return View();
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