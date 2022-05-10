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

        public CreateModel(IAppUserService userService, IApplicationService appService, IAdvertisementService advService, INotyfService notyfService, IMessageService messageService)
        {
            this.userService = userService;
            this.appService = appService;
            this.advService = advService;
            this.notyfService = notyfService;
            this.messageService = messageService;
        }

        public AppUser AppUser { get; set; }

        [BindProperty]
        public Application Application { get; set; }

        public Advertisement Advertisement { get; set; }

        public async Task OnGetAsync(int advertisementId)
        {
            Advertisement = await advService.GetAdvertisementByIdAsync(advertisementId);
            AppUser = await userService.GetLoggedUserAsync(User.Identity.Name);
        }

        public async Task<IActionResult> OnPostAsync(int advertisementId)
        {
            Advertisement = await advService.GetAdvertisementByIdAsync(advertisementId);
            AppUser = await userService.GetLoggedUserAsync(User.Identity.Name);
            string userId = AppUser.Id;
            await appService.CreateApplicationAsync(advertisementId, userId);
            await messageService.SendMessageAsync(new Message()
            {
                AppUserId = userId,
                Subject = $"You have applied for a position at {Advertisement.Company}",
                Content = $"On {DateTime.Now} you have applied for a {Advertisement.Position} position at {Advertisement.Company}." +
                $"Your application has been sent to the employer and will now be handled by them. In case of any questions please contact the company directly." +
                $"Thank you for using ZeaPloy."
            });
            notyfService.Success("You have succesfully applied for this advertisement. You can see it in your profile.");
            return RedirectToPage("/Advertisements/Advertisements");
        }
    }
}
