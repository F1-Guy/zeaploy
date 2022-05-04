using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace zeaploy.Pages.Account
{
    public class ProfileModel : PageModel
    {
        private IAppUserService appUserService;
        public ProfileModel(IAppUserService service)
        {
            this.appUserService = service;
        }
        [BindProperty]
        public AppUser LoggedUser { get; set; }
        public async Task OnGetAsync(string Email)
        {
            LoggedUser = await appUserService.GetLoggedUserAsync(User.Identity.Name);
        }
    }
}
