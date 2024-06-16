using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace montiepy2.Pages.Private
{
    [Authorize]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            ViewData["area"] = "admin";
        }
    }
}