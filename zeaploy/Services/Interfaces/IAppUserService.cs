namespace zeaploy.Services.Interfaces
{
    public interface IAppUserService
    {
        public Task<AppUser> GetLoggedUserAsync(string Email);
        public Task EditUserAsync(AppUser user);
        public Task<IEnumerable<AppUser>> GetAllUsersAsync();
        public Task DeleteUserAsync(string id);
        public Task<AppUser> GetUserByIdAsync(string id);
        public Task<IEnumerable<AppUser>> GetAllAdminsAsync();
        public IEnumerable<AppUser> Filter(Predicate<AppUser> predicate);
    }
}
