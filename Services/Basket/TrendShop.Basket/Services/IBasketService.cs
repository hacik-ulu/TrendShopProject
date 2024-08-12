using TrendShop.Basket.Dtos;

namespace TrendShop.Basket.Services
{
    public interface IBasketService
    {
        Task<BasketTotalDto> GetBasketTotal(string userId);
        Task SaveBasket(BasketTotalDto basketTotalDto);
        Task DeleteBasket(string userId);
    }
}
