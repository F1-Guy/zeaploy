namespace zeaploy.Account
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IAppUserService appUserService;

        public RegisterModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IAppUserService appUserService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.appUserService = appUserService;
        }

        [BindProperty]
        public RegisterViewModel Registration { get; set; }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var user = new IdentityUser() { Email = Registration.Email, UserName = Registration.Email };
            IdentityResult result = await userManager.CreateAsync(user, Registration.Password);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Student");
                await signInManager.SignInAsync(user, isPersistent: false);
                AppUser appUser = new AppUser() { Email = Registration.Email };
                await appUserService.CreateAppUserAsync(appUser);
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
