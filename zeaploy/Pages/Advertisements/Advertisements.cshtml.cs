namespace zeaploy.Pages.Advertisements
{
    public class AdvertisementsModel : PageModel
    {
        private IAdvertisementService adService;
        private IApplicationService apService;
        private IAppUserService uService;

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
            Advertisements = await adService.GetAdvertisementsAsync();
            LoggedUser =  await uService.GetLoggedUserAsync(User.Identity.Name);
        }

        
    }
}
