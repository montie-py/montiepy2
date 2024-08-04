using montiepy2.Business.Models;

namespace montiepy2.Business.Services.Blog
{
    public interface IBlogService{
        public List<BlogEntry> GetAllBlogEntries();
        public void AddNewBlogEntry(BlogEntry blogEntry);
    }
}