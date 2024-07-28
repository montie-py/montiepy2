using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using montiepy2.Models;
using montiepy2.Services.Review;

namespace montiepy2.Pages.Private
{
    [Authorize]
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
            ViewData["area"] = "admin";
            BookReviewEntries = reviewService.GetAllReviewEntries(ReviewType.Books);
            BookReviewEntries.Reverse();
        }
    }
}