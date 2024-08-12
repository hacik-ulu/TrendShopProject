using System.Text.Json;
using TrendShop.Basket.Dtos;
using TrendShop.Basket.Settings;

namespace TrendShop.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task DeleteBasket(string userId)
        {
            await _redisService.GetDb().KeyDeleteAsync(userId);
        }

        public async Task<BasketTotalDto> GetBasketTotal(string userId)
        {
            var existBasket = await _redisService.GetDb().StringGetAsync(userId);
            // existBasketten gelen json verilerini BasketTotalDto'ya dönüştürür, deserilize eder.
            return JsonSerializer.Deserialize<BasketTotalDto>(existBasket);
        }

        public async Task SaveBasket(BasketTotalDto basketTotalDto)
        {
            await _redisService.GetDb().StringSetAsync(basketTotalDto.UserID, JsonSerializer.Serialize(basketTotalDto));
        }
    }
}
