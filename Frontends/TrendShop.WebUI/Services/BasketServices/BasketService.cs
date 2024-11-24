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
        {
            var values = await GetBasket(); // Sepeti getir.
            if (values != null) // Sepetin var olduğunda kontrol et.
            {
                // Aynı ürün sepette varsa
                var existingItem = values.BasketItems.FirstOrDefault(x => x.ProductID == basketItemDto.ProductID);

                if (existingItem != null)
                {
                    // Var olan ürünün miktarını artır
                    existingItem.Quantity += basketItemDto.Quantity;
                }
                else
                {
                    // Aynı ürün yoksa yeni ürünü sepete ekle
                    values.BasketItems.Add(basketItemDto);
                }
            }

            // Sepeti kaydet
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
