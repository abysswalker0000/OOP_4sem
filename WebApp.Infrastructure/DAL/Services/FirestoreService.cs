using Google.Cloud.Firestore;
using WebApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Domain.FirestoreData;
using WebApp.Infrastructure.DAL.Interfaces;
using Markdig;
using WebApp.Domain.DTO;

namespace WebApp.Infrastructure.DAL.Services
{
    public class FirestoreService : IFirestoreService
    {
        private readonly FirestoreDb _firestoreDb;
        private const string _gamesCollectionName = "Games";
        private const string _reviewsCollectionName = "Reviews";
        private const string _commentsCollectionName = "Comments";
        public FirestoreService(FirestoreDb firestoreDb)
        {
            _firestoreDb = firestoreDb;
        }

        public async Task<List<Game>> GetAllGames()
        {
            var collection = _firestoreDb.Collection(_gamesCollectionName);
            var snapshot = await collection.GetSnapshotAsync();

            var gameDocuments = snapshot.Documents.Select(doc => doc.ConvertTo<GameDocument>()).ToList();
            return gameDocuments.Select(ConvertGameDocumentToModel).ToList();
        }

        public async Task<List<Comment>> GetAllComments()
        {
            var collection = _firestoreDb.Collection(_commentsCollectionName);
            var snapshot = await collection.GetSnapshotAsync();

            var commentDocuments = snapshot.Documents.Select(doc => doc.ConvertTo<CommentDocument>()).ToList();
            return commentDocuments.Select(ConvertCommentDocumentToModel).ToList();
        }

        private static Comment ConvertCommentDocumentToModel(CommentDocument commentDocument)
        {
            return new Comment
            {
                commentId = commentDocument.commentId,
                commRating= commentDocument.commRating,
                nickname = commentDocument.nickname,
                content= commentDocument.content,
                datePostedComment= commentDocument.datePostedComment,
                

            };
        }

        private static CommentDocument ConvertCommentModelToDocument(Comment comment)
        {
            return new CommentDocument
            {
                commentId = comment.commentId,
                commRating = comment.commRating,
                nickname = comment.nickname,
                content = comment.content,
                datePostedComment = comment.datePostedComment,
               
            };
        }

        public async Task AddCommentAsync(Comment comment)
        {
            var collection = _firestoreDb.Collection(_commentsCollectionName);
            var commentDocument = ConvertCommentModelToDocument(comment);

            await collection.AddAsync(commentDocument);
        }
       
        public async Task AddGameAsync(Game game)
        {
            var collection = _firestoreDb.Collection(_gamesCollectionName);
            var gameDocument = ConvertGameModelToDocument(game);

            await collection.AddAsync(gameDocument);
        }

        public async Task AddReviewAsync(Review review)
        {
            var collection = _firestoreDb.Collection(_reviewsCollectionName);
            var querySnapshot = await collection.WhereEqualTo("gameId", review.gameId).GetSnapshotAsync();
            if (querySnapshot.Count() > 0)
            {
                throw new InvalidOperationException("A review for this game already exists.");
            }

            var reviewDocument = ConvertReviewModelToDocument(review);

            await collection.AddAsync(reviewDocument);
        }
        private static Game ConvertGameDocumentToModel(GameDocument gameDocument)
        {
            return new Game
            {
                gameId = gameDocument.gameId,
                title = gameDocument.title,
                description = gameDocument.description,
                genre = gameDocument.genre
            };
        }

        private static GameDocument ConvertGameModelToDocument(Game game)
        {
            return new GameDocument
            {
                gameId = game.gameId,
                title = game.title,
                description = game.description,
                genre = game.genre
            };
        }
        


        private static Review ConvertReviewDocumentToModel(ReviewDocument reviewDocument)
        {
            return new Review
            {
                reviewId = reviewDocument.reviewId,
                content = reviewDocument.content,
                rating = reviewDocument.rating,
                gameId = reviewDocument.gameId
            };
        }

        private static ReviewDocument ConvertReviewModelToDocument(Review review)
        {
            return new ReviewDocument
            {
                reviewId = review.reviewId,
                content = review.content,
                rating = review.rating,
                gameId = review.gameId
            };
        }

        public async Task<Review> GetReviewByGameId(string gameId)
        {
            var collection = _firestoreDb.Collection(_reviewsCollectionName);
            var querySnapshot = await collection.WhereEqualTo("gameId", gameId).GetSnapshotAsync();

            if (querySnapshot.Documents.Any())
            {
                var review = ConvertReviewDocumentToModel(querySnapshot.Documents.First().ConvertTo<ReviewDocument>());
                review.content = Markdown.ToHtml(review.content); 
                return review;
            }
            return null;
        }
        public async Task<Review> GetReviewById(string reviewId)
        {
            var reviewRef = _firestoreDb.Collection(_reviewsCollectionName).Document(reviewId);
            var snapshot = await reviewRef.GetSnapshotAsync();

            if (snapshot.Exists)
            {
                return ConvertReviewDocumentToModel(snapshot.ConvertTo<ReviewDocument>());
            }

            return null;
        }

     
        public async Task<Game> GetGameById(string gameId)
        {
            var collection = _firestoreDb.Collection(_gamesCollectionName);
            var documentReference = collection.Document(gameId);
            var snapshot = await documentReference.GetSnapshotAsync();

            if (snapshot.Exists)
            {
                return ConvertGameDocumentToModel(snapshot.ConvertTo<GameDocument>());
            }
            return null;
        }
        public async Task<List<Review>> GetAllReviews()
        {
            var collection = _firestoreDb.Collection(_reviewsCollectionName);
            var snapshot = await collection.GetSnapshotAsync();

            var reviewDocuments = snapshot.Documents.Select(doc => doc.ConvertTo<ReviewDocument>()).ToList();
            return reviewDocuments.Select(ConvertReviewDocumentToModel).ToList();
        }

      


    }
}
