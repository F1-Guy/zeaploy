using Microsoft.AspNetCore.Authorization;

namespace zeaploy.Pages.Advertisements
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        IAdvertisementService service;

        public CreateModel(IAdvertisementService aService)
        {
            service = aService;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync(Advertisement adv)
        {
            adv.Posted = DateTime.Now;
            await service.CreateAdvertisementAsync(adv);
            return RedirectToPage("Advertisements");
        }
    }
}
