using montiepy2.Models;

namespace montiepy2.Services.Blog
{
    public class BlogService : AbstractService, IBlogService
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