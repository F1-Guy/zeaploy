namespace zeaploy.Pages.Advertisements
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly IAdvertisementService adService;
        private readonly INotyfService notyfService;
        private readonly IFileService fileService;

        public EditModel(IAdvertisementService adService, INotyfService notyfService, IFileService fileService)
        {
            this.adService = adService;
            this.notyfService = notyfService;
            this.fileService = fileService;
        }
        [BindProperty]
        public Advertisement Advertisement { get; set; }

#nullable enable
        [BindProperty]
        public IFormFile? Logo { get; set; }
#nullable disable

        public async Task OnGetAsync(int advertisementId)
        {
            Advertisement = await adService.GetAdvertisementByIdAsync(advertisementId);
        }
        public async Task<IActionResult> OnPostAsync(int advertisementId)
        {
            Advertisement = await adService.GetAdvertisementByIdAsync(advertisementId);
            if (!ModelState.IsValid)
            {
                notyfService.Error("The details you entered are not correct. Please review the data and try again.");
                return Page();
            }
            if (Logo != null)
            {
                try
                {
                    await fileService.UploadCompanyLogoAsync(Logo, Advertisement.Company);
                }
                catch (InvalidDataException)
                {
                    notyfService.Error("You tried to upload an unsupported file type. Please try again.");
                    return Page();
                }
                Advertisement.ImagePath = Logo.FileName;
                await adService.EditAdvertisementAsync(Advertisement);
                return RedirectToPage("/Advertisements/Advertisements");
            }
            notyfService.Error("Please upload a company logo.");
            return Page();
        }
    }
}
