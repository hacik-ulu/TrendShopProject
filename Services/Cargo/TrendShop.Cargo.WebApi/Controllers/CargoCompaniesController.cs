using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrendShop.Cargo.BusinessLayer.Abstract;
using TrendShop.Cargo.DtoLayer.Dtos.CargoCompanyDto;
using TrendShop.Cargo.EntityLayer.Concrete;

namespace TrendShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompaniesController : ControllerBase
    {
        private readonly ICargoCompanyService _companyService;
        private readonly IMapper _mapper;

        public CargoCompaniesController(ICargoCompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CargoCompanyList()
        {
            var values = _companyService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
        {
            var values = _mapper.Map<CargoCompany>(createCargoCompanyDto);
            _companyService.TAdd(values);
            return Ok("Kargo Şirketi Başarıyla Oluşturuldu!");
        }

        [HttpDelete]
        public IActionResult RemoveCargoCompany(int id)
        {
            _companyService.TDelete(id);
            return Ok("Kargo Şirketi Başarıyla Sİlindi!");
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCompanyById(int id)
        {
            var values = _companyService.TGetById(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            // _companyService.TUpdate();
            var values = _mapper.Map<CargoCompany>(updateCargoCompanyDto);
            _companyService.TUpdate(values);
            return Ok("Kargo Şirketi Başarıyla Güncellendi");
        }
    }
}
