using Microsoft.AspNetCore.Mvc.RazorPages;
using montiepy2.Business.Models;
using montiepy2.Business.Services.Blog;

namespace montiepy2.Core.Pages
{
    public class BlogModel : PageModel
    {
        private readonly IBlogService _blogService;
        public List<BlogEntry> BlogEntries { get; set; } = new();

        public BlogModel(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public void OnGet()
        {
            BlogEntries = _blogService.GetAllBlogEntries();
            BlogEntries.Reverse();
        }
    }
}
