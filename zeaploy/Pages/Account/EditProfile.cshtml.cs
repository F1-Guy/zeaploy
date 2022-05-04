using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace zeaploy.Pages.Account
{
    public class EditProfileModel : PageModel
    {
        private IAppUserService appUserService;

        public EditProfileModel(IAppUserService service)
        {
            appUserService = service;
        }

        [BindProperty]
        public AppUser LoggedUser { get; set; }
        
        public async Task OnGetAsync(string Email)
        {
            LoggedUser = await appUserService.GetLoggedUserAsync(User.Identity.Name);
        }

    }
}
