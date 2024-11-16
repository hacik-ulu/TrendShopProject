namespace TrendShop.WebUI.Services.Interfaces
{
    public interface IClientCredentialTokenService
    {
        // visitor formatındaki kullanıcılar için.
        Task<string> GetToken();
    }
}
