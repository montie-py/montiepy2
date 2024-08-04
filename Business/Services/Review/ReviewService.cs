using montiepy2.Business.Models;

namespace montiepy2.Business.Services.Review
{
    public class ReviewService : AbstractService, IReviewService
    {
        public void AddNewReviewEntry(ReviewEntry reviewEntry, ReviewType reviewType)
        {
            Db.AddNewReviewEntry(reviewEntry, reviewType);
        }

        public List<ReviewEntry> GetAllReviewEntries(ReviewType reviewType)
        {
            return Db.GetAllReviewEntries(reviewType);
        }
    }
}