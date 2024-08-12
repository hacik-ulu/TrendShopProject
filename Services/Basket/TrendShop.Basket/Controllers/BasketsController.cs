using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrendShop.Basket.Dtos;
using TrendShop.Basket.LoginServices;
using TrendShop.Basket.Services;

namespace TrendShop.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ILoginService _loginService;

        public BasketsController(ILoginService loginService, IBasketService basketService)
        {
            _loginService = loginService;
            _basketService = basketService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMyBasketDetail()
        {
            var values = _basketService.GetBasketTotal(_loginService.GetUserId);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> SaveMyBasket(BasketTotalDto basketTotalDto)
        {
            basketTotalDto.UserID = _loginService.GetUserId;
            await _basketService.SaveBasket(basketTotalDto);
            return Ok("Sepetteli Değişiklikler Kaydedildi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBasket()
        {
            await _basketService.DeleteBasket(_loginService.GetUserId);
            return Ok("Sepet Başarıyla Silindi");
        }
    }
}