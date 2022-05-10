namespace zeaploy.Account
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly INotyfService notyfService;

        public RegisterModel(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, INotyfService notyfService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.notyfService = notyfService;
        }

        [BindProperty]
        public RegisterViewModel Registration { get; set; }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                notyfService.Error("The information you have entered is not correct. Review the data and try again.");
                return Page();
            }
            var user = new AppUser() { Email = Registration.Email, UserName = Registration.Email, Name = Registration.Name };
            IdentityResult result = await userManager.CreateAsync(user, Registration.Password);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Student");
                await signInManager.SignInAsync(user, isPersistent: false);
                notyfService.Success("Your account has been created. You can proceed to use the website.");
                return RedirectToPage("/Index");
            }
            else
            {
                
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return Page();
            }
        }
    }
}
