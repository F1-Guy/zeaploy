namespace zeaploy.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<AppUser> signInManager;
        public LogoutModel(SignInManager<AppUser> signInManager)
        {
            this.signInManager = signInManager;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            await signInManager.SignOutAsync();
            return RedirectToPage("/Index");
        }
    }
}
