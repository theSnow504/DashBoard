using Dashboard.DataDto.User;
using DashBoard.Models;
using Microsoft.AspNetCore.Mvc;

namespace DashBoard.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _service;
        public AccountController(IAccountService service)
        {
            _service = service;
        }


        [HttpGet]
        public ActionResult Login()
        {
            string? userId = Request.Cookies["userId"];
            if (userId == null) 
            {
                return View();
            }
            ResponseBase<User?> response = _service.Login(userId);
            if (response.Data == null)
            {
                ViewData["error"] = response.Message;
                return View("/Views/Shared/Error.cshtml");
            }
            HttpContext.Session.SetInt32("userId", response.Data.Id);
            return Redirect("/Home/Index");
        }

        [HttpPost]
        public IActionResult Login(LoginDto login)
        {

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("User");
            return RedirectToAction("Login", "Account");
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


        public IActionResult ChangePassword()
            ResponseBase<User?> response = _service.ForgotPassword(username, license);
            if(response.Data == null)
            {
                if (response.Code == (int)HttpStatusCode.NotFound)
                {
                    ViewData["error"] = response.Message;
                    return View();
                }
                ViewData["error"] = response.Message;
                return View("/Views/Shared/Error.cshtml");
            }
           
            return Redirect("/Account/ResetPassword");
        }

        public ActionResult ResetPassword()
        {
            return View();
        }
    }
}
