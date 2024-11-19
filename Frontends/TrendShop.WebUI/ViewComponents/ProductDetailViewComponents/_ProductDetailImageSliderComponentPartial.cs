using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TrendShop.DtoLayer.CatalogDtos.ProductImageDtos;
using TrendShop.WebUI.Services.CatalogServices.ProductImageServices;

namespace TrendShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailImageSliderComponentPartial : ViewComponent
    {
        private readonly IProductImageService _productImageService;
        public _ProductDetailImageSliderComponentPartial(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _productImageService.GetByProductIdProductImageAsync(id);
            return View(values);
        }
    }
}
