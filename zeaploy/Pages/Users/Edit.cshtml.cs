namespace zeaploy.Pages.Users
{
    [Authorize(Roles = "Admin")]
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
        public AppUser AppUser { get; set; }

        public async Task OnGetAsync(string id)
        {
            AppUser = await service.GetUserByIdAsync(id);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                notyfService.Error("The details you entered are not correct. Please review the data and try again.");
                return Page();
            }

            await service.EditUserAsync(AppUser);
            return RedirectToPage("/Users/Users");
        }
    }
}
