using Microsoft.AspNetCore.Mvc;
using TrendShop.DtoLayer.CatalogDtos.AboutDtos;
using TrendShop.WebUI.Services.CatalogServices.AboutServices;

namespace TrendShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/About")]
    public class AboutController : Controller
    {
        private readonly IAboutService _AboutService;
        public AboutController(IAboutService AboutService)
        {
            _AboutService = AboutService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            AboutViewbagList();
            var values = await _AboutService.GetAllAboutAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreateAbout")]
        public IActionResult CreateAbout()
        {
            CreateAboutViewbagList();
            return View();
        }

        [HttpPost]
        [Route("CreateAbout")]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            await _AboutService.CreateAboutAsync(createAboutDto);
            return RedirectToAction("Index", "About", new { area = "Admin" });
        }

        [Route("DeleteAbout/{id}")]
        public async Task<IActionResult> DeleteAbout(string id)
        {
            await _AboutService.DeleteAboutAsync(id);
            return RedirectToAction("Index", "About", new { area = "Admin" });
        }

        [Route("UpdateAbout/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateAbout(string id)
        {
            UpdateAboutViewbagList();
            var values = await _AboutService.GetByIdAboutAsync(id);
            return View(values);
        }
        
        [Route("UpdateAbout/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            await _AboutService.UpdateAboutAsync(updateAboutDto);
            return RedirectToAction("Index", "About", new { area = "Admin" });
        }

        void AboutViewbagList()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Hakkımda";
            ViewBag.v3 = "Hakkımda Listesi";
            ViewBag.v4 = "Hakkımda İşlemleri";
        }
        void CreateAboutViewbagList()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Hakkımda";
            ViewBag.v3 = "Hakkımda Ekleme Sayfası";
            ViewBag.v4 = "Hakkımda İşlemleri";
        }
        void UpdateAboutViewbagList()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Hakkımda";
            ViewBag.v3 = "Hakkımda Güncelleme Sayfası";
            ViewBag.v4 = "Hakkımda İşlemleri";
        }
    }
}