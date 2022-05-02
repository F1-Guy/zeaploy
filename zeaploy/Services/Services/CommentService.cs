using zeaploy.Services.Interfaces;
namespace zeaploy.Services.Services
{
    public class CommentService :ICommentService
    {
        private ZeaployDbContext context;

        public CommentService(ZeaployDbContext service)
        {
            context = service;
        }
    }
}
