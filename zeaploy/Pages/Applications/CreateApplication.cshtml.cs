using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace zeaploy.Pages.Applications
{
    public class CreateApplicationModel : PageModel
    {
        public DateTime created = DateTime.Now;
        public void OnGet()
        {
        }
    }
}
