namespace zeaploy.Services.Interfaces
{
    public interface IApplicationService
    {
        public Task CreateApplicationAsync(int avdId, string uId);
        public Task<IEnumerable<Application>> GetAllApplicationsAsync();
        public Task<Application> GetApplicationByIdAsync(int applicationId);
        public Task<ICollection<Application>> GetApplicationsByAdvId(int advertisementId);
        public Task<ICollection<Application>> GetApplicationsByUserAsync(string userEmail);
        public Task DeleteApplicationAsync(int applicationId);
        public Task<bool> IsUserAppliedAsync(string uId, int advId);
        public IEnumerable<Application> Filter(Predicate<Application> predicate);
    }
}
