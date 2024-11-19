﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TrendShop.DtoLayer.CatalogDtos.CategoryDtos;
using TrendShop.WebUI.Services.CatalogServices.CategoryServices;

namespace TrendShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _CategoriesDefaultComponentPartial : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        public _CategoriesDefaultComponentPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _categoryService.GetAllCategoryAsync();
            return View(values);
        }
    }
}
