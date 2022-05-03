using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using zeaploy.Services.Interfaces;

namespace zeaploy.Pages.Advertisements
{
    public class AdvertisementsModel : PageModel
    {
        private IAdvertisementService adService;

        public IEnumerable<Advertisement> Advertisements { get; set; }

        public AdvertisementsModel(IAdvertisementService service)
        {
            adService = service;
        }
        public void OnGet()
        {
            Advertisements = adService.GetAllAdvertisements();
        }
    }
}
