using System.Collections;

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

        public async Task<AppUser> GetLoggedUserAsync(string Email)
        {
            return await context.AppUsers.Where(e => e.Email == Email).FirstOrDefaultAsync();
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
