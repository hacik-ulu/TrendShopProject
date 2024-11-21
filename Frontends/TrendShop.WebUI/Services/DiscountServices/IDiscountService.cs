using TrendShop.DtoLayer.DiscountDtos;

namespace TrendShop.WebUI.Services.DiscountServices
{
    public interface IDiscountService
    {
        // Kupon kodu verilip İndirim kodu detaylarıyla birlikte getirilecek.
        Task<GetDiscountCodeDetailByCode> GetDiscountCode(string code);
    }
}
