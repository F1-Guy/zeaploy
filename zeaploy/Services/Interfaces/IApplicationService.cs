﻿namespace zeaploy.Services.Interfaces
{
    public interface IApplicationService
    {
        public Task CreateApplicationAsync(int avdId, string uId);
        public Task<IEnumerable<Application>> GetAllApplicationsAsync();
    }
}
