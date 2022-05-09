namespace zeaploy.Pages.Advertisements
{
    public class AdvertisementsModel : PageModel
    {
        private IAdvertisementService adService;
        private readonly INotyfService notyf;

        public IEnumerable<Advertisement> Advertisements { get; set; }

        public AdvertisementsModel(IAdvertisementService service, INotyfService notyf)
        {
            adService = service;
            this.notyf = notyf;
        }
        public async Task OnGetAsync()
        {
            Advertisements = await adService.GetAdvertisementsAsync();
        }
    }
}
