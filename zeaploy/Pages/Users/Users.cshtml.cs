namespace zeaploy.Pages.Users
{
    [Authorize(Roles = "Admin")]
    public class UsersModel : PageModel
    {
        private readonly IAppUserService service;
        public UsersModel(IAppUserService service)
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
