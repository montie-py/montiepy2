using Microsoft.AspNetCore.Mvc.RazorPages;
using montiepy2.Business.Models;
using montiepy2.Business.Services.Blog;

namespace montiepy2.Core.Pages
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
            BlogEntries.Reverse();
        }
    }
}
