using System.Text;
using montiepy2.Business.AbstractHandlers;
using montiepy2.Business.Models;

namespace montiepy2.Business.Providers{
    public class FileProvider : AbstractFileHandler, ProviderInterface
    {
        private string BlogFileName = "blog.txt";
        private string ReviewFileName = "_review.txt";
        private const string EntryDelimiter = "---";
        private const string EntryItemDelimiter = "|";

        public void AddNewBlogEntry(BlogEntry blogEntry)
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
            AppendAllText(BlogFileName, blogEntryRow.ToString());
        }

        public void AddNewReviewEntry(ReviewEntry reviewEntry, ReviewType reviewType)
        {
            string fileName = reviewType+ReviewFileName;

            var blogEntryRow = new StringBuilder();
            blogEntryRow.AppendLine();
            blogEntryRow.Append(reviewEntry.ItemTitle);
            blogEntryRow.Append(EntryItemDelimiter);
            blogEntryRow.Append(reviewEntry.ReviewText);
            blogEntryRow.AppendLine();
            blogEntryRow.Append(EntryDelimiter);
            AppendAllText(reviewType+ReviewFileName, blogEntryRow.ToString());
        }

        public List<BlogEntry> GetAllBlogEntries()
        {
            List<BlogEntry> BlogEntries = new();
            string blogEntriesText = ReadAllText(BlogFileName);
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
            //TODO move ReadAllText to the AbstractFileHander class, create a following condition:
            /*
            if (!File.Exists(path))
            {
                // Create the file
                using (FileStream fs = File.Create(path))
                {
                    // Optionally write some data to the file
                    Byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");
                    fs.Write(info, 0, info.Length);
                }
                Console.WriteLine("File created successfully.");
            }
            else
            {
                Console.WriteLine("File already exists.");
            }
            */
            //examples with the FileStream class: https://learn.microsoft.com/en-us/dotnet/api/system.io.filestream

             
            string fileName = reviewType+ReviewFileName;

            List<ReviewEntry> ReviewEntries = new();
            string reviewsEntriesText = ReadAllText(fileName);
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