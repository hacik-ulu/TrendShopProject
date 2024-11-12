using TrendShop.DtoLayer.IdentityDtos.LoginDtos;

namespace TrendShop.WebUI.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<bool> SignIn(SignUpDto signUpDto);
    }
}
