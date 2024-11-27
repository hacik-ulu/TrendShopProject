using TrendShop.DtoLayer.OrderDtos.OrderOrderingDtos;

namespace TrendShop.WebUI.Services.OrderServices.OrderOrderingServices
{
    public interface IOrderOderingService
    {
        Task<List<ResultOrderingByUserIdDto>> GetOrderingByUserId(string id);
    }
}