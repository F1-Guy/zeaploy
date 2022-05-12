namespace zeaploy.Services.Services
{
    public class FilterService : IFilterService
    {
        readonly private ZeaployDbContext context;

        public FilterService(ZeaployDbContext service)
        {
            context = service;
        }

        
    }
}
