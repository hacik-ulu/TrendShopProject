using Microsoft.AspNetCore.Mvc;

namespace TrendShop.WebUI.ViewComponents.ShoppingCardViewComponents
{
    public class _ShoppingCardProductListComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
