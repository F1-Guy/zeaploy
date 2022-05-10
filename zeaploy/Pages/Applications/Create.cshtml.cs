namespace zeaploy.Pages.Applications
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private IAppUserService userService;
        private IApplicationService appService;
        private IAdvertisementService advService;
        private INotyfService notyfService;

        public CreateModel(IAppUserService userService, IApplicationService appService, IAdvertisementService advService, INotyfService notyfService)
        {
            this.userService = userService;
            this.appService = appService;
            this.advService = advService;
            this.notyfService = notyfService;
        }

        public AppUser AppUser { get; set; }

        [BindProperty]
        public Application Application { get; set; }

        public Advertisement Advertisement { get; set; }

        public async Task OnGetAsync(int advertisementId)
        {
            Advertisement = await advService.GetAdvertisementByIdAsync(advertisementId);
            AppUser = await userService.GetLoggedUserAsync(User.Identity.Name);
        }

        public async Task<IActionResult> OnPostAsync(int advertisementId)
        {
            AppUser = await userService.GetLoggedUserAsync(User.Identity.Name);
            string userId = AppUser.Id;
            await appService.CreateApplicationAsync(advertisementId, userId);
            notyfService.Success("You have succesfully applied for this advertisement. You can see it in your profile.");
            return RedirectToPage("/Advertisements/Advertisements");
        }
    }
}
