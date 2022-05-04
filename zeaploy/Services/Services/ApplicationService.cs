using zeaploy.Services.Interfaces;

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
    }
}
