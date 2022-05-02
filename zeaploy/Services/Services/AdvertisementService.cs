using zeaploy.Services.Interfaces;

namespace zeaploy.Services.Services
{
    public class AdvertisementService : IAdvertisementService
    {
        private ZeaployDbContext context;

        public AdvertisementService(ZeaployDbContext service)
        {
            context = service;
        }

        public async Task CreateAdvertisementAsync(Advertisement adv)
        {
            context.Advertisements.Add(adv);
            await context.SaveChangesAsync();
        }
    }
}
