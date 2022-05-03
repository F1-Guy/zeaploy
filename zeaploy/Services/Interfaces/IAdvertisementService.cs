namespace zeaploy.Services.Interfaces
{
    public interface IAdvertisementService
    {
        public Task<IEnumerable<Advertisement>> GetAdvertisementsAsync();
        public Task CreateAdvertisementAsync(Advertisement adv);
    }
}
