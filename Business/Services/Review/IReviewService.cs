using montiepy2.Business.Models;

namespace montiepy2.Business.Services.Review
{
    public interface IReviewService
    {
        public List<ReviewEntry> GetAllReviewEntries(ReviewType reviewType);
        public void AddNewReviewEntry(ReviewEntry reviewEntry, ReviewType reviewType);
    }
}