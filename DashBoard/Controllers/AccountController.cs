using Dashboard.DataDto.User;
using DashBoard.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        public IActionResult Login(LoginDto login)
        {
            if (ModelState.IsValid)
            {
               
                return RedirectToAction("Index", "Home");
            }
            return View();
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
