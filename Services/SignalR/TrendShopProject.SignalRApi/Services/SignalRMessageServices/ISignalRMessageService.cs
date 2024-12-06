namespace TrendShopProject.SignalRApi.Services.SingalRMessageServices
{
    public interface ISignalRMessageService
    {
        Task<int> GetTotalMessageCountByReceiverId(string id);

    }
}
