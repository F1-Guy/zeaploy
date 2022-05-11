namespace zeaploy.Services.Services
{
    public class ApplicationService : IApplicationService
    {
        readonly private ZeaployDbContext context;

        public ApplicationService(ZeaployDbContext service)
        {
            context = service;
        }

        public async Task CreateApplicationAsync(int advId, string uId)
        {
            Application application = new()
            {
                AdvertisementId = advId,
                AppUserId = uId,
                DateCreated = DateTime.Now
            };
            await context.Applications.AddAsync(application);
            await context.SaveChangesAsync();
        }

        public async Task<bool> IsUserAppliedAsync(string uId, int advId)
        {
            Application app = await context.Applications.Where(u => u.AppUserId == uId).Where(a => a.AdvertisementId == advId).FirstOrDefaultAsync();
            if (app == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<Application> GetApplicationByIdAsync(int applicationId)
        {
            return await context.Applications.Where(a => a.Id == applicationId).Include(a => a.Advertisement).Include(u => u.AppUser).FirstOrDefaultAsync();
        }

        public async Task<ICollection<Application>> GetApplicationsByAdvId(int advertisementId)
        {
            return await context.Applications.Where(a => a.AdvertisementId == advertisementId).Include(a => a.Advertisement).Include(u => u.AppUser).ToListAsync();
        }

        public async Task<IEnumerable<Application>> GetAllApplicationsAsync()
        {
            return await context.Applications.Include(a => a.Advertisement).Include(u => u.AppUser).ToListAsync();
        }

        public async Task<ICollection<Application>> GetApplicationsByUserAsync(string userEmail)
        {
            return await context.Applications.Where(u => u.AppUser.Email == userEmail).Include(a => a.Advertisement).Include(u => u.AppUser).ToListAsync();
        }

        public async Task DeleteApplicationAsync(int id)
        {
            Application application = await context.Applications.FindAsync(id);
            context.Applications.Remove(application);
            await context.SaveChangesAsync();
        }
    }
}
