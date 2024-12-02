using Microsoft.AspNetCore.Mvc;
using TrendShop.WebUI.Services.CargoServices.CargoCustomerServices;
using TrendShop.WebUI.Services.UserIdentityServices;

namespace TrendShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserIdentityService _userIdentityService;
        private readonly ICargoCustomerService _cargoCustomerService;
        public UserController(IUserIdentityService userIdentityService, ICargoCustomerService cargoCustomerService)
        {
            _userIdentityService = userIdentityService;
            _cargoCustomerService = cargoCustomerService;
        }

        public async Task<IActionResult> UserList()
        {
            UserListViewbagList();
            var values = await _userIdentityService.GetAllUserListAsync();
            return View(values);
        }


        public async Task<IActionResult> UserAddressInfo(string id)
        {
            var values = await _cargoCustomerService.GetByIdCargoCustomerInfoAsync(id);
            return View(values);
        }



        void UserListViewbagList()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Kullanıcılar";
            ViewBag.v3 = "Kullanıcı Listesi";
            ViewBag.v4 = "Kullanıcı Sayfası";
        }
    }
}
