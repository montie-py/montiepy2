using montiepy2.Models;

namespace montiepy2.Services.Review
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