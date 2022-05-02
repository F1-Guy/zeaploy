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
    }
}
