using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using montiepy2.Business.Services.Blog;
using montiepy2.Business.Models;

namespace montiepy2.Core.Pages.Private
{
    [Authorize]
    public class AddBlogEntry : PageModel
    {
        private readonly IBlogService blogService;

        public AddBlogEntry(IBlogService blogService)
        {
            this.blogService = blogService;
        }

        [BindProperty]
        public required string Title { get; set; }
        [BindProperty]
        public required string Text { get; set; }

        public void OnGet()
        {
            ViewData["area"] = "admin";
        }

        public IActionResult OnPost()
        {
            BlogEntry blogEntry = new()
            {
                Title = Title,
                Text = Text,
                Date = DateTime.Now
            };
            blogService.AddNewBlogEntry(blogEntry);
            return RedirectToPage("/Private/Blog");
        }
    }
}