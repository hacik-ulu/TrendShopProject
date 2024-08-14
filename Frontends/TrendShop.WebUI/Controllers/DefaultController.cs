using Microsoft.AspNetCore.Mvc;

namespace TrendShop.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
