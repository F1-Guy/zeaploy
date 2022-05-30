namespace zeaploy.Pages.Applications
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly IAppUserService userService;
        private readonly IApplicationService appService;
        private readonly IAdvertisementService advService;
        private readonly INotyfService notyfService;
        private readonly IMessageService messageService;
        private readonly IFileService fileService;

        public CreateModel(IAppUserService userService, IApplicationService appService, IAdvertisementService advService, INotyfService notyfService, IMessageService messageService, IFileService fileService)
        {
            this.userService = userService;
            this.appService = appService;
            this.advService = advService;
            this.notyfService = notyfService;
            this.messageService = messageService;
            this.fileService = fileService;
        }

        public AppUser AppUser { get; set; }

        [BindProperty]
        public Application Application { get; set; }

        public Advertisement Advertisement { get; set; }

#nullable enable
        [BindProperty]
        public IFormFile? CV { get; set; }

        [BindProperty]
        public IFormFile? CoverLetter { get; set; }
#nullable disable

        public async Task OnGetAsync(int advertisementId)
        {
            Advertisement = await advService.GetAdvertisementByIdAsync(advertisementId);
            AppUser = await userService.GetLoggedUserAsync(User.Identity.Name);
        }

        public async Task<IActionResult> OnPostAsync(int advertisementId)
        {
            Advertisement = await advService.GetAdvertisementByIdAsync(advertisementId);
            AppUser = await userService.GetLoggedUserAsync(User.Identity.Name);

            if (await appService.IsUserAppliedAsync(AppUser.Id, advertisementId))
            {
                notyfService.Error("You have already applied for this position");
                return Page();
            }
            else
            {
                string userId = AppUser.Id;
                if (CV != null && CoverLetter != null)
                {
                    try
                    {
                        await fileService.UploadApplicationFileAsync(CV, AppUser.Name, Advertisement.Company);
                        await fileService.UploadApplicationFileAsync(CoverLetter, AppUser.Name, Advertisement.Company);
                    }
                    catch (InvalidDataException)
                    {
                        notyfService.Error("You tried to upload an unsupported file type. Please try again.");
                        return Page();
                    }

                    await appService.CreateApplicationAsync(advertisementId, userId);
                    await messageService.SendMessageAsync(new Message()
                    {
                        AppUserId = userId,
                        Subject = $"You have applied for a position at {Advertisement.Company}",
                        Content = $"On {DateTime.Now} you have applied for a {Advertisement.Position} position at {Advertisement.Company}. " +
                    $"Your application has been sent to the employer and will now be handled by them. In case of any questions please contact the company directly. " +
                    $"Thank you for using ZeaPloy."
                    });

                    IEnumerable<AppUser> admins = await userService.GetAllAdminsAsync();

                    foreach (AppUser admin in admins)
                    {
                        await messageService.SendMessageAsync(new Message()
                        {
                            AppUserId = admin.Id,
                            Subject = $"{AppUser.Name} applied for a position",
                            Content = $"User: {AppUser.Name} applied for a {Advertisement.Position} " +
                            $" position in company: {Advertisement.Company}"
                        });
                    }
                    notyfService.Success("You have successfully applied for this advertisement. You can see it in your profile.");
                    return RedirectToPage("/Advertisements/Advertisements");
                }

                else
                {
                    notyfService.Error("All files must be uploaded. Please try again.");
                    return Page();
                }

            }

        }
    }
}
