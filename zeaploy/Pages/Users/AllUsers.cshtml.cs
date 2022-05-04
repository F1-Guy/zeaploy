namespace zeaploy.Pages.Users
{
    [Authorize(Roles = "Admin")]
    public class AllUsersModel : PageModel
    {
        private readonly IAppUserService service;
        public AllUsersModel(IAppUserService service)
        {
            this.service = service;
        }

        [BindProperty]
        public IEnumerable<AppUser> AppUsers { get; set; }

        public async Task OnGetAsync()
        {
            AppUsers = await service.GetAllUsersAsync();
        }
    }
}
