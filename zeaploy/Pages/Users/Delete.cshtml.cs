namespace zeaploy.Pages.Users
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly IAppUserService service;
        public DeleteModel(IAppUserService service)
        {
            this.service = service;
        }

        [BindProperty]
        public AppUser AppUser { get; set; }
        public async Task OnGetAsync(string id)
        {
            AppUser = await service.GetUserByIdAsync(id);
        }
        public async Task<IActionResult> OnPostAsync(string id)
        {
            await service.DeleteUserAsync(id);
            return RedirectToPage("/Users/AllUsers");
        }
    }
}
