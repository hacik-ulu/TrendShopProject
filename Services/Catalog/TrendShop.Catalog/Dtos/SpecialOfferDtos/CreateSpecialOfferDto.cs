using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace TrendShop.Catalog.Dtos.SpecialOfferDtos
{
    public class CreateSpecialOfferDto
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ImageUrl { get; set; }
    }
}
