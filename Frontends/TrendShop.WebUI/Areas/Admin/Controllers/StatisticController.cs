using Microsoft.AspNetCore.Mvc;
using TrendShop.WebUI.Services.CommentServices;
using TrendShop.WebUI.Services.Interfaces;
using TrendShop.WebUI.Services.StatisticServices.CatalogStatisticServices;
using TrendShop.WebUI.Services.StatisticServices.DiscountStatisticServices;
using TrendShop.WebUI.Services.StatisticServices.MessageStatisticServices;
using TrendShop.WebUI.Services.StatisticServices.UserStatisticsServices;

namespace TrendShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StatisticController : Controller
    {
        private readonly ICatalogStatisticService _catalogStatisticService;
        private readonly IUserStatisticService _userStatisticService;
        private readonly IDiscountStatisticService _discountStatisticService;
        private readonly IMessageStatisticService _messageStatisticService;
        private readonly ICommentService _commentService;

        public StatisticController(ICatalogStatisticService catalogStatisticService,
            IUserStatisticService userStatisticService,
            ICommentService commentService,
            IDiscountStatisticService discountStatisticService,
            IMessageStatisticService messageStatisticService)
        {
            _catalogStatisticService = catalogStatisticService;
            _userStatisticService = userStatisticService;
            _commentService = commentService;
            _discountStatisticService = discountStatisticService;
            _messageStatisticService = messageStatisticService;
        }

        public async Task<IActionResult> Index()
        {
            StatisticList();

            var values = await _catalogStatisticService.GetBrandCount();
            ViewBag.getBrandCount = values;

            var values2 = await _catalogStatisticService.GetProductCount();
            ViewBag.getProductCount = values2;

            var values3 = await _catalogStatisticService.GetCategoryCount();
            ViewBag.getCategoryCount = values3;

            var values4 = await _catalogStatisticService.GetMaxPriceProductName();
            ViewBag.getMaxPriceProductName = values4;

            var values5 = await _catalogStatisticService.GetMinPriceProductName();
            ViewBag.getMinPriceProductName = values5;

            var values6 = await _catalogStatisticService.GetProductAvgPrice();
            ViewBag.getProductAvgPrice = values6;

            var values7 = await _catalogStatisticService.GetProductCount();
            ViewBag.getProductCount = values7;

            var values8 = await _userStatisticService.GetUserCount();
            ViewBag.getUserCount = values8;

            var values9 = await _userStatisticService.GetUserCount();
            ViewBag.getUserCount = values8;

            var values10 = await _commentService.GetTotalComment();
            ViewBag.getTotalCommentCount = values10;

            var values11 = await _commentService.GetActiveComment();
            ViewBag.getActiveCommentCount = values11;

            var values12 = await _commentService.GetPassiveComment();
            ViewBag.getPassiveCommentCount = values12;

            var values13 = await _discountStatisticService.GetDiscountCouponCount();
            ViewBag.getDiscountCouponCount = values13;

            var values14 = await _messageStatisticService.GetTotalMessageCount();
            ViewBag.getTotalMessageCount = values14;


            void StatisticList()
            {
                ViewBag.v1 = "Ana Sayfa";
                ViewBag.v2 = "İstatistikler";
                ViewBag.v3 = "İstatistik Listesi";
                ViewBag.v4 = "İstatistik Sayfası";
            }

            return View();
        }
    }
}
