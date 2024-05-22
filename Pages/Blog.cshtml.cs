using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using montiepy2.Models;

namespace montiepy2.Pages
{
    public class BlogModel : PageModel
    {
        public List<BlogEntry> BlogEntries { get; set; } = new();

        public void OnGet()
        {
            string blogEntriesText = System.IO.File.ReadAllText("blog.txt");
            string[] blogEntries = blogEntriesText.Split("---");
            foreach (string blogEntry in blogEntries)
            {
                BlogEntry BlogEntry = new BlogEntry();
                var entryParts = blogEntry.Split("|");
                BlogEntry.Title = entryParts[0];
                BlogEntry.Date = DateTimeOffset.FromUnixTimeSeconds(long.Parse(entryParts[1])).DateTime;
                BlogEntry.Text = entryParts[2];
                BlogEntries.Add(BlogEntry);
            }
        }
    }
}
