namespace zeaploy.Pages.Profile
{
    public class EditModel : PageModel
    {
        private readonly IAppUserService service;
        private readonly INotyfService notyfService;
        private readonly Microsoft.AspNetCore.Hosting.IWebHostEnvironment env;

        public EditModel(IAppUserService service, INotyfService notyfService, Microsoft.AspNetCore.Hosting.IWebHostEnvironment env)
        {
            this.service = service;
            this.notyfService = notyfService;
            this.env = env;
        }

        [BindProperty]
        public AppUser LoggedInUser { get; set; }

        [BindProperty]
        public IFormFile? ImageUpload { get; set; }
        public async Task OnGetAsync()
        {
            LoggedInUser = await service.GetLoggedUserAsync(User.Identity.Name);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            
            if (ModelState.IsValid)
            {
                if (ImageUpload != null)
                {
                    LoggedInUser = await service.GetLoggedUserAsync(User.Identity.Name);
                    string relativePath = @"wwwroot\assets\";
                    var file = Path.Combine(relativePath, ImageUpload.FileName);
                    using (var fileStream = new FileStream(file, FileMode.Create))
                    {
                        await ImageUpload.CopyToAsync(fileStream);
                    }
                    LoggedInUser.ImagePath = ImageUpload.FileName;
                }
                else
                {
                    LoggedInUser = await service.GetLoggedUserAsync(User.Identity.Name);
                    LoggedInUser.ImagePath = null;
                }
                notyfService.Success("Your profile has been succesfully updated.");
                await service.EditUserAsync(LoggedInUser);
            }
            else
            {
                notyfService.Error("The data you entered is invalid. Please review the data and try again.");
                return Page();
            }

            return RedirectToPage("/Profile/Profile");
        }
    }
}
