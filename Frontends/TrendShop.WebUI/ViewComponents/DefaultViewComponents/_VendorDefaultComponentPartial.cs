using Microsoft.AspNetCore.Mvc;

namespace TrendShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _VendorDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
