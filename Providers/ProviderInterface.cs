using montiepy2.Models;

namespace montiepy2.Providers
{
    public interface ProviderInterface
    {
        List<BlogEntry> GetAllBlogEntries();
        List<ReviewEntry> GetAllReviewEntries(ReviewType reviewType);
        void AddNewBlogEntry(BlogEntry blogEntry);
        void AddNewReviewEntry(ReviewEntry reviewEntry, ReviewType reviewType);
    }
}