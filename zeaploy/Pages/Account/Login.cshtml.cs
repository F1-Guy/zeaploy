namespace zeaploy.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<AppUser> signInManager;

        public LoginModel(SignInManager<AppUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        [BindProperty]
        public LoginViewModel LoginViewModel { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(LoginViewModel.Email, LoginViewModel.Password, LoginViewModel.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToPage("/Index");
                }
                else
                {
                    ModelState.AddModelError(String.Empty, "Invalid input data");
                }
            }

            return Page();
        }
    }
}
