using Microsoft.AspNetCore.Mvc;

namespace TrendShop.WebUI.Areas.User.Controllers
{
    public class LogOutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
