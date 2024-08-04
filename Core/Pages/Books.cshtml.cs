using Microsoft.AspNetCore.Mvc.RazorPages;
using montiepy2.Business.Models;
using montiepy2.Business.Services.Review;

namespace montiepy2.Core.Pages
{
    public class BooksModel : PageModel
    {
        private readonly IReviewService reviewService;
        public List<ReviewEntry> BookReviewEntries { get; set; } = new();

        public BooksModel(IReviewService reviewService)
        {
            this.reviewService = reviewService;
        }

        public void OnGet()
        {
            BookReviewEntries = reviewService.GetAllReviewEntries(ReviewType.Books);
            BookReviewEntries.Reverse();
        }
    }
}