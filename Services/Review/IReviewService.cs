using montiepy2.Models;

namespace montiepy2.Services.Review
{
    public interface IReviewService
    {
        public List<ReviewEntry> GetAllReviewEntries(ReviewType reviewType);
        public void AddNewReviewEntry(ReviewEntry reviewEntry, ReviewType reviewType);
    }
}