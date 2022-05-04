namespace zeaploy.Account
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public RegisterModel(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [BindProperty]
        public RegisterViewModel Registration { get; set; }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var user = new AppUser() {Email = Registration.Email, UserName = Registration.Email };
            IdentityResult result = await userManager.CreateAsync(user, Registration.Password);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Student");
                await signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToPage("/Index");
            }
            else
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return Page();
            }
        }
    }
}
