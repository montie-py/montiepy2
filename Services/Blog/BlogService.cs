using System.Text;
using montiepy2.Models;

namespace montiepy.Services.Blog
{
    public static class BlogService
    {
        private const string FileName = "blog.txt";
        private const string EntryDelimiter = "---";
        private const string EntryItemDelimiter = "|";
        public static List<BlogEntry> GetAllBlogEntries()
        {
            List<BlogEntry> BlogEntries = new();
            string blogEntriesText = File.ReadAllText(FileName);
            string[] blogEntries = blogEntriesText.Split(EntryDelimiter);
            foreach (string blogEntry in blogEntries)
            {
                if (String.IsNullOrEmpty(blogEntry)) {
                    continue;
                }
                BlogEntry BlogEntry = new BlogEntry();
                var entryParts = blogEntry.Split(EntryItemDelimiter);
                BlogEntry.Title = entryParts[0];
                BlogEntry.Date = DateTimeOffset.FromUnixTimeSeconds(long.Parse(entryParts[1])).DateTime;
                BlogEntry.Text = entryParts[2];
                BlogEntries.Add(BlogEntry);
            }
            return BlogEntries;
        }

        public static void AddNewBlogEntry(BlogEntry blogEntry)
        {
            var blogEntryRow = new StringBuilder();
            blogEntryRow.AppendLine();
            blogEntryRow.Append(blogEntry.Title);
            blogEntryRow.Append(EntryItemDelimiter);
            blogEntryRow.Append(((DateTimeOffset)blogEntry.Date).ToUnixTimeSeconds());
            blogEntryRow.Append(EntryItemDelimiter);
            blogEntryRow.Append(blogEntry.Text);
            blogEntryRow.AppendLine();
            blogEntryRow.Append(EntryDelimiter);
            File.AppendAllText(FileName, blogEntryRow.ToString());
        }
    }
}