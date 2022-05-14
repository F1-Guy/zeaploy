namespace zeaploy.Pages.Advertisements
{
    public class AdvertisementsModel : PageModel
    {
        private readonly IAdvertisementService adService;
        private readonly IApplicationService apService;
        private readonly IAppUserService uService;

        [BindProperty(SupportsGet = true)]
        public string Criteria  { get; set; }

        [BindProperty(SupportsGet = true)]
        public string TypeCriteria { get; set; }

        [BindProperty(SupportsGet = true)]
        public string LocationCriteria { get; set; }

        public IEnumerable<Advertisement> Advertisements { get; set; }

        public IEnumerable<Advertisement> Filtered { get; set; } = Enumerable.Empty<Advertisement>();

        public AppUser LoggedUser { get; set; }

        public AdvertisementsModel(IAdvertisementService adService, IApplicationService apService, IAppUserService uService)
        {
            this.adService = adService;
            this.apService = apService;
            this.uService = uService;
        }

        public async Task OnGetAsync()
        {
            LoggedUser = await uService.GetLoggedUserAsync(User.Identity.Name);
  
            if (!String.IsNullOrEmpty(Criteria))
            {
                Filtered.Concat(adService.Filter(a => (a.Company.Contains(Criteria, StringComparison.OrdinalIgnoreCase)
                                                     || a.Position.Contains(Criteria, StringComparison.OrdinalIgnoreCase))));
            }
         
            if (!String.IsNullOrEmpty(TypeCriteria))
            {
                Filtered.Concat(adService.Filter(a => (a.JobType.Contains(TypeCriteria))));
            }

            if (!String.IsNullOrEmpty(LocationCriteria))
            {
                Filtered.Concat(adService.Filter(a => (a.Location.Contains(LocationCriteria))));
            }

            if ((Filtered != null) && (!Filtered.Any()))
            {
                Advertisements = await adService.GetAdvertisementsAsync();
            }
            else
            {
                Advertisements = Filtered.Distinct();
            }
        } 
    }
}
