using Microsoft.AspNetCore.Mvc;

namespace TrendShop.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.directory1 = "TrendShop";
            ViewBag.directory2 = "Ana Sayfa";
            ViewBag.directory3 = "Ürün Listesi";
            return View();
        }
    }
}
