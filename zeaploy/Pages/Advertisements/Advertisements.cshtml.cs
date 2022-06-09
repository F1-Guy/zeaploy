namespace zeaploy.Pages.Advertisements
{
    [Authorize]
    public class AdvertisementsModel : PageModel
    {
        private readonly IAdvertisementService adService;
        private readonly IAppUserService uService;

        public IEnumerable<Advertisement> Advertisements { get; set; }

        public AppUser LoggedUser { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchCriteria { get; set; }

        [BindProperty(SupportsGet = true)]
        public string TypeCriteria { get; set; }

        [BindProperty(SupportsGet = true)]
        public string LocationCriteria { get; set; }

        public AdvertisementsModel(IAdvertisementService adService, IAppUserService uService)
        {
            this.adService = adService;
            this.uService = uService;
        }

        public async Task OnGetAsync()
        {
            LoggedUser = await uService.GetLoggedUserAsync(User.Identity.Name);

            if (!String.IsNullOrEmpty(SearchCriteria) || TypeCriteria != null || LocationCriteria != null)
                Advertisements = await adService.FilterAsync(SearchCriteria, TypeCriteria, LocationCriteria);
            else
                Advertisements = await adService.GetAdvertisementsAsync();
        }
    }
}
