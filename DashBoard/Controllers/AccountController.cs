using Dashboard.DataDto.User;
using Microsoft.AspNetCore.Mvc;

namespace DashBoard.Controllers
{
    public class AccountController : Controller
    {    
        [HttpGet]
        public ActionResult Login()
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


        public IActionResult ChangePassword() 
        { 
            return View(); 
        }

        public ActionResult ResetPassword()
        {
            return View();
        }
    }
}
