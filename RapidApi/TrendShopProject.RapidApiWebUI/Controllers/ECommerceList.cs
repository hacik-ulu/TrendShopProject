using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TrendShopProject.RapidApiWebUI.Models;

namespace TrendShopProject.RapidApiWebUI.Controllers
{
    public class ECommerceList : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://real-time-product-search.p.rapidapi.com/search-v2?q=Nike%20shoes&country=us&language=en&page=1&limit=10&sort_by=BEST_MATCH&product_condition=ANY"),
                Headers =
    {
        { "x-rapidapi-key", "386093d10emsh01d48a3373a6db1p1a4f26jsneb4b38e20954" },
        { "x-rapidapi-host", "real-time-product-search.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ECommerceViewModel>(body);
                return View(values.data);
            }
        }
    }
}
