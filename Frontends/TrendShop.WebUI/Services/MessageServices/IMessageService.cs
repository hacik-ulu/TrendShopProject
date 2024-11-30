using TrendShop.DtoLayer.MessageDtos;

namespace TrendShop.WebUI.Services.MessageServices
{
    public interface IMessageService
    {
        Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id); // Gelen mesajlar (receiver id'ye göre gelecek.)
        Task<List<ResultSendboxMessageDto>> GetSendboxMessageAsync(string id); // Gönderilen mesajlar (sender id'ye göre gelecek.)
    }
}
