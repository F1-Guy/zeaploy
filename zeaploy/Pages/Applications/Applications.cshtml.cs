namespace zeaploy.Pages.Applications
{
    [Authorize]
    public class ApplicationsModel : PageModel
    {
        private readonly IApplicationService appService;
        private readonly IAdvertisementService advService;

        public ApplicationsModel(IApplicationService appService, IAdvertisementService advService)
        {
            this.appService = appService;
            this.advService = advService;
        }

        public IEnumerable<Application> Applications { get; set; }

        public int? AdvertisementId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchCriteria { get; set; }

        public Advertisement OpenAdvertisement { get; set; }

        public async Task OnGetAsync(int? AdvertisementId)
        {
            if (AdvertisementId == null)
            {
                if (!String.IsNullOrEmpty(SearchCriteria))
                {
                    Applications = appService.Filter(SearchCriteria);
                }
                else
                {
                    Applications = await appService.GetAllApplicationsAsync();
                }
                
            }
            else
            {
                Applications = await appService.GetApplicationsByAdvId(AdvertisementId.Value);
                OpenAdvertisement = await advService.GetAdvertisementByIdAsync(AdvertisementId.Value);
            }
        }
    }
}
