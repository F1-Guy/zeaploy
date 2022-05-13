namespace zeaploy.Pages.Advertisements
{
    public class AdvertisementsModel : PageModel
    {
        private readonly IAdvertisementService adService;
        private readonly IApplicationService apService;
        private readonly IAppUserService uService;


        [BindProperty(SupportsGet = true)]
        public string Criteria  { get; set; }


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

            if (String.IsNullOrEmpty(Criteria))
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
