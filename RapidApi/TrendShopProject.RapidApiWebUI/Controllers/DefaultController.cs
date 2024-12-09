using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
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
        public async Task<IActionResult> Exchange()
        {
            var client = new HttpClient();

            // USD to TRY 
            var usdRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://real-time-finance-data.p.rapidapi.com/currency-exchange-rate?from_symbol=USD&to_symbol=TRY&language=en"),
                Headers =
        {
            { "x-rapidapi-key", "386093d10emsh01d48a3373a6db1p1a4f26jsneb4b38e20954" },
            { "x-rapidapi-host", "real-time-finance-data.p.rapidapi.com" },
        },
            };

            // EUR to TRY exchange request
            var eurRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://real-time-finance-data.p.rapidapi.com/currency-exchange-rate?from_symbol=EUR&to_symbol=TRY&language=en"),
                Headers =
        {
            { "x-rapidapi-key", "386093d10emsh01d48a3373a6db1p1a4f26jsneb4b38e20954" },
            { "x-rapidapi-host", "real-time-finance-data.p.rapidapi.com" },
        },
            };

            // Initialize response variables
            dynamic usdResponseData = null;
            dynamic eurResponseData = null;

            try
            {
                // USD request
                using (var usdResponse = await client.SendAsync(usdRequest))
                {
                    usdResponse.EnsureSuccessStatusCode();
                    var usdBody = await usdResponse.Content.ReadAsStringAsync();
                    usdResponseData = JsonConvert.DeserializeObject<ExchangeViewModel.Rootobject>(usdBody);
                }

                // EUR request
                using (var eurResponse = await client.SendAsync(eurRequest))
                {
                    eurResponse.EnsureSuccessStatusCode();
                    var eurBody = await eurResponse.Content.ReadAsStringAsync();
                    eurResponseData = JsonConvert.DeserializeObject<ExchangeViewModel.Rootobject>(eurBody);
                }

                ViewBag.UsdExchangeRate = usdResponseData.data.exchange_rate;
                ViewBag.UsdPreviousClose = usdResponseData.data.previous_close;

                ViewBag.EurExchangeRate = eurResponseData.data.exchange_rate;
                ViewBag.EurPreviousClose = eurResponseData.data.previous_close;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching exchange rates: {ex.Message}");
                return StatusCode(500, "Error fetching exchange rates.");
            }

            return View();
        }


    }
}
