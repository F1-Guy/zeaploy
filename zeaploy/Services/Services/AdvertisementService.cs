namespace zeaploy.Services.Services
{
    public class AdvertisementService : IAdvertisementService
    {
        readonly private ZeaployDbContext context;

        public AdvertisementService(ZeaployDbContext service)
        {
            context = service;
        }

        public async Task<IEnumerable<Advertisement>> GetAdvertisementsAsync()
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

        public async Task EditAdvertisementAsync(Advertisement adv)
        {
            Advertisement ad = await context.Advertisements.Where(a => a.Id == adv.Id).FirstOrDefaultAsync();
            ad.Company = adv.Company;
            ad.Description = adv.Description;
            ad.JobType = adv.JobType;
            ad.Position = adv.Position;
            ad.Posted = adv.Posted;
            ad.Wage = adv.Wage;
            ad.Location = adv.Location;
            context.SaveChanges();
        }

        public async Task DeleteAdvertisementAsync(int advertisementId)
        {
            Advertisement ad = await context.Advertisements.FindAsync(advertisementId);
            context.Advertisements.Remove(ad);
            await context.SaveChangesAsync();
        }
    }
}
