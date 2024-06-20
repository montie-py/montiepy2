using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using montiepy.Services.Blog;
using montiepy2.Models;

namespace montiepy2.Pages.Private
{
    [Authorize]
    public class BlogModel : PageModel
    {
        public List<BlogEntry> BlogEntries { get; set; } = new();
        
        public void OnGet()
        {
            ViewData["area"] = "admin";
            BlogEntries = BlogService.GetAllBlogEntries();
        }
    }
}