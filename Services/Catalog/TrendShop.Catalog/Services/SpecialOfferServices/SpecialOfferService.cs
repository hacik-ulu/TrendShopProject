using AutoMapper;
using MongoDB.Driver;
using TrendShop.Catalog.Dtos.CategoryDtos;
using TrendShop.Catalog.Dtos.SpecialOfferDtos;
using TrendShop.Catalog.Entities;
using TrendShop.Catalog.Settings;

namespace TrendShop.Catalog.Services.SpecialOfferServices
{
    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly IMongoCollection<SpecialOffer> _specialOfferCollection;
        private readonly IMapper _mapper;

        public SpecialOfferService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _specialOfferCollection = database.GetCollection<SpecialOffer>(_databaseSettings.SpecialOfferCollectionName);
            _mapper = mapper;
        }
        public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto)
        {
            var values = _mapper.Map<SpecialOffer>(createSpecialOfferDto);
            await _specialOfferCollection.InsertOneAsync(values);
        }

        public async Task DeleteSpecialOfferAsync(string id)
        {
            await _specialOfferCollection.DeleteOneAsync(x => x.SpecialOfferID == id);

        }

        public async Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync()
        {
            var values = await _specialOfferCollection.Find(x => true).ToListAsync();
            return (_mapper.Map<List<ResultSpecialOfferDto>>(values));
        }

        public async Task<GetByIdSpecialOfferDto> GetByIdSpecialOfferAsync(string id)
        {
            var values = await _specialOfferCollection.Find<SpecialOffer>(x => x.SpecialOfferID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdSpecialOfferDto>(values);
        }

        public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            var values = _mapper.Map<SpecialOffer>(updateSpecialOfferDto);
            var result = await _specialOfferCollection.FindOneAndReplaceAsync(x => x.SpecialOfferID == updateSpecialOfferDto.SpecialOfferID, values);
        }
    }
}
