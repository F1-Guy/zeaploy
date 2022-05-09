namespace zeaploy.Pages.Profile
{
    public class EditModel : PageModel
    {
        private IAppUserService appUserService;

        public EditModel(IAppUserService service)
        {
            appUserService = service;
        }

        [BindProperty]
        public AppUser LoggedInUser { get; set; }

        public async Task OnGetAsync(string Email)
        {
            LoggedInUser = await appUserService.GetLoggedUserAsync(User.Identity.Name);
        }
        public async Task<IActionResult> OnPostAsync()
        {
            // Saving doesn't work null exception thrown
            await appUserService.EditUserAsync(LoggedInUser);
            return RedirectToPage("/Profile/Profile");
        }

    }
}
