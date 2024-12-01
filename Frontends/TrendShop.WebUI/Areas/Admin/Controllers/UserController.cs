using Microsoft.AspNetCore.Mvc;
using TrendShop.WebUI.Services.UserIdentityServices;

namespace TrendShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserIdentityService _userIdentityService;
        public UserController(IUserIdentityService userIdentityService)
        {
            _userIdentityService = userIdentityService;
        }

        public async Task<IActionResult> UserList()
        {
            UserListViewbagList();
            var values = await _userIdentityService.GetAllUserListAsync();
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
