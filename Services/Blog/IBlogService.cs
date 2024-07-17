using montiepy2.Models;

namespace montiepy2.Services.Blog
{
    public interface IBlogService{
        public List<BlogEntry> GetAllBlogEntries();
        public void AddNewBlogEntry(BlogEntry blogEntry);
    }
}