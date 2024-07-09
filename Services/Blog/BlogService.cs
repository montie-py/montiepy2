using montiepy2.Models;
using montiepy2.Services;

namespace montiepy.Services.Blog
{
    public class BlogService : AbstractService
    {   
        public List<BlogEntry> GetAllBlogEntries()
        {
            return Db.GetAllBlogEntries();
        }

        public void AddNewBlogEntry(BlogEntry blogEntry)
        {
            Db.AddNewBlogEntry(blogEntry);
        }
    }
}