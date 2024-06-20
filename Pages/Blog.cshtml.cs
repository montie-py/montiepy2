using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using montiepy.Services.Blog;
using montiepy2.Models;

namespace montiepy2.Pages
{
    public class BlogModel : PageModel
    {
        public List<BlogEntry> BlogEntries { get; set; } = new();

        public void OnGet()
        {
            BlogEntries = BlogService.GetAllBlogEntries();
        }
    }
}
