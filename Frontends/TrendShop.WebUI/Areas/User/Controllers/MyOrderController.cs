using Microsoft.AspNetCore.Mvc;
using TrendShop.WebUI.Services.Interfaces;
using TrendShop.WebUI.Services.OrderServices.OrderOrderingServices;

namespace TrendShop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class MyOrderController : Controller
    {
        private readonly IUserService _userService;
        private readonly IOrderOderingService _orderingService;
        public MyOrderController(IOrderOderingService orderingService, IUserService userService)
        {
            _orderingService = orderingService;
            _userService = userService;
        }

        public async Task<IActionResult> MyOrderList()
        {
            var user = await _userService.GetUserInfo();
            var values = await _orderingService.GetOrderingByUserId(user.Id);
            return View(values);
        }
    }
}
