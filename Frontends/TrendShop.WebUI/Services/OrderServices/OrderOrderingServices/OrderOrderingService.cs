using Newtonsoft.Json;
using TrendShop.DtoLayer.OrderDtos.OrderOrderingDtos;
using TrendShop.WebUI.Services.OrderServices.OrderOrderingServices;

namespace TrendShop.WebUI.Services.OrderServices.OrderOderingServices
{
    public class OrderOderingService : IOrderOderingService
    {
        private readonly HttpClient _httpClient;
        public OrderOderingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<ResultOrderingByUserIdDto>> GetOrderingByUserId(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"orderings/GetOrderingByUserId/{id}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultOrderingByUserIdDto>>(jsonData);
            return values;
        }
    }
}