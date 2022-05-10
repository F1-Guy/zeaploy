namespace zeaploy.Pages.Account
{
    [Authorize]
    public class ProfileModel : PageModel
    {
        private IAppUserService service;

        public ProfileModel(IAppUserService service)
        {
            this.service = service;
        }

        [BindProperty]
        public AppUser LoggedInUser { get; set; }

        public async Task OnGetAsync()
        {
            LoggedInUser = await service.GetLoggedUserAsync(User.Identity.Name);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            return Page();
        }
    }
}
