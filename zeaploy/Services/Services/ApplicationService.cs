namespace zeaploy.Services.Services
{
    public class ApplicationService : IApplicationService
    {
        private ZeaployDbContext context;

        public ApplicationService(ZeaployDbContext service)
        {
            context = service;
        }
        public async Task CreateApplicationAsync (int advId, string uId)
        {
            Application application = new Application() { 
                AdvertisementId= advId, 
                AppUserId = uId,
                DateCreated= DateTime.Now
            };
            await context.Applications.AddAsync(application);
            await context.SaveChangesAsync();
        }
        public async Task<ICollection<Application>> GetApplicationsByAdvId(int advertisementId)
        {
            return await context.Applications.Where(a=> a.AdvertisementId == advertisementId).Include(a => a.Advertisement).Include(u => u.AppUser).ToListAsync();
        }
        public async Task<IEnumerable<Application>> GetAllApplicationsAsync()
        {
            return await context.Applications.Include(a => a.Advertisement).Include(u=>u.AppUser).ToListAsync();

        }
    }
}
