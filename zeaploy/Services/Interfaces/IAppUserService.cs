using System.Collections;

namespace zeaploy.Services.Interfaces
{
    public interface IAppUserService
    {
        public Task<IEnumerable<AppUser>> GetAllUsersAsync();
        public Task DeleteUserAsync(string id);
        public Task<AppUser> GetUserByIdAsync(string id);
    }
}
