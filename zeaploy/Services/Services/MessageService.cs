namespace zeaploy.Services.Services
{
    public class MessageService : IMessageService
    {
        private ZeaployDbContext context;

        public MessageService(ZeaployDbContext service)
        {
            context = service;
        }

        public async Task SendMessageAsync(Message message)
        {
            context.Add(message);
            await context.SaveChangesAsync();
        }
    }
}
