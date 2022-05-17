namespace zeaploy.Pages.Profile
{
    public class EditModel : PageModel
    {
        private readonly IAppUserService service;
        private readonly INotyfService notyfService;
        private readonly IFileService fileService;

        public EditModel(IAppUserService service, INotyfService notyfService, IFileService fileService)
        {
            this.service = service;
            this.notyfService = notyfService;
            this.fileService = fileService;
        }

        [BindProperty]
        public AppUser LoggedInUser { get; set; }

#nullable enable
        [BindProperty]
        public IFormFile? ImageUpload { get; set; }
#nullable disable

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
                    await fileService.UploadProfilePictureAsync(ImageUpload, LoggedInUser.Name);
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
