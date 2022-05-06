using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace zeaploy.Pages.Applications
{
    [Authorize]
    public class CreateApplicationModel : PageModel
    {
        private IAppUserService userService;
        private IApplicationService appService;
        private IAdvertisementService advService;
        public CreateApplicationModel(IAppUserService userService, IApplicationService appService, IAdvertisementService advService)
        {
            this.userService = userService;
            this.appService = appService;
            this.advService = advService;
        }
        public AppUser AppUser { get; set; }
        [BindProperty]
        public Application App { get; set; }
        public Advertisement Adv { get; set; }
        public async Task OnGetAsync(int AdvId)
        {
            Adv = await advService.GetAdvertisementByIdAsync(AdvId);
            AppUser = await userService.GetLoggedUserAsync(User.Identity.Name);
        }
        public async Task<IActionResult> OnPostAsync(int advId)
        {
            AppUser = await userService.GetLoggedUserAsync(User.Identity.Name);
            string uId = AppUser.Id;
            await appService.CreateApplicationAsync(advId, uId);
            return RedirectToPage("/Advertisements/Advertisements");
        }
    }
}
