namespace zeaploy.Pages.Applications
{
    [Authorize]
    public class ApplicationsModel : PageModel
    {
        private IApplicationService appService;
        private IAdvertisementService advService;

        public ApplicationsModel(IApplicationService appService, IAdvertisementService advService)
        {
            this.appService = appService;
            this.advService = advService;
        }

        public IEnumerable<Application> Applications { get; set; }

        public int? AdvertisementId { get; set; }

        public Advertisement OpenAdvertisement { get; set; }

        public async Task OnGetAsync(int? AdvertisementId)
        {
            if (AdvertisementId == null) 
            {
                Applications = await appService.GetAllApplicationsAsync();
            }
            else
            {
                Applications = await appService.GetApplicationsByAdvId(AdvertisementId.Value);
                OpenAdvertisement = await advService.GetAdvertisementByIdAsync(AdvertisementId.Value);
            }
        }
    }
}
