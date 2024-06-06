using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Domain.DTO;
using WebApp.Domain.Entities;

namespace WebApp.Infrastructure.DAL.Interfaces
{
    public interface IFirestoreService
    {
        Task<List<Game>> GetAllGames();
        Task AddGameAsync(Game game);

        Task<List<Review>> GetAllReviews();
        Task AddReviewAsync(Review review);
        Task<Review> GetReviewByGameId(string gameId);
        Task<Game> GetGameById(string gameId);
        Task AddCommentAsync(Comment comment);
        Task<List<Comment>> GetAllComments();
        Task<Review> GetReviewById(string reviewId);
    }
}
