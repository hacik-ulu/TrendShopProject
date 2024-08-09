using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrendShop.Cargo.BusinessLayer.Abstract;
using TrendShop.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using TrendShop.Cargo.EntityLayer.Concrete;

namespace TrendShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;

        public CargoOperationsController(ICargoOperationService cargoOperationService)
        {
            _cargoOperationService = cargoOperationService;
        }

        [HttpGet]
        public IActionResult CargoOperationList()
        {
            var values = _cargoOperationService.TGetAll();
            return Ok(values);
        }


        [HttpGet("{id}")]
        public IActionResult GetCargoOperationById(int id)
        {
            var values = _cargoOperationService.TGetById(id);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCargoOperation(CreateCargoOperationDto createCargoOperationDto)
        {
            CargoOperation cargoOperation = new CargoOperation
            {
                Barcode = createCargoOperationDto.Barcode,
                Description = createCargoOperationDto.Description,
                OperationDate = createCargoOperationDto.OperationDate,
            };
            return Ok("Kargo Operasyonları Başarıyla Eklendi");
        }

        [HttpDelete]
        public IActionResult RemoveCargoOperation(int id)
        {
            _cargoOperationService.TDelete(id);
            return Ok("Kargo Operasyonları Başarıyla Silindi");
        }

        [HttpPut]
        public IActionResult UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
        {
            CargoOperation cargoOperation = new CargoOperation
            {
                Barcode = updateCargoOperationDto.Barcode,
                Description = updateCargoOperationDto.Description,
                CargoOperationID = updateCargoOperationDto.CargoOperationID,
                OperationDate = updateCargoOperationDto.OperationDate
            };

            _cargoOperationService.TUpdate(cargoOperation);
            return Ok("Kargo Operasyonları Başarıyla Güncellendi");
        }
    }
}
