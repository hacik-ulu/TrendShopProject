using Microsoft.AspNetCore.Mvc;

namespace TrendShop.WebUI.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.directory1 = "TrendShop";
            ViewBag.directory2 = "İletişim";
            ViewBag.directory3 = "Sipariş İşlemleri";
            return View();
        }
    }
}
