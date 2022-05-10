using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace zeaploy.Pages.Profile
{
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
            string userEmail = User.Identity.Name;

            Applications = await appService.GetApplicationsByUserAsync(userEmail); 
        }
    }
}
