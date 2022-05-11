using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace zeaploy.Pages.Advertisements
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly IAdvertisementService adService;

        public DeleteModel(IAdvertisementService service)
        {
            adService = service;
        }
        [BindProperty]
        public Advertisement Advertisement {get;set;}

        public async Task OnGetAsync(int advertisementId)
        {
            Advertisement = await adService.GetAdvertisementByIdAsync(advertisementId);
        }
        public async Task<IActionResult> OnPostAsync(int advertisementId)
        {
            await adService.DeleteAdvertisementAsync(advertisementId);
            return RedirectToPage("/Advertisements/Advertisements");
        }
    }
}
