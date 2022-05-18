using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace zeaploy.Pages.Advertisements
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly IAdvertisementService adService;
        private readonly INotyfService notyfService;
        public EditModel (IAdvertisementService service, INotyfService notyfService)
        {
            this.adService = service;
            this.notyfService = notyfService;
        }
        [BindProperty]
        public Advertisement Advertisement { get; set; }
        public async Task OnGetAsync(int advertisementId)
        {
            Advertisement = await adService.GetAdvertisementByIdAsync(advertisementId);
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                notyfService.Error("The details you entered are not correct. Please review the data and try again.");
                return Page();
            }
            await adService.EditAdvertisementAsync(Advertisement);
            return RedirectToPage("/Advertisements/Advertisements");
        }
    }
}
