using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using TrendShop.DtoLayer.IdentityDtos.LoginDto;
using TrendShop.DtoLayer.IdentityDtos.LoginDtos;
using TrendShop.WebUI.Models;
using TrendShop.WebUI.Services.Interfaces;

namespace TrendShop.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;
        private readonly IIdentityService _identityService;

        public LoginController(IHttpClientFactory httpClientFactory, ILoginService loginService, IIdentityService identityService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
            _identityService = identityService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(SignInDto signInDto)
        {
            await _identityService.SignIn(signInDto);
            return View();
        }

        //[HttpPost]
        public async Task<IActionResult> SignIn(SignInDto signInDto)
        {
            
            signInDto.Username = "ayse02";
            signInDto.Password = "123456789Aa.";
            await _identityService.SignIn(signInDto);
            return RedirectToAction("Index","User");
        }
    }
}
