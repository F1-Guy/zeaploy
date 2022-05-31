namespace zeaploy.Services.Interfaces
{
    public interface ICommentService
    {
        public Task CreateCommentAsync(Comment comment);
        public Task<IEnumerable<Comment>> GetCommentsAsync(int advertisementId);
    }
}
