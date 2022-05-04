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

        public async Task <IEnumerable<Advertisement>> GetAdvertisementsAsync()
        {
            return await context.Advertisements.ToListAsync();
        }

        public async Task CreateAdvertisementAsync(Advertisement adv)
        {
            context.Advertisements.Add(adv);
            await context.SaveChangesAsync();
        }

        public async Task<Advertisement> GetAdvertisementByIdAsync(int advId)
        {
            return await context.Advertisements.Where(a => a.Id == advId).FirstOrDefaultAsync();
        }
    }
}
