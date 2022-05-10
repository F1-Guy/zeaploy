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
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync(Advertisement adv)
        {
            adv.Posted = DateTime.Now;
            await service.CreateAdvertisementAsync(adv);
            notyfService.Success("You have succesfully added an advertisement.");
            return RedirectToPage("Advertisements");
        }
    }
}
