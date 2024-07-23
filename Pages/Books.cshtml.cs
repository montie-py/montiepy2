using Microsoft.AspNetCore.Mvc.RazorPages;
using montiepy2.Models;
using montiepy2.Services.Review;

namespace montiepy2.Pages
{
    public class BooksModel : PageModel
    {
        private readonly ReviewService reviewService;
        public List<ReviewEntry> BookReviewEntries { get; set; } = new();

        public BooksModel(ReviewService reviewService)
        {
            this.reviewService = reviewService;
        }

        public void OnGet()
        {
            BookReviewEntries = reviewService.GetAllReviewEntries(ReviewType.Books);
        }
    }
}