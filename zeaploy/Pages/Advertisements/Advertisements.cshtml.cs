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

            // Add the rest of the conditions conditions
            if (String.IsNullOrEmpty(Criteria) && String.IsNullOrEmpty(TypeCriteria) && String.IsNullOrEmpty(LocationCriteria))
            {
                Advertisements = await adService.GetAdvertisementsAsync();
            }
            else
            {
                Advertisements = adService.Filter(a => (a.Company.Contains(Criteria, StringComparison.OrdinalIgnoreCase) 
                                                     || a.Position.Contains(Criteria, StringComparison.OrdinalIgnoreCase)));
            }
        } 
    }
}
