using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace zeaploy.Pages.Applications
{
    public class ApplicationsModel : PageModel
    {
        private IApplicationService appService;

        public ApplicationsModel(IApplicationService appService)
        {
            this.appService = appService;
        }
        public IEnumerable<Application> Applications { get; set; }
        public async Task OnGetAsync()
        {
            Applications = await appService.GetAllApplicationsAsync();
        }
    }
}
