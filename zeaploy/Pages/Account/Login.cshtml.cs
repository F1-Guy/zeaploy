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

        public async Task<IActionResult> OnPostAsync(string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(LoginViewModel.Email, LoginViewModel.Password, LoginViewModel.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    if (!String.IsNullOrEmpty(returnUrl))
                    {
                        return RedirectToPage(returnUrl);
                    }
                    else
                    {
                        return RedirectToPage("/Index");
                    }
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
