using TrendShop.DtoLayer.BasketDtos;

namespace TrendShop.WebUI.Services.BasketServices
{
    public interface IBasketService
    {
        Task<BasketTotalDto> GetBasket(); // userId'ye göre sepetin içeriği(sepetin tümünü) getirilecek.
        Task SaveBasket(BasketTotalDto basketTotalDto); // Sepetteki değişiklikler kaydedilecek.(Card Summary kısmı)
        Task DeleteBasket(string userId); // Komple sepetin tamamı silinecek.
        Task AddBasketItem(BasketItemDto basketItemDto); // Sepet içerisine öğe eklenecek.
        Task<bool> RemoveBasketItem(string productId); // Sepetteki öğelerin remove/silme işlemi için kullanılacak.

    }
}
