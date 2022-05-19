namespace zeaploy.Pages.Applications
{
    public class DeleteModel : PageModel
    {
        private readonly IAppUserService userService;
        private readonly IApplicationService appService;
        private readonly IAdvertisementService advService;
        private readonly INotyfService notyfService;
        private readonly IMessageService messageService;
        private readonly IFileService fileService;

        public DeleteModel(IAppUserService userService, IApplicationService appService, IAdvertisementService advService, INotyfService notyfService, IMessageService messageService, IFileService fileService)
        {
            this.userService = userService;
            this.messageService = messageService;
            this.appService = appService;
            this.advService = advService;
            this.notyfService = notyfService;
            this.fileService = fileService;
        }

        [BindProperty(SupportsGet = true)]
        public Application Application { get; set; }

        public async Task OnGetAsync(int applicationId)
        {
            Application = await appService.GetApplicationByIdAsync(applicationId);
        }

        public async Task<IActionResult> OnPostAsync(int applicationId)
        {
            Application = await appService.GetApplicationByIdAsync(applicationId);
            Advertisement advertisement = await advService.GetAdvertisementByIdAsync(Application.AdvertisementId);
            AppUser user = await userService.GetLoggedUserAsync(User.Identity.Name);

            fileService.DeleteApplicationFiles(user.Name, advertisement.Company);

            await appService.DeleteApplicationAsync(applicationId);

            if (User.IsInRole("Student"))
            {
                IEnumerable<AppUser> admins = await userService.GetAllAdminsAsync();

                foreach (var admin in admins)
                {
                    await messageService.SendMessageAsync(new Message()
                    {
                        AppUserId = admin.Id,
                        Subject = $"{user.Name} removed application",
                        Content = $"User: {user.Name} deleted application for a {advertisement.Position} " +
                        $" position in company: {advertisement.Company}"
                    });
                }

                notyfService.Success($"Your application for {advertisement.Position} position in {advertisement.Company} was successfully removed.");


                return RedirectToPage("/Profile/Applications");
            }
            else
            {
                notyfService.Success($"{user.Name} application for {advertisement.Position} position in {advertisement.Company} was successfully removed.");
                return RedirectToPage("/Applications/Applications");
            }

        }
    }
}
