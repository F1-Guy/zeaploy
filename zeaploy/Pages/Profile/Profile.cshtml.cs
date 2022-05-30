namespace zeaploy.Pages.Account
{
    [Authorize]
    public class ProfileModel : PageModel
    {
        private readonly IAppUserService service;
        private readonly IMessageService mService;

        public ProfileModel(IAppUserService service, IMessageService mService)
        {
            this.service = service;
            this.mService = mService;
        }

        [BindProperty]
        public AppUser LoggedInUser { get; set; }

        public IEnumerable<Message> Messages { get; set; }

        public async Task OnGetAsync()
        {
            LoggedInUser = await service.GetLoggedUserAsync(User.Identity.Name);
            Messages = await mService.GetMessagesAsync(LoggedInUser.Id);
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            Message message = await mService.GetMessageByIdAsync(id);
            await mService.DeleteMessageAsync(message);
            return RedirectToPage("/Profile/Profile");
        }
    }
}
