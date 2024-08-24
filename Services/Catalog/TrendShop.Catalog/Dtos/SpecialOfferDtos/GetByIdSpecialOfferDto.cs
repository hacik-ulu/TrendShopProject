using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace TrendShop.Catalog.Dtos.SpecialOfferDtos
{
    public class GetByIdSpecialOfferDto
    {
        public string SpecialOfferID { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ImageUrl { get; set; }
    }
}
