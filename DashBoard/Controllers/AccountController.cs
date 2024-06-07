using DashBoard.Services.IService;
using DataAccess.Base;
using DataAccess.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
        public ActionResult Login(string username, string password, string? check)
        {
            ResponseBase<User?> response = _service.Login(username, password);
            if (response.Data == null)
            {
                if(response.Code == (int)HttpStatusCode.NotFound)
                {
                    ViewData["message"] = response.Message;
                    return View();
                }
                ViewData["error"] = response.Message;
                return View("/Views/Shared/Error.cshtml");
            }
            HttpContext.Session.SetInt32("userId", response.Data.Id);
            // if remember account
            if (check != null)
            {
                CookieOptions options = new CookieOptions()
                {
                    Expires = DateTime.Now.AddDays(7)
                };
                Response.Cookies.Append("userId", response.Data.Id.ToString(), options);
            }
            return Redirect("/Home/Index");
        }


        public IActionResult Logout()
        {
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

       /* [HttpPost]
        public IActionResult ForgotPassword(string username, string license)
        {
            var user = _testContext.Users.Where(x => x.UserName.Equals(username) && x.License.Equals(license)).FirstOrDefault();
            if (user != null)
            {
                return RedirectToAction("ResetPassword", "Account");
            }
            return View();
        }*/

        public IActionResult ResetPassword()
        {
            return View();
        }
    }
}
