using TrendShop.DtoLayer.IdentityDtos.LoginDtos;

namespace TrendShop.WebUI.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<bool> SignIn(SignInDto signInDto);
        Task<bool> GetRefreshToken();

    }
}
