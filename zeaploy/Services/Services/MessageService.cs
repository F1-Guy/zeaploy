namespace zeaploy.Services.Services
{
    public class MessageService : IMessageService
    {
        private readonly ZeaployDbContext context;

        public MessageService(ZeaployDbContext service)
        {
            context = service;
        }

        public async Task DeleteMessageAsync(Message message)
        {
            context.Remove(message);
            await context.SaveChangesAsync();
        }

        public async Task<Message> GetMessageByIdAsync(int id)
        {
            return await context.Messages.FindAsync(id);
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