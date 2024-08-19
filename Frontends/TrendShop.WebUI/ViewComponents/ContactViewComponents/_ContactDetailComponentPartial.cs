using Microsoft.AspNetCore.Mvc;

namespace TrendShop.WebUI.ViewComponents.ContactViewComponents
{
    public class _ContactDetailComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
