﻿using MongoDB.Bson;
using MongoDB.Driver;
using TrendShop.Catalog.Entities;
using TrendShop.Catalog.Settings;

namespace TrendShop.Catalog.Services.StatisticServices
{
    public class StatisticService : IStatisticService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMongoCollection<Brand> _brandCollection;

        public StatisticService(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _brandCollection = database.GetCollection<Brand>(_databaseSettings.BrandCollectionName);
        }

        public Task<long> GetBrandCount()
        {
            return _brandCollection.CountDocumentsAsync(FilterDefinition<Brand>.Empty);
        }

        public Task<long> GetCategoryCount()
        {
            return _categoryCollection.CountDocumentsAsync(FilterDefinition<Category>.Empty);
        }

        public async Task<string> GetMaxPriceProductName()
        {
            var filter = Builders<Product>.Filter.Empty;
            var sort = Builders<Product>.Sort.Descending(x => x.ProductPrice);
            var projection = Builders<Product>.Projection.Include(y =>
                                                      y.ProductName).Exclude("ProductID");
            var product = await _productCollection.Find(filter)
                                                .Sort(sort)
                                                .Project(projection)
                                                .FirstOrDefaultAsync();
            return product.GetValue("ProductName").AsString;

        }

        public async Task<string> GetMinPriceProductName()
        {
            var filter = Builders<Product>.Filter.Empty;
            var sort = Builders<Product>.Sort.Ascending(x => x.ProductPrice);
            var projection = Builders<Product>.Projection.Include(y => y.ProductName).Exclude("ProductID");
            var product = await _productCollection.Find(filter).Sort(sort).Project(projection).FirstOrDefaultAsync();
            return product.GetValue("ProductName").AsString;
        }

        public async Task<decimal> GetProductAvgPrice()
        {
            var pipeline = new BsonDocument[]
            {
            new BsonDocument("$group", new BsonDocument
            {
                {"_id", new BsonDocument()},
                {"averagePrice", new BsonDocument("$avg", "$ProductPrice")}
            })
                };

            var result = await _productCollection.AggregateAsync<BsonDocument>(pipeline);
            var averagePriceValue = result.FirstOrDefault()?.GetValue("averagePrice");

            if (averagePriceValue == null || averagePriceValue.IsBsonNull)
            {
                return decimal.Zero;
            }

            return Math.Round(averagePriceValue.ToDecimal(), 2);
        }

        public Task<long> GetProductCount()
        {
            return _productCollection.CountDocumentsAsync(FilterDefinition<Product>.Empty);
        }
    }
}
