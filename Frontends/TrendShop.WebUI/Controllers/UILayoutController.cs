using Microsoft.AspNetCore.Mvc;

namespace TrendShop.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult _UILayout()
        {
            return View();
        }
    }
}
