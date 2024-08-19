using Microsoft.AspNetCore.Mvc;

namespace TrendShop.WebUI.Controllers
{
    public class ShoppingCardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
