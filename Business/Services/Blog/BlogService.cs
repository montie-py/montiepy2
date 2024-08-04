using montiepy2.Business.Models;

namespace montiepy2.Business.Services.Blog
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