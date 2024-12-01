using TrendShop.DtoLayer.IdentityDtos.UserDtos;

namespace TrendShop.WebUI.Services.UserIdentityServices
{
    public interface IUserIdentityService
    {
        Task<List<ResultUserDto>> GetAllUserListAsync();

    }
}
