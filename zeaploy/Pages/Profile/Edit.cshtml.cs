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
        public AppUser LoggedUser { get; set; }

        public async Task OnGetAsync(string Email)
        {
            LoggedUser = await appUserService.GetLoggedUserAsync(User.Identity.Name);
        }
        public async Task<IActionResult> OnPostAsync()
        {
            await appUserService.EditUserAsync(LoggedUser);
            return RedirectToPage("/Profile/Profile");
        }

    }
}
