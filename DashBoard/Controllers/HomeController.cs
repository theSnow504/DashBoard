﻿using AspNetCoreHero.ToastNotification.Abstractions;
using Dashboard.DataDto.User;
using Dashboard.Service.Api.Actions;
using Dashboard.Service.Api.Users;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DashBoard.Controllers
{
    public class HomeController : Controller
    {
        private readonly INotyfService _notyf;
        private readonly IUsersApiServices _userService;
        private readonly IActionServices _actionService;


        public HomeController(IUsersApiServices userService, INotyfService notyf,IActionServices actionServices)
        {
            _userService = userService;
            _notyf = notyf;
            _actionService = actionServices;
        }
        [ResponseCache(NoStore = true, Duration = 0, VaryByHeader = "none")]
        public IActionResult Index()
        {
            var id = HttpContext.Session.GetInt32("IdUser");
            if (id !=null)
            {
                var user = _userService.GetUserById(id);
                if (user != null)
                {
                    return View(user.Data);
                }
                return View();
            } 
            else return RedirectToAction("Login","Account");
        }

        public IActionResult LoadFacebookPartial(int iduser)
        {
            var accounts = _userService.GetAccountFbEverLogin(iduser);
            return PartialView("_AccountFacebook", accounts.Data);
        }

        public IActionResult LoadTiktokPartial()
        {
            return PartialView("_AccountTiktok");
        }

        public IActionResult LoadYoutubePartial()
        {
            return PartialView("_AccountYoutube");
        }
        public IActionResult LoadClientPartial(int iduser)
        {
            var accounts = _userService.GetAccountEverLogin(iduser);
            return PartialView("_AccountClient", accounts.Data);
        }
        public IActionResult GetActionHistory(int iduser)
        {
            var accounts = _actionService.GetActionHistory(iduser);
            return PartialView("_AccountClient", accounts.Data);
        }
    }
}