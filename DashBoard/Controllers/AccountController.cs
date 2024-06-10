using AspNetCoreHero.ToastNotification.Abstractions;
using Dashboard.DataDto.User;
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
                if (count >= 5)
                {
                    _notyf.Error("Tài khoản này tạm thời bị khoá");
                    return View();
                }
            }

            if (check.Data == null)
            {
                _notyf.Error("Sai tài khoản");
                return View();
            }
            if (check.Data != null && user.Data == null)
            {
                _notyf.Error("Mật khẩu không chính xác");
                count++;
                //HttpContext.Session.SetInt32(username, count);
                Response.Cookies.Append(username, count.ToString(), new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddDays(1) // Thời gian tồn tại của cookie, có thể thay đổi tùy theo nhu cầu
                });
                if (count <= 4)
                    if (count < 5)
                    {
                        _notyf.Error("Bạn đã nhập sai " + count + " lần, còn lại " + (5 - count) + " lần thử");
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
                _notyf.Success("Đăng nhập thành công");
                Response.Cookies.Delete(username);
                return RedirectToAction("Index", "Home");
            }
            else 
                return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Login");
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

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordDto passwordDto)
        {
            var userDataJson = HttpContext.Session.GetString("User");
            var userData = JsonConvert.DeserializeObject<UserLoginDto>(userDataJson);
            if (userData != null) 
            { 
                passwordDto.IdUser = userData.Id;
            }

            if (passwordDto.CurrentPassword == null || passwordDto.NewPassword == null || passwordDto.ConfirmPassword == null)
            {
                _notyf.Error("Mật khẩu không được là khoảng trắng");
                return View();
            }

            if (passwordDto.NewPassword != passwordDto.ConfirmPassword)
            {
                _notyf.Error("Mật khẩu nhập lại không đúng");
                return View();
            }

            var response = _userService.ChangePassword(passwordDto);
            if(response.Code == 99)
            {
                _notyf.Error("Mật khẩu cũ không đúng");
                return View();
            }

            if(response.IsSuccessful)
            {
                _notyf.Success("Đổi mật khẩu thành công");
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public ActionResult ResetPassword()
        {
            return View();
        }
    }
}