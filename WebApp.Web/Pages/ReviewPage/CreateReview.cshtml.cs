using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Domain.DTO;
using WebApp.Domain.Entities;
using WebApp.Infrastructure.DAL.Interfaces;

namespace WebApp.Web.Pages.ReviewPage
{
    public class CreateReviewModel : PageModel
    {
        private readonly IFirestoreService _firestoreService;
       

        [BindProperty]
        public string gameId { get; set; }
        [BindProperty]
        public ReviewDto Review { get; set; }

        public CreateReviewModel(IFirestoreService firestoreService)
        {
            _firestoreService = firestoreService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            gameId = Request.Query["gameId"].ToString();
            var existingReview = await _firestoreService.GetReviewByGameId(gameId);
            if (existingReview != null)
            {
                
                return RedirectToPage("/ReviewPage/ViewReview", new { gameId = gameId });
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
           
            var existingReview = await _firestoreService.GetReviewByGameId(gameId);
            if (existingReview != null)
            {
                
                return RedirectToPage("/ReviewPage/ViewReview", new { gameId = gameId });
            }

            await _firestoreService.AddReviewAsync(new Review
            {
                gameId = gameId,
                rating = Review.rating,
                content = Review.content
            });
            return RedirectToPage("/Firestore/Index");
        }
    }
}
