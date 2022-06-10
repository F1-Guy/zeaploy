namespace zeaploy.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly INotyfService notyfService;

        public LogoutModel(SignInManager<AppUser> signInManager, INotyfService notyfService)
        {
            this.signInManager = signInManager;
            this.notyfService = notyfService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            await signInManager.SignOutAsync();
            notyfService.Information("You have successfully logged out");
            return RedirectToPage("/Index");
        }
    }
}
