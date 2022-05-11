namespace zeaploy.Services.Interfaces
{
    public interface ICommentService
    {
        public Task CreateComment(Comment comment);
        public Task<IEnumerable<Comment>> GetAdvComments(int advertisementId);
    }
}
