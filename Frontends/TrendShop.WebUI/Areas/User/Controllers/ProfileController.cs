﻿using Microsoft.AspNetCore.Mvc;

namespace TrendShop.WebUI.Areas.User.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
