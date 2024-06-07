using Dashboard.DataDto.User;
using DashBoard.Models;
using Microsoft.AspNetCore.Mvc;


namespace DashBoard.Controllers
{
    public class AccountController : Controller
    {
        TestContext _testContext = new TestContext();

        [HttpGet]
        public IActionResult Login()
        {
            return View();
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
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPassword(string username, string license)
        {
            return RedirectToAction("ResetPassword", "Account");
        }


        public IActionResult ChangePassword()
        {
            return View();
        }
    }
}
