﻿using Microsoft.AspNetCore.Mvc;

namespace TrendShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListGetProductCountComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
