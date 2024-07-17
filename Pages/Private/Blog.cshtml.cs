using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using montiepy2.Services.Blog;
using montiepy2.Models;

namespace montiepy2.Pages.Private
{
    [Authorize]
    public class BlogModel : PageModel
    {
        private readonly IBlogService blogService;

        public BlogModel(IBlogService blogService)
        {
            this.blogService = blogService;
        }
        public List<BlogEntry> BlogEntries { get; set; } = new();
        
        public void OnGet()
        {
            ViewData["area"] = "admin";
            BlogEntries = blogService.GetAllBlogEntries();
        }
    }
}