using TrendShop.DtoLayer.CatalogDtos.FeatureSliderDtos;

namespace TrendShop.WebUI.Services.CatalogServices.FeatureSliderServices
{
    public interface IFeatureSliderService
    {
        Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync();
        Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto);
        Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto);
        Task DeleteFeatureSliderAsync(string id);
        Task<UpdateFeatureSliderDto> GetByIdFeatureSliderAsync(string id);
       
    }
}
