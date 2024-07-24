using System.Text;
using montiepy2.AbstractHandlers;
using montiepy2.Models;

namespace montiepy2.Providers{
    public class FileProvider : AbstractFileHandler, ProviderInterface
    {
        private string BlogFileName = "blog.txt";
        private string ReviewFileName = "_review.txt";
        private const string EntryDelimiter = "---";
        private const string EntryItemDelimiter = "|";

        public void AddNewBlogEntry(BlogEntry blogEntry)
        {
            CreateFileIfNotExists(BlogFileName);

            var blogEntryRow = new StringBuilder();
            blogEntryRow.AppendLine();
            blogEntryRow.Append(blogEntry.Title);
            blogEntryRow.Append(EntryItemDelimiter);
            blogEntryRow.Append(((DateTimeOffset)blogEntry.Date).ToUnixTimeSeconds());
            blogEntryRow.Append(EntryItemDelimiter);
            blogEntryRow.Append(blogEntry.Text);
            blogEntryRow.AppendLine();
            blogEntryRow.Append(EntryDelimiter);
            File.AppendAllText(BlogFileName, blogEntryRow.ToString());
        }

        public void AddNewReviewEntry(ReviewEntry reviewEntry, ReviewType reviewType)
        {
            string fileName = reviewType+ReviewFileName;
            CreateFileIfNotExists(fileName);

            var blogEntryRow = new StringBuilder();
            blogEntryRow.AppendLine();
            blogEntryRow.Append(reviewEntry.ItemTitle);
            blogEntryRow.Append(EntryItemDelimiter);
            blogEntryRow.Append(reviewEntry.ReviewText);
            blogEntryRow.AppendLine();
            blogEntryRow.Append(EntryDelimiter);
            File.AppendAllText(reviewType+ReviewFileName, blogEntryRow.ToString());
        }

        public List<BlogEntry> GetAllBlogEntries()
        {
            CreateFileIfNotExists(BlogFileName);

            List<BlogEntry> BlogEntries = new();
            string blogEntriesText = File.ReadAllText(BlogFileName);
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

        public List<ReviewEntry> GetAllReviewEntries(ReviewType reviewType)
        {
            string fileName = reviewType+ReviewFileName;
            CreateFileIfNotExists(fileName);

            List<ReviewEntry> ReviewEntries = new();
            string reviewsEntriesText = File.ReadAllText(fileName);
            string[] blogEntries = reviewsEntriesText.Split(EntryDelimiter);
            foreach (string blogEntry in blogEntries)
            {
                if (String.IsNullOrEmpty(blogEntry)) {
                    continue;
                }
                ReviewEntry ReviewEntry = new ReviewEntry();
                var entryParts = blogEntry.Split(EntryItemDelimiter);
                ReviewEntry.ItemTitle = entryParts[0];
                ReviewEntry.ReviewText = entryParts[1];
                ReviewEntries.Add(ReviewEntry);
            }
            return ReviewEntries;
        }

    }
}