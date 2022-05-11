namespace zeaploy.Pages.Profile
{
    public class EditModel : PageModel
    {
        private readonly IAppUserService service;
        private readonly INotyfService notyfService;

        public EditModel(IAppUserService service, INotyfService notyfService)
        {
            this.service = service;
            this.notyfService = notyfService;
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
                notyfService.Success("Your profile has been succesfully updated.");
                await service.EditUserAsync(LoggedInUser);
            }
            else
            {
                notyfService.Error("The data you entered is invalid. Please review the data and try again.");
                return Page();
            }

            return RedirectToPage("/Profile/Profile");
        }
    }
}
