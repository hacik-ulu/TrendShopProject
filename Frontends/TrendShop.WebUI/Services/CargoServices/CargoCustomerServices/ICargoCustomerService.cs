using TrendShop.DtoLayer.CargoDtos.CargoCustomerDtos;

namespace TrendShop.WebUI.Services.CargoServices.CargoCustomerServices
{
    public interface ICargoCustomerService
    {
        Task<GetCargoCustomerByIdDto> GetByIdCargoCustomerInfoAsync(string id);

    }
}
