namespace zeaploy.Pages.Advertisements
{
    public class AdvertisementsModel : PageModel
    {
        private readonly IAdvertisementService adService;

        public IEnumerable<Advertisement> Advertisements { get; set; }

        public AdvertisementsModel(IAdvertisementService service)
        {
            adService = service;
        }
        public async Task OnGetAsync()
        {
            Advertisements = await adService.GetAdvertisementsAsync();
        }
    }
}
