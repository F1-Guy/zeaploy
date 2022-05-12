namespace zeaploy.Pages.Advertisements
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly IAdvertisementService service;
        private readonly INotyfService notyfService;
        private readonly IFileService fileService;

        public CreateModel(IAdvertisementService service, INotyfService notyfService, IFileService fileService)
        {
            this.service = service;
            this.notyfService = notyfService;
            this.fileService = fileService;
        }

        [BindProperty]
        public Advertisement Advertisement { get; set; }

        [BindProperty]
        public IFormFile? Logo { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Advertisement.Posted = DateTime.Now;
            await fileService.UploadCompanyLogoAsync(Logo, Advertisement.Company);
            Advertisement.ImagePath = Logo.FileName;
            await service.CreateAdvertisementAsync(Advertisement);
            notyfService.Success("You have successfully added an advertisement.");
            return RedirectToPage("Advertisements");
        }
    }
}
