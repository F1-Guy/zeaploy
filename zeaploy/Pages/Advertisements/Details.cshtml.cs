namespace zeaploy.Pages.Advertisements
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly IAdvertisementService service;
        private readonly ICommentService cService;
        private readonly INotyfService nService;
        public DetailsModel(IAdvertisementService service, ICommentService cService, INotyfService nService)
        {
            this.service = service;
            this.cService = cService;
            this.nService = nService;
        }

        [BindProperty]
        public Advertisement Advertisement { get; set; }

        public IEnumerable<Comment> Comments { get; set; }

        [BindProperty]
        public Comment Comment { get; set; }

        public async Task OnGetAsync(int advertisementId)
        {
            Advertisement = await service.GetAdvertisementByIdAsync(advertisementId);
            Comments = await cService.GetCommentsAsync(advertisementId);
        }

        public async Task<IActionResult> OnPostAsync(int advertisementId)
        {
            if (String.IsNullOrEmpty(Comment.Content))
            {
                Advertisement = await service.GetAdvertisementByIdAsync(advertisementId);
                Comments = await cService.GetCommentsAsync(advertisementId);
                nService.Error("Comment cannot be empty.");
                return Page();
            }
            Advertisement = await service.GetAdvertisementByIdAsync(advertisementId);
            Comment.DateAdded = DateTime.Now;
            Comment.AdvertisementId = Advertisement.Id;
            await cService.CreateCommentAsync(Comment);
            Comments = await cService.GetCommentsAsync(advertisementId);
            return Page();
        }
    }
}
