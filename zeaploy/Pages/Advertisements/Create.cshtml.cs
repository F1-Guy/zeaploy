namespace zeaploy.Pages.Advertisements
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly IAdvertisementService service;
        private readonly INotyfService notyfService;

        public CreateModel(IAdvertisementService service, INotyfService notyfService)
        {
            this.service = service;
            this.notyfService = notyfService;
        }

        [BindProperty]
        public Advertisement Advertisement { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Advertisement.Posted = DateTime.Now;
            await service.CreateAdvertisementAsync(Advertisement);
            notyfService.Success("You have successfully added an advertisement.");
            return RedirectToPage("Advertisements");
        }
    }
}
