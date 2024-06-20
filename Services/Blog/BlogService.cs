using montiepy2.Models;

namespace montiepy.Services.Blog
{
    public static class BlogService
    {
        public static List<BlogEntry> GetAllBlogEntries()
        {
            List<BlogEntry> BlogEntries = new();
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
            return BlogEntries;
        }
    }
}