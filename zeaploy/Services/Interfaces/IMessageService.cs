namespace zeaploy.Services.Interfaces
{
    public interface IMessageService
    {
        Task SendMessageAsync(Message message);

        Task<IEnumerable<Message>> GetMessagesAsync(string userId);

        Task DeleteMessageAsync(Message message);

        Task<Message> GetMessageByIdAsync(int id);
    }
}
