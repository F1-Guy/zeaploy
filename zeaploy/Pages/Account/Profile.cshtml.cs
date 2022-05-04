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
        public AppUser AppUser { get; set; }
        public void OnGet()
        {
        }
    }
}
