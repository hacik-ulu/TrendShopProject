using Microsoft.AspNetCore.Mvc;
using TrendShop.DtoLayer.BasketDtos;
using TrendShop.DtoLayer.OrderDtos.OrderAddressDtos;
using TrendShop.WebUI.Services.BasketServices;
using TrendShop.WebUI.Services.Interfaces;
using TrendShop.WebUI.Services.OrderServices.OrderAddressServices;

namespace TrendShop.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderAddressService _orderAddressService;
        private readonly IUserService _userService;
        private readonly IBasketService _basketService;

        public OrderController(IOrderAddressService orderAddressService, IUserService userService, IBasketService basketService)
        {
            _orderAddressService = orderAddressService;
            _userService = userService;
            _basketService = basketService;
        }

        //[HttpGet]
        //public ActionResult Index()
        //{
        //    ViewBag.directory1 = "TrendShop";
        //    ViewBag.directory2 = "İletişim";
        //    ViewBag.directory3 = "Sipariş İşlemleri";

        //    return View();
        //}

        public async Task<IActionResult> Index(string code, int discountRate, decimal totalNewPriceWithDiscount)
        {
            ViewBag.code = code;
            ViewBag.discountRate = discountRate;
            ViewBag.totalNewPriceWithDiscount = totalNewPriceWithDiscount;
            ViewBag.directory1 = "Ana Sayfa";
            ViewBag.directory2 = "Ürünler";
            ViewBag.directory3 = "Sepetim";

            var values = await _basketService.GetBasket();

            decimal totalPrice = values.TotalPrice;
            ViewBag.total = totalPrice;

            decimal tax = totalPrice / 100 * 10;
            decimal totalPriceWithTax = totalPrice + tax;

            ViewBag.totalPriceWithTax = totalPriceWithTax;
            ViewBag.tax = tax;

            decimal shippingFee = 30.00m; 
            ViewBag.ShippingFee = shippingFee;

            var discountedTotalString = HttpContext.Session.GetString("DiscountedTotal");

            decimal discountedTotal = 0;
            bool isCouponApplied = false;

            if (!string.IsNullOrEmpty(discountedTotalString) && decimal.TryParse(discountedTotalString, out discountedTotal))
            {
                isCouponApplied = discountedTotal < totalPrice;
                ViewBag.DiscountedTotal = discountedTotal;
            }
            else
            {
                ViewBag.DiscountedTotal = totalPriceWithTax;
            }

            var basketItems = values.BasketItems.Select(item => new BasketItemDto
            {
                ProductName = item.ProductName,
                Price = item.Price,
                Quantity = item.Quantity
            }).ToList();

            ViewBag.BasketItems = basketItems;

            var totalPriceWithTaxAndShipping = totalPriceWithTax + shippingFee;
            ViewBag.totalPriceWithTaxAndShipping = totalPriceWithTaxAndShipping;
            return View();
        }




        [HttpPost]
        public async Task<IActionResult> Index(CreateOrderAddressDto createOrderAddressDto)
        {
            var values = await _userService.GetUserInfo();
            createOrderAddressDto.UserID = values.Id;
            await _orderAddressService.CreateOrderAddressAsync(createOrderAddressDto);
            return RedirectToAction("Index", "Payment");
        }
    }
}
