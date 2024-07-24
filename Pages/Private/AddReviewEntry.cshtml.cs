using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using montiepy2.Models;
using montiepy2.Services.Review;

namespace montiepy2.Pages.Private
{
    [Authorize]
    public class AddReviewEntry : PageModel
    {
        private readonly IReviewService reviewService;

        public AddReviewEntry(IReviewService reviewService)
        {
            this.reviewService = reviewService;
        }

        [BindProperty]
        public required string ItemTitle { get; set; }
        
        [BindProperty]
        public required string ReviewText { get; set; }
        
        [BindProperty]
        public required ReviewType Type { get; set; }

        public void OnGet()
        {
            ViewData["area"] = "admin";
        }

        public IActionResult OnPost()
        {
            ReviewEntry reviewEntry = new()
            {
                ItemTitle = ItemTitle,
                ReviewText = ReviewText
            };
            reviewService.AddNewReviewEntry(reviewEntry, Type);
            return RedirectToPage("/Private/Books");
        }
    }
}