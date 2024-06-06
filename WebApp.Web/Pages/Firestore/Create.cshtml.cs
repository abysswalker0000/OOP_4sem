using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Domain.DTO;
using WebApp.Domain.Entities;
using WebApp.Infrastructure.DAL.Interfaces;

namespace WebApp.Web.Pages.Firestore
{
    public class CreateModel : PageModel
    {
        private readonly IFirestoreService _firestoreService;
        public List<string> Genres { get; } = new List<string>
    {
        "Action", "Adventure", "Role-Playing", "Simulation", "Strategy",
    "Sports", "Puzzle", "Idle", "Arcade", "Shooter", "Fighting", "Platformer",
    "Racing", "Horror", "Music", "Party", "Educational", "VR", "Card & Board",
    "MMORPG", "MOBA", "Battle Royale", "Stealth", "Survival", "Sandbox",
    "Visual Novel", "Interactive Drama", "Fitness", "Tycoon", "Tower Defense",
    "Point & Click", "Rhythm", "Trivia", "Text Adventure", "Roguelike",
    "Tactical RPG", "Shoot 'em up", "Beat 'em up", "Hack and Slash",
    "Pinball", "Dating Simulator", "Flight Simulator", "Naval Combat Simulator",
    "Space Simulator", "Farming", "Mystery", "Historical", "Steampunk",
    "Fantasy", "Sci-Fi", "Post-Apocalyptic", "Zombie", "Western",
    "War", "Espionage", "Urban", "Wildlife", "Marine", "Prehistoric",
    "Mythology", "Magic", "Superhero", "Detective", "Comedy",
    "Drama", "Anime", "Family", "Children's", "Educational"
    };
        private readonly IFirebaseStorageService _storageService;
        [BindProperty]
        public GameDto Game { get; set; }

        public CreateModel(IFirestoreService firestoreService, IFirebaseStorageService storageService)
        {
            _firestoreService = firestoreService;
            _storageService = storageService;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _firestoreService.AddGameAsync(new Game
            {
                title = Game.title,
                description = Game.description,
                genre = Game.genre,
             
            });
            return RedirectToPage("Index");
        }
    }
}
