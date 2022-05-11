using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace zeaploy.Pages.Advertisements
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly IAdvertisementService adService;
        public EditModel (IAdvertisementService service)
        {
            this.adService = service;
        }
        [BindProperty]
        public Advertisement Advertisement { get; set; }
        public async Task OnGetAsync(int advertisementId)
        {
            Advertisement = await adService.GetAdvertisementByIdAsync(advertisementId);
        }
        public async Task<IActionResult> OnPostAsync()
        {
            await adService.EditAdvertisementAsync(Advertisement);
            return RedirectToPage("/Advertisements/Advertisements");
        }
    }
}
