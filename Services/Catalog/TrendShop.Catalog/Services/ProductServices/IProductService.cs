using TrendShop.Catalog.Dtos.ProductDetails;
using TrendShop.Catalog.Dtos.ProductDtos;

namespace TrendShop.Catalog.Operations.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(string id);
        Task<GetByIdProductDto> GetByIdProductAsync(string id);
        Task<List<ResultsProductsWithCategoryDto>> GetProductsWithCategoryAsync();
        Task<List<ResultsProductsWithCategoryDto>> GetProductsWithCategoryByCategoryIdAsync(string categoryId);
    }
}

