namespace zeaploy.Pages.Applications
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private IAppUserService userService;
        private IApplicationService appService;
        private IAdvertisementService advService;

        public CreateModel(IAppUserService userService, IApplicationService appService, IAdvertisementService advService)
        {
            this.userService = userService;
            this.appService = appService;
            this.advService = advService;
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
            return RedirectToPage("/Advertisements/Advertisements");
        }
    }
}
