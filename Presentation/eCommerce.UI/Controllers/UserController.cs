﻿using Microsoft.AspNetCore.Mvc;

namespace eCommerce.UI.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SignIn()
        {
            return View();
        }
    }
}
