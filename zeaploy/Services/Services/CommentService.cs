namespace zeaploy.Services.Services
{
    public class CommentService : ICommentService
    {
        private readonly ZeaployDbContext context;

        public CommentService(ZeaployDbContext service)
        {
            context = service;
        }

        public async Task CreateCommentAsync(Comment comment)
        {
            context.Add(comment);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Comment>> GetCommentsAsync(int advertisementId)
        {
            return await context.Comments.Where(c => c.AdvertisementId == advertisementId).ToListAsync();
        }
    }
}
