using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using montiepy.Services.Blog;
using montiepy2.Models;

namespace montiepy2.Pages.Private
{
    [Authorize]
    public class AddBlogEntry : PageModel
    {
        [BindProperty]
        public required string Title { get; set; }
        [BindProperty]
        public required string Text { get; set; }

        public void OnGet()
        {
            ViewData["area"] = "admin";
        }

        [HttpPost]
        public IActionResult OnPost()
        {
            BlogEntry blogEntry = new();
            blogEntry.Title = Title;
            blogEntry.Text = Text;
            blogEntry.Date = DateTime.Now;
            BlogService.AddNewBlogEntry(blogEntry);
            return RedirectToPage("/Private/Blog");
        }
    }
}