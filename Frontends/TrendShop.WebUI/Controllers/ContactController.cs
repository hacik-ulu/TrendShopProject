using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Xml.Linq;
using TrendShop.DtoLayer.CatalogDtos.ContactDtos;
using TrendShop.WebUI.Services.CatalogServices.ContactServices;

namespace TrendShop.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.directory1 = "TrendShop";
            ViewBag.directory2 = "İletişim";
            ViewBag.directory3 = "Bize Ulaşın";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto createContactDto)
        {
            createContactDto.IsRead = false;
            createContactDto.SendDate = DateTime.Now;
            await _contactService.CreateContactAsync(createContactDto);
            return RedirectToAction("Index", "Default");
        }
    }
}
