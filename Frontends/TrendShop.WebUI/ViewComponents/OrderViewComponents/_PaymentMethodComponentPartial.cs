using Microsoft.AspNetCore.Mvc;

namespace TrendShop.WebUI.ViewComponents.OrderViewComponents
{
    public class _PaymentMethodComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
