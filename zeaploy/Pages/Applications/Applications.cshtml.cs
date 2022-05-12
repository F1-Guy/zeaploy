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
        public string Criteria { get; set; }

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

            if (String.IsNullOrEmpty(Criteria))
            {
                Applications = await appService.GetAllApplicationsAsync();
            }
            else
            {
                Applications = appService.Filter((Application a) => (a.Advertisement.Company.ToLower().Contains(Criteria.ToLower()) || a.AppUser.Name.ToLower().Contains(Criteria.ToLower())));
            }
        }
    }
}
