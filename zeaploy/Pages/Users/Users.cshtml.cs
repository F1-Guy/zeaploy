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
        public string SearchCriteria { get; set; }

        [BindProperty]
        public IEnumerable<AppUser> AppUsers { get; set; }

        public async Task OnGetAsync()
        {
            AppUsers = await service.GetAllUsersAsync();

            if (String.IsNullOrEmpty(SearchCriteria))
            {
                AppUsers = await service.GetAllUsersAsync();
            }
            else
            {
                AppUsers = await service.FilterAsync(SearchCriteria);
            }
        }
    }
}
