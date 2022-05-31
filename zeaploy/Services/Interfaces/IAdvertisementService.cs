namespace zeaploy.Services.Interfaces
{
    public interface IAdvertisementService
    {
        public Task<IEnumerable<Advertisement>> GetAdvertisementsAsync();
        public Task CreateAdvertisementAsync(Advertisement adv);
        public Task<Advertisement> GetAdvertisementByIdAsync(int advId);
        public Task EditAdvertisementAsync(Advertisement adv);
        public Task DeleteAdvertisementAsync(int advertisementId);
#nullable enable
        public Task<IEnumerable<Advertisement>> FilterAsync(string? searchString, string? jobType, string? location);
    }
}

