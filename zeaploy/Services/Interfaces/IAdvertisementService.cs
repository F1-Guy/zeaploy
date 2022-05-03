namespace zeaploy.Services.Interfaces
{
    public interface IAdvertisementService
    {
        public IEnumerable<Advertisement> GetAllAdvertisements();
        public Task CreateAdvertisementAsync(Advertisement adv);
    }
}
