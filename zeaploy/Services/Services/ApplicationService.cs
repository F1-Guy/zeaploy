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
            var result = await context.Applications.AddAsync(application);
            await context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Application>> GetAllApplicationsAsync()
        {
            var application = await context.Applications.Include(a => a.Advertisement).Include(u=>u.AppUser).ToListAsync();
            return application;
        }
    }
}
