using TrendShop.DtoLayer.BasketDtos;

namespace TrendShop.WebUI.Services.BasketServices
{
    public interface IBasketService
    {
        Task<BasketTotalDto> GetBasketTotal(string userId); // Sepete veri getirmek.
        Task SaveBasket(BasketTotalDto basketTotalDto); // Sepetteki değişiklikleri kaydetmek.
        Task DeleteBasket(string userId);
    }
}
