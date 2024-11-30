using TrendShopProject.Message.Dtos;

namespace TrendShopProject.Message.Services
{
    public interface IUserMessageService
    {
        Task<List<ResultMessageDto>> GetAllMessageAsync();
        Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id); // Gelen mesajlar (receiver id'ye göre gelecek.)
        Task<List<ResultSendboxMessageDto>> GetSendboxMessageAsync(string id); // Gönderilen mesajlar (sender id'ye göre gelecek.)
        Task CreateMessageAsync(CreateMessageDto createMessageDto);
        Task UpdateMessageAsync(UpdateMessageDto updateMessageDto);
        Task DeleteMessageAsync(int id);
        Task<GetByIdMessageDto> GetByIdMessageAsync(int id);

    }
}
