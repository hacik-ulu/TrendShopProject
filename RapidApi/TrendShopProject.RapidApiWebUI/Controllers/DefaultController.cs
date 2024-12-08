using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using TrendShopProject.RapidApiWebUI.Models;


namespace TrendShopProject.RapidApiWebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IMemoryCache _cache;

        public DefaultController(IMemoryCache cache)
        {
            _cache = cache;
        }

        public async Task<IActionResult> WeatherDetail()
        {
            string cacheKey = "WeatherDetail_Ankara";
            WeatherViewModel.Rootobject weatherData;

            if (!_cache.TryGetValue(cacheKey, out weatherData))
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri("https://weather-api-by-any-city.p.rapidapi.com/weather/Ankara"),
                    Headers =
                {
                    { "x-rapidapi-key", "386093d10emsh01d48a3373a6db1p1a4f26jsneb4b38e20954" },
                    { "x-rapidapi-host", "weather-api-by-any-city.p.rapidapi.com" },
                },
                };

                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    weatherData = JsonConvert.DeserializeObject<WeatherViewModel.Rootobject>(body);

                    // Veriyi önbelleğe ekle
                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromMinutes(10)); 
                    _cache.Set(cacheKey, weatherData, cacheEntryOptions);
                }
            }

            ViewBag.cityTemp = weatherData.current.feelslike_c;
            return View(weatherData);
        }
    }
}
