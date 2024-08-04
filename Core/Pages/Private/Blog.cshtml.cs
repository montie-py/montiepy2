using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using montiepy2.Business.Services.Blog;
using montiepy2.Business.Models;

namespace montiepy2.Core.Pages.Private
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
            BlogEntries.Reverse();
        }
    }
}