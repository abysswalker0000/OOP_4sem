using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Domain.Entities;
using WebApp.Infrastructure.DAL.Interfaces;

namespace WebApp.Web.Pages.Firestore
{
    public class IndexModel : PageModel
    {
        private readonly IFirestoreService _firestoreService;
        public Dictionary<string, bool> GameReviewsExist { get; private set; } = new Dictionary<string, bool>();

        public List<Game>? Games;
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public IndexModel(IFirestoreService firestoreService)
        {
            _firestoreService = firestoreService;
        }

        public async Task OnGetAsync()
        {
            Games = await _firestoreService.GetAllGames();
            if (!string.IsNullOrEmpty(SearchString))
            {
                Games = Games.Where(game => game.title != null && game.title.ToLower().Contains(SearchString.ToLower())).ToList();
            }
            var allReviews = await _firestoreService.GetAllReviews();
            GameReviewsExist = allReviews
                .GroupBy(review => review.gameId)
                .ToDictionary(group => group.Key, group => group.Any());
        }

    }
}
