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
            if (ModelState.IsValid)
            {
                await service.EditUserAsync(LoggedInUser);
            }
            else
            {
                return Page();
            }

            return RedirectToPage("/Profile/Profile");
        }
    }
}
