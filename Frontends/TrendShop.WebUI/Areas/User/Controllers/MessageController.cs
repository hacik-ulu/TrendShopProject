using Microsoft.AspNetCore.Mvc;

namespace TrendShop.WebUI.Areas.User.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
