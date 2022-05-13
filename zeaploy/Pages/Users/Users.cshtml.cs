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

        [BindProperty(SupportsGet = true)]
        public string Criteria { get; set; }

        [BindProperty]
        public IEnumerable<AppUser> AppUsers { get; set; }

        public async Task OnGetAsync()
        {
            AppUsers = await service.GetAllUsersAsync();

            if (String.IsNullOrEmpty(Criteria))
            {
                AppUsers = await service.GetAllUsersAsync();
            }
            else
            {
                AppUsers = service.Filter(u => (u.Name.Contains(Criteria, StringComparison.OrdinalIgnoreCase) 
                                             || u.Email.Contains(Criteria, StringComparison.OrdinalIgnoreCase) 
                                             || u.Course.Contains(Criteria, StringComparison.OrdinalIgnoreCase)));
            }
        }
    }
}
