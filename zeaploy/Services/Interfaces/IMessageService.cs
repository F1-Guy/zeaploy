namespace zeaploy.Services.Interfaces
{
    public interface IMessageService
    {
        Task SendMessageAsync(Message message);
    }
}
