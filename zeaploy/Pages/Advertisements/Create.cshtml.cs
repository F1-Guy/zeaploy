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

#nullable enable
        [BindProperty]
        public IFormFile? Logo { get; set; }
# nullable disable

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                Advertisement.Posted = DateTime.Now;
                if (Logo != null)
                {
                    await fileService.UploadCompanyLogoAsync(Logo, Advertisement.Company);
                    Advertisement.ImagePath = Logo.FileName;
                    await service.CreateAdvertisementAsync(Advertisement);
                    notyfService.Success("You have successfully added an advertisement.");
                    return RedirectToPage("Advertisements");
                }
                else
                {
                    notyfService.Error("Please upload a company logo.");
                    return Page();
                }
            }
            else
            {
                notyfService.Error("The data you entered is invalid. Please review the data and try again.");
                return Page();
            }
        }
    }
}
