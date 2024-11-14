using System.ComponentModel;
using TrendShop.DtoLayer.IdentityDtos.LoginDtos;

namespace TrendShop.WebUI.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<bool> SignIn(SignInDto signInDto);

        // Access token süresi dolduğunda tekrardan giriş yapmamak adına refresh token devreye girerek access token alınmasını sağlar.
        Task<bool> GetRefreshToken();

    }
}
