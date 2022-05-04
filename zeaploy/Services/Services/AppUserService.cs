namespace zeaploy.Services.Services
{
    public class AppUserService : IAppUserService
    {
        private readonly ZeaployDbContext context;
        public AppUserService(ZeaployDbContext context)
        {
            this.context = context;
        }

        public async Task DeleteUserAsync(string id)
        {
            AppUser? user = await context.AppUsers.FindAsync(id);
            context.AppUsers.Remove(user);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AppUser>> GetAllUsersAsync()
        {
            return await context.AppUsers.ToListAsync();
        }

        public async Task<AppUser> GetUserByIdAsync(string id)
        {
            return await context.AppUsers.FindAsync(id);
        }
    }
}
