using System.Collections;

namespace zeaploy.Services.Interfaces
{
    public interface IAppUserService
    {
        public Task CreateAppUserAsync(AppUser user);
        public Task UserRegistration(AppUser user);
        public Task<AppUser> GetLoggedUserAsync(string Email);
        public Task EditUserAsync(AppUser user);
    }
}
