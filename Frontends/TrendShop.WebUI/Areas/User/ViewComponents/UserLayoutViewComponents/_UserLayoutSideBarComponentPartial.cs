﻿using Microsoft.AspNetCore.Mvc;

namespace TrendShop.WebUI.Areas.User.ViewComponents.UserLayoutViewComponents
{
    public class _UserLayoutSideBarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
