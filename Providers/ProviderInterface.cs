using montiepy2.Models;

namespace montiepy2.Providers
{
    public interface ProviderInterface
    {
        List<BlogEntry> GetAllBlogEntries();
        void AddNewBlogEntry(BlogEntry blogEntry);
    }
}