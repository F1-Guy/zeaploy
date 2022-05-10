namespace zeaploy.Pages.Profile
{
    public class EditModel : PageModel
    {
        private IAppUserService service;

        public EditModel(IAppUserService service)
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
            await service.EditUserAsync(LoggedInUser);
            return RedirectToPage("/Profile/Profile");
        }
    }
}
