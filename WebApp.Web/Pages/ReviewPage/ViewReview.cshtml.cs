using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Domain.DTO;
using WebApp.Domain.Entities;
using WebApp.Infrastructure.DAL.Interfaces;

namespace WebApp.Web.Pages.ReviewPage
{
    public class ViewReviewModel : PageModel
    {
        private readonly IFirestoreService _firestoreService;
        public ReviewDto Review { get; private set; }
        public GameDto Game { get; private set; }
        public List<Comment> Comments { get; set; }

        public ViewReviewModel(IFirestoreService firestoreService)
        {
            _firestoreService = firestoreService;
        }

        public async Task<IActionResult> OnGetAsync(string gameId)
        {
            var review = await _firestoreService.GetReviewByGameId(gameId);
            if (review == null)
            {
                return RedirectToPage("/Firestore/Index");
            }

            Review = new ReviewDto
            {
                reviewId = review.reviewId, // Убедитесь, что это значение корректно
                gameId = review.gameId,
                content = review.content,
                rating = review.rating
            };

            var game = await _firestoreService.GetGameById(gameId);
            Game = new GameDto
            {
                title = game.title,
                description = game.description,
                genre = game.genre
            };
            
            return Page();
        }
    }
}
