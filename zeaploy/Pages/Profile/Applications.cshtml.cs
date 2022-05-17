using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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

        public async Task OnGetAsync()
        {
            Applications = await appService.GetApplicationsByUserAsync(User.Identity.Name); 
        }
    }
}
