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
        public async Task<IActionResult> Index(CreateLoginDto createLoginDto)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonSerializer.Serialize(createLoginDto), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:5001/api/Logins", content);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var tokenModel = JsonSerializer.Deserialize<JwtResponseModel>(jsonData, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                if (tokenModel != null)
                {
                    JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                    var token = handler.ReadJwtToken(tokenModel.Token);

                    var claims = token.Claims.ToList();

                    var nameIdentifierClaim = token.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                    if (nameIdentifierClaim != null)
                    {
                        claims.Add(new Claim(ClaimTypes.NameIdentifier, nameIdentifierClaim.Value)); 
                    }

                    claims.Add(new Claim("trendshoptoken", tokenModel.Token));

                    var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);

                    var authProps = new AuthenticationProperties
                    {
                        ExpiresUtc = tokenModel.ExpireDate,
                        IsPersistent = true
                    };

                    await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);

                    var id = _loginService.GetUserId;  
                    return RedirectToAction("Index", "Default");
                }
            }
            return View();
        }

        //[HttpGet]
        //public IActionResult SignUp()
        //{
        //    return View();
        //}

        //[HttpPost]
        public async Task<IActionResult> SignIn(SignInDto signInDto)
        {
            
            signInDto.Username = "ayse02";
            signInDto.Password = "123456789Aa.";
            await _identityService.SignIn(signInDto);
            return RedirectToAction("Index","Test");
        }
    }
}
