namespace zeaploy.Services.Interfaces
{
    public interface IApplicationService
    {
        public Task CreateApplicationAsync(int avdId, string uId);
        public Task<IEnumerable<Application>> GetAllApplicationsAsync();
        public Task<Application> GetApplicationByIdAsync(int applicationId);
        public Task<IEnumerable<Application>> GetApplicationsByAdvId(int advertisementId);
        public Task<IEnumerable<Application>> GetApplicationsByUserAsync(string userEmail);
        public Task DeleteApplicationAsync(int applicationId);
        public Task<bool> IsUserAppliedAsync(string uId, int advId);
#nullable enable
        public Task<IEnumerable<Application>> FilterAsync(string? searchString);
        public Task<IEnumerable<Application>> FilterUsersAsync(string? searchString, string userEmail);
    }
}
