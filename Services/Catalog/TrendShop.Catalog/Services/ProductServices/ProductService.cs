using AutoMapper;
using MongoDB.Driver;
using TrendShop.Catalog.Dtos.ProductDetails;
using TrendShop.Catalog.Dtos.ProductDtos;
using TrendShop.Catalog.Entities;
using TrendShop.Catalog.Settings;

namespace TrendShop.Catalog.Operations.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var values = _mapper.Map<Product>(createProductDto);
            await _productCollection.InsertOneAsync(values);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productCollection.DeleteOneAsync(x => x.ProductID == id);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values);
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var value = await _productCollection.Find<Product>(x => x.ProductID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDto>(value);
        }

        public async Task<List<ResultsProductsWithCategoryDto>> GetProductsWithCategoryAsync()
        {
            var products = await _productCollection.Find(x => true).ToListAsync();
            var results = new List<ResultsProductsWithCategoryDto>();

            foreach (var product in products)
            {
                var category = await _categoryCollection.Find(c => c.CategoryID == product.CategoryID).FirstOrDefaultAsync();
                var productWithCategory = new ResultsProductsWithCategoryDto
                {
                    ProductID = product.ProductID,
                    ProductName = product.ProductName,
                    ProductPrice = product.ProductPrice,
                    ProductDescription = product.ProductDescription,
                    ProductImageUrl = product.ProductImageUrl,
                    CategoryID = product.CategoryID,
                    CategoryName = category.CategoryName
                };
                results.Add(productWithCategory);
            }
            return results;
        }

        public async Task<List<ResultsProductsWithCategoryDto>> GetProductsWithCategoryByCategoryIdAsync(string categoryId)
        {
            var products = await _productCollection.Find(x => x.CategoryID == categoryId).ToListAsync();
            var results = new List<ResultsProductsWithCategoryDto>();

            foreach (var product in products)
            {
                var category = await _categoryCollection.Find(c => c.CategoryID == product.CategoryID).FirstOrDefaultAsync();
                var productWithCategory = new ResultsProductsWithCategoryDto
                {
                    ProductID = product.ProductID,
                    ProductName = product.ProductName,
                    ProductPrice = product.ProductPrice,
                    ProductDescription = product.ProductDescription,
                    ProductImageUrl = product.ProductImageUrl,
                    CategoryID = product.CategoryID,
                    CategoryName = category.CategoryName
                };
                results.Add(productWithCategory);
            }
            return results;
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var values = _mapper.Map<Product>(updateProductDto);
            await _productCollection.FindOneAndReplaceAsync(x => x.ProductID == updateProductDto.ProductID, values);
        }
    }
}
