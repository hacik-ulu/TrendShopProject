﻿using Microsoft.AspNetCore.Mvc;
using TrendShop.WebUI.Services.BasketServices;
using TrendShop.WebUI.Services.DiscountServices;

namespace TrendShop.WebUI.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;
        private readonly IBasketService _basketService;
        public DiscountController(IDiscountService discountService, IBasketService basketService)
        {
            _discountService = discountService;
            _basketService = basketService;
        }

        [HttpGet]
        public PartialViewResult ConfirmDiscountCoupon()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDiscountCoupon(string code)
        {
            var values = await _discountService.GetDiscountCouponCountRate(code);

            var basketValues = await _basketService.GetBasket();
            var totalPriceWithTax = basketValues.TotalPrice + basketValues.TotalPrice / 100 * 10;

            var totalNewPriceWithDiscount = totalPriceWithTax - (totalPriceWithTax / 100 * values);

            HttpContext.Session.SetString("DiscountedTotal", totalNewPriceWithDiscount.ToString("F2"));

            return RedirectToAction("Index", "ShoppingCard", new { code = code, discountRate = values, totalNewPriceWithDiscount = totalNewPriceWithDiscount });
        }
    }
}
