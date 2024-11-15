using TrendShop.WebUI.Models;

namespace TrendShop.WebUI.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDetailViewModel> GetUserInfo();
    }
}
