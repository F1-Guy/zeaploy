namespace zeaploy.Pages.Users
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly IAppUserService service;

        public EditModel(IAppUserService service)
        {
            this.service = service;
        }

        [BindProperty]
        public AppUser AppUser { get; set; }

        public async Task OnGetAsync(string id)
        {
            AppUser = await service.GetUserByIdAsync(id);
        }

        public async Task<IActionResult> OnPostAsync()
        {

            return RedirectToPage("/Users/AllUsers");
        }
    }
}
