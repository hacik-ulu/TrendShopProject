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

            // JSON verisini logla
            Console.WriteLine($"Retrieved JSON: {existBasket}");

            if (string.IsNullOrEmpty(existBasket))
            {
                // Handle case where basket does not exist
                return null; // Or throw an appropriate exception
            }

            try
            {
                return JsonSerializer.Deserialize<BasketTotalDto>(existBasket);
            }
            catch (JsonException ex)
            {
                // Log the exception
                Console.WriteLine($"Deserialization error: {ex.Message}");
                throw;
            }
        }

        public async Task SaveBasket(BasketTotalDto basketTotalDto)
        {
            await _redisService.GetDb().StringSetAsync(basketTotalDto.UserID, JsonSerializer.Serialize(basketTotalDto));
        }

        
    }
}
