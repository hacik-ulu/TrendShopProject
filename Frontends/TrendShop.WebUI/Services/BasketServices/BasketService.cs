using TrendShop.DtoLayer.BasketDtos;

namespace TrendShop.WebUI.Services.BasketServices
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;
        public BasketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddBasketItem(BasketItemDto basketItemDto)
        { //Any --> en az bir öğe içerip içermediğini kontrol eder.

            var values = await GetBasket(); // sepet getirilecek.
            if (values != null) // sepetin var olduğunda dair kontrol
            {
                // Aynı ürün yoksa if çalışır
                if (!values.BasketItems.Any(x => x.ProductID == basketItemDto.ProductID))
                {
                    values.BasketItems.Add(basketItemDto);
                }
                else // aynı ürün varsa else çalışır.
                {
                    values = new BasketTotalDto(); // sepet sıfırlanır.
                    values.BasketItems.Add(basketItemDto);
                }

            }
            await SaveBasket(values);
        }

        public Task DeleteBasket(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<BasketTotalDto> GetBasket() // userId token'dan gelecek.
        {
            var responseMessage = await _httpClient.GetAsync("baskets");
            var values = await responseMessage.Content.ReadFromJsonAsync<BasketTotalDto>();
            return values;

        }

        public async Task<bool> RemoveBasketItem(string productId)
        {
            var values = await GetBasket();
            var deletedItem = values.BasketItems.FirstOrDefault(x => x.ProductID == productId);
            var result = values.BasketItems.Remove(deletedItem);
            await SaveBasket(values);
            return true;
        }

        public async Task SaveBasket(BasketTotalDto basketTotalDto)
        {
            await _httpClient.PostAsJsonAsync<BasketTotalDto>("baskets", basketTotalDto);
        }
    }
}
