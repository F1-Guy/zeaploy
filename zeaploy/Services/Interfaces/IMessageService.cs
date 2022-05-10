namespace zeaploy.Services.Interfaces
{
    public interface IMessageService
    {
        Task SendMessageAsync(Message message);

        Task<IEnumerable<Message>> GetMessagesAsync(string userId);
    }
}
