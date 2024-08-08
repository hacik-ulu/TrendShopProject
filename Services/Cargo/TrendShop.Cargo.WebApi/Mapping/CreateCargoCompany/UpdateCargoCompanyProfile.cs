using AutoMapper;
using TrendShop.Cargo.DtoLayer.Dtos.CargoCompanyDto;
using TrendShop.Cargo.EntityLayer.Concrete;

namespace TrendShop.Cargo.WebApi.Mapping.CreateCargoCompany
{
    public class UpdateCargoCompanyProfile : Profile
    {
        public UpdateCargoCompanyProfile()
        {
            CreateMap<UpdateCargoCompanyDto, CargoCompany>();
        }
    }
}
