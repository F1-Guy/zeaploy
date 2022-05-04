namespace zeaploy.Services.Services
{
    public class AppUserService : IAppUserService
    {
        private readonly ZeaployDbContext context;
        public AppUserService(ZeaployDbContext context)
        {
            this.context = context;
        }
        public async Task CreateAppUserAsync(AppUser user)
        {
            await context.AppUsers.AddAsync(user);
            await context.SaveChangesAsync();
        }

        public async Task UserRegistration(AppUser user)
        {
            throw new NotImplementedException();
        }
    }
}
