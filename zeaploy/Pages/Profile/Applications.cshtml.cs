namespace zeaploy.Pages.Profile
{
    [Authorize(Roles = "Student")]
    public class ApplicationsModel : PageModel
    {
        private readonly IApplicationService appService;

        public ApplicationsModel(IApplicationService appService)
        {
            this.appService = appService;
        }

        public IEnumerable<Application> Applications { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchCriteria { get; set; }

        public async Task OnGetAsync()
        {
            if (!String.IsNullOrEmpty(SearchCriteria))
            {
                Applications = await appService.FilterUsersAsync(SearchCriteria, User.Identity.Name);
            }
            else
            {
                Applications = await appService.GetApplicationsByUserAsync(User.Identity.Name);
            }
        }
    }
}
