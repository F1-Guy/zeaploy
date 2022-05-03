using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using zeaploy.Services.Interfaces;

namespace zeaploy.Pages.Advertisements
{
    public class CreateAdvertisementModel : PageModel
    {
        IAdvertisementService service;

        public CreateAdvertisementModel (IAdvertisementService aService)
        {
            service = aService;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync(Advertisement adv)
        {
                await service.CreateAdvertisementAsync(adv);
                return RedirectToPage("Advertisements");
        }
    }
}
