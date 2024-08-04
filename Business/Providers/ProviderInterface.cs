using montiepy2.Business.Models;

namespace montiepy2.Business.Providers
{
    public interface ProviderInterface
    {
        List<BlogEntry> GetAllBlogEntries();
        List<ReviewEntry> GetAllReviewEntries(ReviewType reviewType);
        void AddNewBlogEntry(BlogEntry blogEntry);
        void AddNewReviewEntry(ReviewEntry reviewEntry, ReviewType reviewType);
    }
}