using AspNetCoreHero.ToastNotification.Abstractions;
using Dashboard.DataDto.User;
using Dashboard.Service.Api.Users;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection.Metadata;
using System.Web;

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

                if(count>=5)
                {
                    _notyf.Error("Tài khoản này tạm thời bị khoá");
                    return View();
                }    
            }
         
            if (check.Data==null)
            {
                _notyf.Error("Sai tài khoản");
                return View();
            }
            if (check.Data != null && user.Data == null)
            {
                _notyf.Error("Mật khẩu không chính xác");
                count++;
                Response.Cookies.Append(username, count.ToString(), new CookieOptions
                {
                    Expires = DateTimeOffset.UtcNow.AddHours(1) // Thời gian tồn tại của cookie, có thể thay đổi tùy theo nhu cầu
                });
                if (count<5)
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
                HttpContext.Session.SetInt32("IdUser", user.Data.Id);
                _notyf.Success("Đăng nhập thành công");
                Response.Cookies.Delete(username);
                return RedirectToAction("Index", "Home"); 
            }
            else 
                return View();
        }

        public IActionResult Logout()
        {
            Response.Headers.Add("Cache-Control", "no-cache, no-store, must-revalidate");
            Response.Headers.Add("Pragma", "no-cache");
            Response.Headers.Add("Expires", "0");

            HttpContext.Session.Remove("IdUser");
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
            var user = _userService.ForgotPassword(username, license);
            if (user != null)
            {
                HttpContext.Session.SetInt32("IdUser", user.Data.Id);

                return RedirectToAction("ResetPassword", "Account");
            }
            else
            {
                _notyf.Error("Sai thông tin");
                return View();
            }

        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordDto passwordDto)
        {
            var id = HttpContext.Session.GetInt32("IdUser");
            var userData = _userService.GetUserById(id);
            if (userData != null) 
            { 
                passwordDto.IdUser = userData.Data.Id;
                passwordDto.CurrentPassword = userData.Data.Password;
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

        [HttpGet]
        public ActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ResetPassword(ChangePasswordDto passwordDto)
        {
            var id = HttpContext.Session.GetInt32("IdUser");
            var userData = _userService.GetUserById(id);

            if (userData.Data != null)
            {
                passwordDto.IdUser = userData.Data.Id;
                passwordDto.CurrentPassword = userData.Data.Password;
            }

            if (passwordDto.NewPassword == null || passwordDto.ConfirmPassword == null)
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
            if (response.Code == 99)
            {
                _notyf.Error("Mật khẩu cũ không đúng");
                return View();
            }

            if (response.IsSuccessful)
            {
                _notyf.Success("Đổi mật khẩu thành công");
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}