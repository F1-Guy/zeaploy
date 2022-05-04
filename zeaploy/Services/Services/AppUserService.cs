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

        public async Task<AppUser> GetLoggedUserAsync(string email)
        {
            return await context.AppUsers.Where(e => e.Email == email).FirstOrDefaultAsync();
        }

        public async Task EditUserAsync(AppUser user)
        {
            AppUser appUser = await context.AppUsers.Where(u => user.Email == u.Email).FirstOrDefaultAsync();
            appUser.Name = user.Name;
            appUser.Email = user.Email;
            appUser.Course = user.Course;
            appUser.JobTitle = user.JobTitle;
            context.SaveChanges();
        }

        
    }
}
