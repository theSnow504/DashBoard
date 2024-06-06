using Microsoft.AspNetCore.Mvc;

namespace DashBoard.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            return View();
        }


        public IActionResult Logout()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPassword(string username, string license)
        {
            return View();
        }

        public IActionResult ResetPassword()
        {
            return View();
        }
    }
}
