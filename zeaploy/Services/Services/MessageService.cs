namespace zeaploy.Services.Services
{
    public class MessageService : IMessageService
    {
        readonly private ZeaployDbContext context;

        public MessageService(ZeaployDbContext service)
        {
            context = service;
        }

        public async Task<IEnumerable<Message>> GetMessagesAsync(string userId)
        {
            return await context.Messages.Where(m => m.AppUserId == userId).ToListAsync();
        }

        public async Task SendMessageAsync(Message message)
        {
            context.Add(message);
            await context.SaveChangesAsync();
        }
    }
}
