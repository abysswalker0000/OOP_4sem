namespace WebApp.Domain.Entities
{
    public class Review
    {
        public string reviewId { get; set; }
        public required string content { get; set; }
        public required double rating { get; set; }

        public string gameId { get; set; }
        public Game game { get; set; }

    }
}
