using AutoMapper;
using MongoDB.Driver;
using TrendShop.Catalog.Dtos.BrandDtos;
using TrendShop.Catalog.Dtos.CategoryDtos;
using TrendShop.Catalog.Entities;
using TrendShop.Catalog.Settings;

namespace TrendShop.Catalog.Services.BrandServices
{
    public class BrandService : IBrandService
    {
        private readonly IMongoCollection<Brand> _brandCollection;
        private readonly IMapper _mapper;
        public BrandService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _brandCollection = database.GetCollection<Brand>(_databaseSettings.BrandCollectionName);
            _mapper = mapper;
        }

        public async Task CreateBrandAsync(CreateBrandDto createBrandDto)
        {
            var values = _mapper.Map<Brand>(createBrandDto);
            await _brandCollection.InsertOneAsync(values);
        }

        public async Task DeleteBrandAsync(string id)
        {
            await _brandCollection.DeleteOneAsync(x => x.BrandID == id);
        }

        public async Task<List<ResultBrandDto>> GetAllBrandAsync()
        {
            var values = await _brandCollection.Find(x => true).ToListAsync();
            return (_mapper.Map<List<ResultBrandDto>>(values));
        }

        public async Task<GetByIdBrandDto> GetByIdBrandAsync(string id)
        {
            var values = await _brandCollection.Find<Brand>(x => x.BrandID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdBrandDto>(values);
        }

        public async Task UpdateBrandAsync(UpdateBrandDto updateBrandDto)
        {
            var values = _mapper.Map<Brand>(updateBrandDto);
            await _brandCollection.FindOneAndReplaceAsync(x => x.BrandID == updateBrandDto.BrandID, values);
        }
    }
}
