﻿using Microsoft.AspNetCore.Mvc;
using TrendShop.WebUI.Services.CatalogServices.ProductServices;

namespace TrendShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;
        public _ProductListComponentPartial(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _productService.GetProductsWithCategoryByCategoryIdAsync(id);
            return View(values);
        }
    }
}