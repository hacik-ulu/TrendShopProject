﻿using Microsoft.AspNetCore.Mvc;

namespace TrendShop.WebUI.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}