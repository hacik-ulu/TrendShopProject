using Microsoft.AspNetCore.Mvc;
using TrendShop.DtoLayer.OrderDtos.OrderAddressDtos;
using TrendShop.WebUI.Services.Interfaces;
using TrendShop.WebUI.Services.OrderServices.OrderAddressServices;

namespace TrendShop.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderAddressService _orderAddressService;
        private readonly IUserService _userService;
        public OrderController(IOrderAddressService orderAddressService, IUserService userService)
        {
            _orderAddressService = orderAddressService;
            _userService = userService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.directory1 = "TrendShop";
            ViewBag.directory2 = "İletişim";
            ViewBag.directory3 = "Sipariş İşlemleri";

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
