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
            var check = _userService.CheckExitUser(username);
            var user = _userService.GetUser(username, password);
            var name = username;
            int count = 0;
            var cookieValue = Request.Cookies[username];
            if (cookieValue != null)
            {
                count = int.Parse(cookieValue);
            }

            if (check.Data==null)
            {
                _notyf.Error("Sai tài khoản");
                return View();
            }
            if(check.Data!=null && user.Data==null)
            {
                _notyf.Error("Tài khoản đúng mật khẩu sai");
                count++;
                //HttpContext.Session.SetInt32(username, count);
                Response.Cookies.Append(username, count.ToString(), new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddDays(1) // Thời gian tồn tại của cookie, có thể thay đổi tùy theo nhu cầu
                });
                if (count<=4)
                {
                    _notyf.Error("Bạn đã nhập sai "+count+" lần, còn lại "+(5-count)+" lần thử");
                    return View();
                }
                else
                {
                    _notyf.Error("Nhập sai quá số lần quy định, vui lòng thử lại sau");
                    return View();
                }    
            }
            if (user.Data != null)
            {
                HttpContext.Session.SetString("User", JsonConvert.SerializeObject(user.Data));
                //HttpContext.Session.SetInt32(username, 0);
                Response.Cookies.Delete(username);
                return RedirectToAction("Index", "Home");
            }
            else
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