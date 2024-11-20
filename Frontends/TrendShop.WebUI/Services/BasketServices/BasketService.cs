using TrendShop.DtoLayer.BasketDtos;

namespace TrendShop.WebUI.Services.BasketServices
{
    public class BasketService : IBasketService
    {
        public Task DeleteBasket(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<BasketTotalDto> GetBasketTotal(string userId)
        {
            throw new NotImplementedException();
        }

        public Task SaveBasket(BasketTotalDto basketTotalDto)
        {
            throw new NotImplementedException();
        }
    }
}
