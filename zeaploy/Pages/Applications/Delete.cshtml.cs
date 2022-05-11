using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace zeaploy.Pages.Applications
{
    public class DeleteModel : PageModel
    {
        private readonly IApplicationService service;

        public DeleteModel(IApplicationService service)
        {
            this.service = service;
        }

        [BindProperty(SupportsGet = true)]
        public Application Application { get; set; }

        public async Task OnGetAsync(int applicationId)
        {
            Application = await service.GetApplicationByIdAsync(applicationId);
        }

        public async Task<IActionResult> OnPostAsync(int applicationId)
        {
            await service.DeleteApplicationAsync(applicationId);
            return RedirectToPage("/Profile/Applications");
        }
    }
}
