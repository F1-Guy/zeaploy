namespace zeaploy.Pages.Advertisements
{
    public class AdvertisementsModel : PageModel
    {
        private readonly IAdvertisementService adService;
        private readonly IApplicationService apService;
        private readonly IAppUserService uService;

        [BindProperty(SupportsGet = true)]
        public string SearchCriteria  { get; set; }

        [BindProperty(SupportsGet = true)]
        public string TypeCriteria { get; set; }

        [BindProperty(SupportsGet = true)]
        public string LocationCriteria { get; set; }

        public IEnumerable<Advertisement> Advertisements { get; set; }

        public IEnumerable<Advertisement> Filtered { get; set; } = new List<Advertisement>();

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

            if (!String.IsNullOrEmpty(SearchCriteria) || !String.IsNullOrEmpty(TypeCriteria) || !String.IsNullOrEmpty(LocationCriteria))
            {
                Advertisements = adService.Filter(SearchCriteria, TypeCriteria, LocationCriteria);
            }
            else
            {
                Advertisements = await adService.GetAdvertisementsAsync();
            }
        } 
    }
}
