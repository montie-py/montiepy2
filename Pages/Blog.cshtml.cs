using Microsoft.AspNetCore.Mvc.RazorPages;
using montiepy2.Models;
using montiepy2.Services.Blog;

namespace montiepy2.Pages
{
    public class BlogModel : PageModel
    {
        private readonly IBlogService blogService;
        public List<BlogEntry> BlogEntries { get; set; } = new();

        public BlogModel(IBlogService blogService)
        {
            this.blogService = blogService;
        }

        public void OnGet()
        {
            BlogEntries = blogService.GetAllBlogEntries();
        }
    }
}
