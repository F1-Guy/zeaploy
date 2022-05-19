namespace zeaploy.Pages.Advertisements
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly IAdvertisementService adService;
        private readonly IFileService fileService;

        public DeleteModel(IAdvertisementService adService, IFileService fileService)
        {
            this.adService = adService;
            this.fileService = fileService;
        }
        [BindProperty]
        public Advertisement Advertisement { get; set; }

        public async Task OnGetAsync(int advertisementId)
        {
            Advertisement = await adService.GetAdvertisementByIdAsync(advertisementId);
        }
        public async Task<IActionResult> OnPostAsync(int advertisementId)
        {
            Advertisement = await adService.GetAdvertisementByIdAsync(advertisementId);
            fileService.DeleteCompanyLogo(Advertisement.Company);
            await adService.DeleteAdvertisementAsync(advertisementId);
            return RedirectToPage("/Advertisements/Advertisements");
        }
    }
}
