using Microsoft.AspNetCore.Mvc;
using TrendShop.DtoLayer.BasketDtos;
using TrendShop.WebUI.Services.BasketServices;
using TrendShop.WebUI.Services.CatalogServices.ProductServices;
using TrendShop.WebUI.Services.DiscountServices;

namespace TrendShop.WebUI.Controllers
{
    public class ShoppingCardController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;

        public ShoppingCardController(IProductService productService, IBasketService basketService)
        {
            _productService = productService;
            _basketService = basketService;
        }

        //public async Task<IActionResult> Index(string code, int discountRate, decimal totalNewPriceWithDiscount)
        //{
        //    ViewBag.code = code;
        //    ViewBag.discountRate = discountRate;
        //    ViewBag.totalNewPriceWithDiscount = totalNewPriceWithDiscount;
        //    ViewBag.directory1 = "Ana Sayfa";
        //    ViewBag.directory2 = "Ürünler";
        //    ViewBag.directory3 = "Sepetim";
        //    var values = await _basketService.GetBasket();
        //    ViewBag.total = values.TotalPrice;
        //    var totalPriceWithTax = values.TotalPrice + values.TotalPrice / 100 * 10;
        //    var tax = values.TotalPrice / 100 * 10;
        //    ViewBag.totalPriceWithTax = totalPriceWithTax;
        //    ViewBag.tax = tax;
        //    return View();

        //}

        public async Task<IActionResult> Index(string code, int discountRate, decimal totalNewPriceWithDiscount)
        {
            // ViewBag ile gelen veriler
            ViewBag.code = code;
            ViewBag.discountRate = discountRate;
            ViewBag.totalNewPriceWithDiscount = totalNewPriceWithDiscount;
            ViewBag.directory1 = "Ana Sayfa";
            ViewBag.directory2 = "Ürünler";
            ViewBag.directory3 = "Sepetim";

            // Sepet verilerini al
            var values = await _basketService.GetBasket();

            // Sepet toplam fiyatı
            decimal totalPrice = values.TotalPrice;
            ViewBag.total = totalPrice;

            // KDV hesapla (%10)
            decimal tax = totalPrice / 100 * 10;
            decimal totalPriceWithTax = totalPrice + tax;

            // KDV ve toplam fiyatı ViewBag'e ekle
            ViewBag.totalPriceWithTax = totalPriceWithTax;
            ViewBag.tax = tax;

            // Session'dan indirimli tutarı al
            var discountedTotal = HttpContext.Session.GetString("DiscountedTotal");

            // Eğer session'da indirimli fiyat varsa, bunu kullan
            if (!string.IsNullOrEmpty(discountedTotal))
            {
                // Kupon kodu uygulandı, indirimli fiyatı kullan
                ViewBag.DiscountedTotal = decimal.Parse(discountedTotal);
            }
            else
            {
                // Kupon kodu uygulanmadıysa, normal fiyatı kullan
                ViewBag.DiscountedTotal = totalPriceWithTax;
            }

            // Eğer kupon kodu varsa ve geçerliyse indirim uygula
            if (!string.IsNullOrEmpty(code) && discountRate > 0)
            {
                // Kupon kodunun geçerli olduğunu varsayalım
                decimal discountedPrice = totalPrice - (totalPrice * discountRate / 100);
                decimal discountedPriceWithTax = discountedPrice + (discountedPrice / 100 * 10); // KDV ekle

                // İndirimli tutarı session'a kaydet
                HttpContext.Session.SetString("DiscountedTotal", discountedPriceWithTax.ToString());

                // ViewBag ile indirimli fiyatı gönder
                ViewBag.DiscountedTotal = discountedPriceWithTax;
            }

            return View();
        }

        public async Task<IActionResult> AddBasketItem(string id)
        {
            var values = await _productService.GetByIdProductAsync(id);
            var items = new BasketItemDto
            {
                ProductID = values.ProductID,
                ProductName = values.ProductName,
                Price = values.ProductPrice,
                Quantity = 1,
                ProductImageUrl = values.ProductImageUrl
            };
            await _basketService.AddBasketItem(items);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveBasketItem(string id)
        {
            await _basketService.RemoveBasketItem(id);
            return RedirectToAction("Index");
        }

        public async Task UpdateBasketItemQuantity(string productId, int quantity)
        {
            var basket = await _basketService.GetBasket(); // Mevcut sepeti getir
            var itemToUpdate = basket.BasketItems.FirstOrDefault(x => x.ProductID == productId);

            if (itemToUpdate != null)
            {
                itemToUpdate.Quantity = quantity; // Miktarı güncelle
                await _basketService.SaveBasket(basket); // Sepeti kaydet
            }
        }


    }
}
