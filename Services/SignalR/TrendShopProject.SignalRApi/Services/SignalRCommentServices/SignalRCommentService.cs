using Newtonsoft.Json;
using TrendShopProject.SignalRApi.Services.SignalRCommentServices;

namespace TrendShopProject.SignalApi.Services.SignalRCommentServices
{
    public class SignalRCommentService : ISignalRCommentService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public SignalRCommentService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<int> GetTotalCommentCount()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:7212/api/CommentStatistics");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var commentCount = JsonConvert.DeserializeObject<int>(jsonData);
            return commentCount;
        }
    }
}