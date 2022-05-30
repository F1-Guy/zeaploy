namespace zeaploy.Pages.Profile
{
    [Authorize]
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

        public AppUser AppUser { get; set; }

#nullable enable
        [BindProperty]
        public IFormFile? ImageUpload { get; set; }
#nullable disable

        public async Task OnGetAsync()
        {
            LoggedInUser = await service.GetLoggedUserAsync(User.Identity.Name);
        }

        public async Task<IActionResult> OnPostAsync(AppUser LoggedInUser)
        {

            if (ModelState.IsValid)
            {
                if (ImageUpload != null)
                {
                    AppUser = await service.GetLoggedUserAsync(User.Identity.Name);
                    try
                    {
                        await fileService.UploadProfilePictureAsync(ImageUpload, AppUser.Id);
                    }
                    catch (InvalidDataException)
                    {
                        notyfService.Error("You tried to upload an unsupported file type. Please try again.");
                        return Page();
                    }
                    AppUser.ImagePath = ImageUpload.FileName;
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

        public async Task<IActionResult> OnPostRemoveAsync()
        {
            AppUser = await service.GetLoggedUserAsync(User.Identity.Name);
            fileService.DeleteProfilePicture(AppUser.Id);
            AppUser.ImagePath = null;
            await service.EditUserAsync(AppUser);
            return RedirectToPage("/Profile/Profile");
        }
    }
}
